// Based off of the Concurrent Collections to provide an easy to use thread-safe list-like collection 
// but provides an ordered, indexible collection

// This is a horrible implementation for concurrent lists, so avoid using it for now
// make a PR to fix it if you wish. I have ConcurrentList<T> implemented elsewhere that is much better
// this is purely an experimental version to create something much faster, and less allocating. 
namespace WaifuShork.Common
{
	using System;
	using System.Threading;
	using System.Diagnostics;
	using System.Collections;
	using System.Collections.Generic;
	using System.Diagnostics.Contracts;
	using Microsoft.Toolkit.Diagnostics;
	using System.Collections.ObjectModel;

	[Serializable]
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(CollectionDebugView<>))]
	[Obsolete("Use ConcurrentList<T> for now, this is wildly unoptimized and terrifying.")]
	public class VolatileList<T> : IList, IList<T>, IReadOnlyList<T>
	{
		// ============== FIELDS ============== \\
		private const int _defaultCapacity = 4;

		private T[] _items;
		[ContractPublicPropertyName("Count")]
		private int _size;

		private int _version;

		[NonSerialized] 
		private object _syncRoot;

		// Statically allocated array to provide a quicker T[0] implementation.
		private static readonly T[] _emptyArray = Array.Empty<T>();
		
		// ============== CONSTRUCTORS ============== \\
		public VolatileList()
		{
			_items = _emptyArray;
		}

		public VolatileList(int capacity)
		{
			if (capacity < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(capacity), "");
			}

			if (capacity == 0)
			{
				this._items = _emptyArray;
			}
			else
			{
				this._items = new T[capacity];
			}

			this._syncRoot = new object();
		}

		public VolatileList(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(collection), "");
			}

			if (collection is ICollection<T> c)
			{
				var count = c.Count;
				if (count == 0)
				{
					this._items = _emptyArray;
				}
				else
				{
					this._items = new T[count];
					c.CopyTo(this._items, 0);
					this._size = count;
				}
			}
			else
			{
				this._size = 0;
				this._items = _emptyArray;

				using var enumerator = collection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this.Add(enumerator.Current);
				}
			}
			
			this._syncRoot = new object();
		}

		// ============== PROPERTIES ============== \\
		public int Capacity
		{
			get
			{
				lock (this._syncRoot)
				{
					return this._items.Length;
				}
			}
			set
			{
				lock (this._syncRoot)
				{
					if (value < this._size)
					{
						ThrowHelper.ThrowArgumentOutOfRangeException(nameof(value));
					}

					if (value != this._items.Length)
					{
						if (value > 0)
						{
							var newItems = new T[value];

							if (this._size > 0)
							{
								Array.Copy(this._items, 0, newItems, 0, this._size);
							}

							_items = newItems;
						}
						else
						{
							this._items = _emptyArray;
						}
					}
				}
			}
		}

		public int Count
		{
			get
			{
				lock (this._syncRoot)
				{
					return this._size;
				}
			}
		}

		bool IList.IsFixedSize => false;
		bool ICollection<T>.IsReadOnly => false;
		bool IList.IsReadOnly => false;
		bool ICollection.IsSynchronized => true;

		object ICollection.SyncRoot
		{
			get
			{
				if (this._syncRoot == null)
				{
					Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
				}

				Debug.Assert(this._syncRoot != null);
				return this._syncRoot;
			}	
		}
		
		public T this[int index]
		{
			get
			{
				lock (this._syncRoot)
				{
					if ((uint)index >= (uint)this._size)
					{
						ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
					}

					return this._items[index];
				}
			}
			set
			{
				lock (this._syncRoot)
				{
					if ((uint)index >= (uint)this._size)
					{
						ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
					}

					this._items[index] = value;
					this._version++;
				}
			}
		}
		
		// Shouldn't need lock due to the fact that it accesses the thread-safe this[index], so by nature it should be thread-safe.
		object IList.this[int index]
		{
			get => this[index];
			set
			{
				try
				{
					this[index] = (T)value;
				}
				catch (InvalidCastException)
				{
					ThrowHelper.ThrowArgumentException(nameof(value), $"{typeof(T)}");
				}
			}
		}

		// ============== METHODS ============== \\
		private static bool IsCompatibleObject(object value)
		{
			return ((value is T) || value == null && default(T) == null);
		}
		
		// Don't enter lock because we want to avoid nesting locks. 
		public void CopyTo(Array array, int index)
		{
			if (array is T[] t)
			{
				this.CopyTo(t, index);
			}
		}

		public void CopyTo(T[] array, int arrayIndex = 0)
		{
			lock (this._syncRoot)
			{
				if ((array != null) && (array.Rank != 1))
				{
					ThrowHelper.ThrowArgumentException(nameof(array));
				}

				try
				{
					Array.Copy(this._items, 0, array, arrayIndex, this._size);
				}
				catch (ArrayTypeMismatchException)
				{
					ThrowHelper.ThrowArgumentException(nameof(array));
				}
			}
		}

		public void CopyTo(int index, T[] array, int arrayIndex, int count)
		{
			lock (this._syncRoot)
			{
				if (this._size - index < count)
				{
					ThrowHelper.ThrowArgumentException(nameof(index));
				}
			
				Array.Copy(this._items, index, array, arrayIndex, count);
			}
		}
		
		public void Add(T item)
		{
			lock (this._syncRoot)
			{
				if (this._size == this._items.Length)
				{
					this.EnsureCapacity(this._size + 1);
				}

				this._items[this._size++] = item;
				this._version++;
			}
		}

		int IList.Add(object item)
		{
			try
			{
				this.Add((T)item);
			}
			catch (InvalidOperationException)
			{
				ThrowHelper.ThrowArgumentException(nameof(item), "");
			}

			lock (this._syncRoot)
			{
				return this.Count - 1;
			}
		}

		public void AddRange(IEnumerable<T> collection)
		{
			this.InsertRange(this._size, collection);
		}

		public ReadOnlyCollection<T> AsReadOnly()
		{
			return new ReadOnlyCollection<T>(this);
		}

		public void Clear()
		{
			lock (this._syncRoot)
			{
				if (this._size > 0)
				{
					Array.Clear(this._items, 0, this._size);
					this._size = 0;
				}

				this._version++;
			}
		}

		public bool Contains(T item)
		{
			lock (this._syncRoot)
			{
				if (item == null)
				{
				
					for (var i = 0; i < this._size; i++)
					{
						if (this._items[i] == null)
						{
							return true;
						}
					}

					return false;
				}
			
				var comparer = EqualityComparer<T>.Default;
				for (var i = 0; i < this._size; i++)
				{
					if (comparer.Equals(this._items[i], item))
					{
						return true;
					}
				}

				return false;	
			}
		}
		
		bool IList.Contains(object item)
		{
			if (IsCompatibleObject(item))
			{
				return this.Contains((T)item);
			}

			return false;
		}

		public VolatileList<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
		{
			if (converter == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(converter));
			}

			lock (this._syncRoot)
			{
				var list = new VolatileList<TOutput>(this._size);
				for (var i = 0; i < this._size; i++)
				{
					list._items[i] = converter(this._items[i]);
				}

				list._size = this._size;
				return list;
			}
		}

		public bool Exists(Predicate<T> match)
		{
			return this.FindIndex(match) != -1;
		}

		public T Find(Predicate<T> match)
		{
			if (match == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(match));
			}

			lock (this._syncRoot)
			{
				for (var i = 0; i < this._size; i++)
				{
					if (match(this._items[i]))
					{
						return this._items[i];
					}
				}

				return default;
			}
		}

		public VolatileList<T> FindAll(Predicate<T> match)
		{
			if (match == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(match));
			}

			var list = new VolatileList<T>();
			lock (this._syncRoot)
			{
				for (var i = 0; i < this._size; i++)
				{
					if (match(this._items[i]))
					{
						list.Add(this._items[i]);
					}
				}

				return list;
			}
		}

		public int FindIndex(Predicate<T> match)
		{
			return this.FindIndex(0, this._size, match);
		}

		public int FindIndex(int startIndex, Predicate<T> match)
		{
			return this.FindIndex(startIndex, this._size - startIndex, match);
		}
		
		public int FindIndex(int startIndex, int count, Predicate<T> match)
		{
			lock (this._syncRoot)
			{
				if ((uint)startIndex > (uint)this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(startIndex));
				}

				if (count < 0 || startIndex > this._size - count)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
				}
			
				if (match == null)
				{
					ThrowHelper.ThrowArgumentNullException(nameof(match));
				}

				var endIndex = startIndex + count;
				for (var i = startIndex; i < endIndex; i++)
				{
					if (match(this._items[i]))
					{
						return i;
					}
				}

				return -1;
			}
		}
		
		public T FindLast(Predicate<T> match) 
		{
            if(match == null) 
            {
                ThrowHelper.ThrowArgumentNullException(nameof(match));
            }

            lock (this._syncRoot)
            {
	            for(var i = _size - 1 ; i >= 0; i--) 
	            {
		            if(match(_items[i])) 
		            {
			            return _items[i];
		            }
	            }
	            return default;
            }
		}
 
        public int FindLastIndex(Predicate<T> match) 
        {
            return FindLastIndex(_size - 1, _size, match);
        }
   
        public int FindLastIndex(int startIndex, Predicate<T> match) 
        {
            return FindLastIndex(startIndex, startIndex + 1, match);
        }
 
        public int FindLastIndex(int startIndex, int count, Predicate<T> match) 
        {
            if( match == null) 
            {
                ThrowHelper.ThrowArgumentNullException(nameof(match));
            }

            lock (this._syncRoot)
            {
	            if(_size == 0) 
	            {
		            // Special case for 0 length List
		            if(startIndex != -1) 
		            {
			            ThrowHelper.ThrowArgumentOutOfRangeException(nameof(startIndex));
		            }
	            }
	            else 
	            {
		            // Make sure we're not out of range            
		            if ((uint)startIndex >= (uint)_size) 
		            {
			            ThrowHelper.ThrowArgumentOutOfRangeException(nameof(startIndex));
		            }
	            }
            
	            // 2nd have of this also catches when startIndex == MAXINT, so MAXINT - 0 + 1 == -1, which is < 0.
	            if (count < 0 || startIndex - count + 1 < 0) 
	            {
		            ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
	            }
                        
	            var endIndex = startIndex - count;
	            for(var i = startIndex; i > endIndex; i--) 
	            {
		            if( match(_items[i])) 
		            {
			            return i;
		            }
	            }
	            return -1;
            }
        }

        public void ForEach(Action<T> action)
        {
	        if (action == null)
	        {
		        ThrowHelper.ThrowArgumentNullException(nameof(action));
	        }

	        lock (this._syncRoot)
	        {
		        for (var i = 0; i < this._size; i++)
		        {
			        action(this._items[i]);
		        }
	        }
        }

        public int IndexOf(T item)
		{
			lock (this._syncRoot)
			{
				return Array.IndexOf(this._items, item, 0, this._size);
			}
		}

		int IList.IndexOf(object item)
		{
			if (IsCompatibleObject(item))
			{
				return this.IndexOf((T)item);
			}

			return -1;
		}

		public int IndexOf(T item, int index)
		{
			lock (this._syncRoot)
			{
				if (index > this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}

				return Array.IndexOf(this._items, item, index, this._size - index);
			}
		}

		public int IndexOf(T item, int index, int count)
		{
			lock (this._syncRoot)
			{
				if (index > this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}

				if (count < 0 || index > this._size - count)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException();
				}

				return Array.IndexOf(this._items, item, index, count);
			}
		}

		public void Insert(int index, T item)
		{
			lock (this._syncRoot)
			{
				if ((uint)index > (uint)this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}

				if (this._size == this._items.Length)
				{
					this.EnsureCapacity(this._size + 1);
				}

				if (index < this._size)
				{
					Array.Copy(this._items, index, this._items, index + 1, this._size - index);
				}

				this._items[index] = item;
				this._size++;
				this._version++;
			}
		}

		void IList.Insert(int index, object item)
		{
			try
			{
				this.Insert(index, (T)item);
			}
			catch (InvalidCastException)
			{
				ThrowHelper.ThrowInvalidOperationException();
			}
		}

		public void InsertRange(int index, IEnumerable<T> collection)
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(collection));
			}

			lock (this._syncRoot)
			{
				if ((uint)index > (uint)this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}

				if (collection is ICollection<T> c)
				{
					var count = c.Count;
					if (count > 0)
					{
						this.EnsureCapacity(this._size + count);

						if (index < this._size)
						{
							Array.Copy(this._items, index, this._items, index + count, this._size - index);
						}

						if (this == c)
						{
							Array.Copy(this._items, 0, this._items, index, index);
							Array.Copy(this._items, index + count, this._items, index * 2, this._size - index);
						}
						else
						{
							var itemsToInsert = new T[count];
							c.CopyTo(itemsToInsert, 0);
							itemsToInsert.CopyTo(this._items, index);
						}

						this._size += count;
					}
				}
				else
				{
					using var enumerator = collection.GetEnumerator();
					while (enumerator.MoveNext())
					{
						this.Insert(index++, enumerator.Current);
					}
				}

				this._version++;
			}
		}

		public int LastIndexOf(T item)
		{
			lock (this._syncRoot)
			{
				if (this._size == 0)
				{
					return -1;
				}	
			}

			return this.LastIndexOf(item, this._size - 1, this._size);
		}

		public int LastIndexOf(T item, int index)
		{
			lock (this._syncRoot)
			{
				if (index >= this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}	
			}
			
			return this.LastIndexOf(item, index, index + 1);
		}

		public int LastIndexOf(T item, int index, int count)
		{
			lock (this._syncRoot)
			{
				if ((this.Count != 0) && (index < 0))
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}

				if ((this.Count != 0) && (count < 0))
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
				
				}

				if (this._size == 0)
				{
					return -1;
				}

				if (index >= this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
				}

				if (count > index + 1)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
				}

				return Array.LastIndexOf(this._items, item, index, count);
			}
		}

		public bool Remove(T item)
		{
			var index = this.IndexOf(item);
			if (index >= 0)
			{
				this.RemoveAt(index);
				return true;
			}

			return false;
		}

		void IList.Remove(object item)
		{
			if (IsCompatibleObject(item))
			{
				this.Remove((T)item);
			}
		}

		public int RemoveAll(Predicate<T> match)
		{
			if (match == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(match));
			}
			
			var freeIndex = 0;

			lock (this._syncRoot)
			{
				while (freeIndex < this._size && !match(this._items[freeIndex]))
				{
					freeIndex++;
				}

				if (freeIndex >= this._size)
				{
					return 0;
				}

				var current = freeIndex + 1;
				while (current < this._size)
				{
					while (current < this._size && match(this._items[current]))
					{
						current++;
					}

					if (current < this._size)
					{
						this._items[freeIndex++] = this._items[current++];
					}
				}
			
				Array.Clear(this._items, freeIndex, this._size - freeIndex);
				var result = this._size - freeIndex;
				this._size = freeIndex;
				this._version++;
				return result;
			}
		}
		
		public void RemoveAt(int index)
		{
			lock (this._syncRoot)
			{
				if ((uint)index >= this._size)
				{
					ThrowHelper.ThrowArgumentOutOfRangeException();
				}

				this._size--;
				if (index < this._size)
				{
					Array.Copy(this._items, index + 1, this._items, index, this._size - index);
				}

				this._items[this._size] = default;
				this._version++;
			}
		}

		public void RemoveRange(int index, int count)
		{
			if (index < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}
			
			if (count < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}

			lock (this._syncRoot)
			{
				if (this._size - index < count)
				{
					ThrowHelper.ThrowArgumentException();
				}

				if (count > 0)
				{
					var i = this._size;
					this._size -= count;
					if (index < this._size)
					{
						Array.Copy(this._items, index + count, this._items, index, this._size - index);
					}
				
					Array.Clear(this._items, this._size, count);
					this._version++;
				}
			}
		}

		public void Reverse()
		{
			this.Reverse(0, this.Count);
		}

		public void Reverse(int index, int count)
		{
			if (index < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}
			
			if (count < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}

			lock (this._syncRoot)
			{
				if (this._size - index < count)
				{
					ThrowHelper.ThrowArgumentException();
				}
			
				Array.Reverse(this._items, index, count);
				this._version++;
			}
		}
		
		public void Sort()
		{
			this.Sort(0, Count, null);
		}
 
	
		public void Sort(IComparer<T> comparer)
		{
			this.Sort(0, Count, comparer);
		}
		
		public void Sort(int index, int count, IComparer<T> comparer) 
		{
			if (index < 0) 
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}
            
			if (count < 0) 
			{
				ThrowHelper.ThrowArgumentOutOfRangeException();
			}

			lock (this._syncRoot)
			{
				if (this._size - index < count)
				{
					ThrowHelper.ThrowArgumentException();
				}
 
				Array.Sort(this._items, index, count, comparer);
				this._version++;
			}
		}
 
		public void Sort(Comparison<T> comparison) 
		{
			if( comparison == null) 
			{
				ThrowHelper.ThrowArgumentNullException();
			}

			lock (this._syncRoot)
			{
				if( _size > 0)
				{
					var comparer = new FunctorComparer<T>(comparison);
					Array.Sort(_items, 0, _size, comparer);
				}
			}
		}
		
		public int BinarySearch(int index, int count, T item, IComparer<T> comparer)
		{
			if (index < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index), "");
			}

			if (count < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count), "");
			}

			lock (this._syncRoot)
			{
				if (this._size - index < count)
				{
					ThrowHelper.ThrowArgumentException("Invalid length");
				}

				return Array.BinarySearch(this._items, index, count, item, comparer);
			}
		}

		public void TrimExcess()
		{
			lock (this._syncRoot)
			{
				var threshold = (int)(this._items.Length * 0.9);
				if (this._size < threshold)
				{
					this.Capacity = this._size;
				}
			}
		}
		
		public bool TrueForAll(Predicate<T> match)
		{
			if (match == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(match));
			}

			lock (this._syncRoot)
			{
				for (var i = 0; i < this._size; i++)
				{
					if (!match(this._items[i]))
					{
						return false;
					}
				}

				return true;
			}
		}
		
		public int BinarySearch(T item)
		{
			return this.BinarySearch(0, this.Count, item, null);
		}

		public int BinarySearch(T item, IComparer<T> comparer)
		{
			return this.BinarySearch(0, this.Count, item, comparer);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return new Enumerator(this);
		}
		
		IEnumerator IEnumerable.GetEnumerator()
		{
			return new Enumerator(this);
		}

		public VolatileList<T> GetRange(int index, int count)
		{
			if (index < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index));
			}

			if (count < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
			}

			lock (this._syncRoot)
			{
				if (this._size - index < count)
				{
					ThrowHelper.ThrowArgumentNullException();
				}

				var list = new VolatileList<T>(count);
				Array.Copy(this._items, index, list._items, 0, count);
				list._size = count;
				return list;
			}
		}

		public T[] ToArray()
		{
			lock (this._syncRoot)
			{
				var array = new T[this._size];
				Array.Copy(this._items, 0, array, 0, this._size);
				return array;
			}
		}

		public List<T> ToList()
		{
			lock (this._syncRoot)
			{
				var list = new List<T>(this._size);
				for (var i = 0; i < list.Count; i++)
				{
					list.Add(this._items[i]);
				}

				return list;
			}
		}
		
		// This **should** be thread-safe, I'll fix it later if it's not. 
		private void EnsureCapacity(int min)
		{
			if (this._items.Length < min)
			{
				var newCapacity = this._items.Length == 0 ? _defaultCapacity : this._items.Length * 2;
				// Max array length, not sure why this property isn't publicly available ._.
				if ((uint)newCapacity > 0X7FEFFFFF)
				{
					newCapacity = 0X7FEFFFFF;
				}

				if (newCapacity < min)
				{
					newCapacity = min;
				}

				this.Capacity = newCapacity;
			}
		}
		
		public struct Enumerator : IEnumerator<T>
		{
			private VolatileList<T> _list;
			private int _index;
			private int _version;
			private T _current;

			internal Enumerator(VolatileList<T> list)
			{
				this._list = list;
				this._index = 0;
				this._version = this._list._version;
				this._current = default;
			}

			public T Current => this._current;

			object IEnumerator.Current
			{
				get
				{
					if (this._index == 0 || this._index == this._list._size + 1)
					{
						ThrowHelper.ThrowInvalidOperationException();
					}

					return this.Current;
				}
			}
			
			public bool MoveNext()
			{
				var localList = this._list;

				if (this._version == localList._version && ((uint)this._index < (uint)localList._size))
				{
					this._current = localList._items[this._index];
					this._index++;
					return true;
				}

				return this.MoveNextRare();
			}

			private bool MoveNextRare()
			{
				if (this._version != this._list._version)
				{
					ThrowHelper.ThrowInvalidOperationException();
				}

				this._index = this._list._size + 1;
				this._current = default;
				return false;
			}

			void IEnumerator.Reset()
			{
				if (this._version != this._list._version)
				{
					ThrowHelper.ThrowInvalidOperationException();
				}

				this._index = 0;
				this._current = default;
			}

			public void Dispose() { }
		}
	}

	internal sealed class CollectionDebugView<T> 
	{
		private readonly ICollection<T> collection; 
        
		public CollectionDebugView(ICollection<T> collection) 
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(collection));
			}
 
			this.collection = collection;
		}
       
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public T[] Items   
		{ 
			get {
				var items = new T[collection.Count];
				collection.CopyTo(items, 0);
				return items;
			}
		}
	}    
	
	internal sealed class FunctorComparer<T> : IComparer<T> 
	{
		private readonly Comparison<T> _comparison;
 
		public FunctorComparer(Comparison<T> comparison)
		{
			this._comparison = comparison;
		}
 
		public int Compare(T x, T y) 
		{
			return this._comparison(x, y);
		}
	}
}