namespace WaifuShork.Common
{
	using System;
	using System.Linq;
	using System.Text;
	using System.Threading;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.Concurrent;
	
	// TODO: As of right now this is a very very primitive wrapper for ConcurrentDictionary<TKey, TValue> to create a ConcurrentList<T>, but needs to be vastly improved 
	[Serializable]
	public class ConcurrentList<T> : IList<T>, IReadOnlyList<T>, IDeepEquatable<ConcurrentList<T>>
	{
		private readonly ConcurrentDictionary<int, T> _underlyingCollection;
		private volatile int _size;
		
		public ConcurrentList(IEnumerable<T> source)
		{
			this._underlyingCollection = new ConcurrentDictionary<int, T>();
			this.PopulateCollectionInternal(source);
			this._size = this._underlyingCollection.Count;
		}

		public ConcurrentList()
		{
			this._underlyingCollection = new ConcurrentDictionary<int, T>();
			this._size = 0;
		}

		public int Count => this._size;
		public bool IsReadOnly => false;
		
		public T this[int index]
		{
			get => this._underlyingCollection[index];
			set
			{
				// Increment if applicable
				if (index > this._size)
				{
					this._size = index;
				}
				
				this._underlyingCollection[index] = value;
			}
		}

		private void PopulateCollectionInternal(IEnumerable<T> source)
		{
			var array = source.ToArray();
			var size = array.Length;

			for (var i = 0; i < size; i++)
			{
				this._underlyingCollection[i] = array[i];
			}
		}
		
		public IEnumerator<T> GetEnumerator()
		{
			return this._underlyingCollection.Values.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public void AddRange(IEnumerable<T> items)
		{
			foreach (var item in items)
			{
				Interlocked.Increment(ref this._size);
				this._underlyingCollection[this._size] = item;
			}
		}
		
		public void Add(T item)
		{
			Interlocked.Increment(ref this._size);
			this._underlyingCollection[this._size] = item;
		}

		public void Clear()
		{
			for (var i = 0; i < this.Count; i++)
			{
				Interlocked.Decrement(ref this._size);
			}
			
			this._underlyingCollection.Clear();
		}

		public bool Contains(T item)
		{
			return this._underlyingCollection.Values.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			this._underlyingCollection.Values.CopyTo(array, arrayIndex);
		}

		public bool Remove(T item)
		{
			Interlocked.Increment(ref this._size);
			return this._underlyingCollection.TryRemove(this._size, out _);
		}
		
		public int IndexOf(T item)
		{
			return Array.IndexOf(this._underlyingCollection.Values.ToArray(), item, 0, this._underlyingCollection.Count);
		}

		public void Insert(int index, T item)
		{
			// Increment if applicable
			if (index > this._size)
			{
				this._size = index;
			}
			
			this._underlyingCollection[index] = item;
		}

		public void RemoveAt(int index)
		{
			Interlocked.Decrement(ref this._size);
			this._underlyingCollection.TryRemove(index, out _);
		}

		public static implicit operator List<T>(ConcurrentList<T> collection)
		{
			return collection._underlyingCollection.Values.ToList();
		}

		public static explicit operator ConcurrentList<T>(List<T> collection)
		{
			return new(collection);
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine($"ConcurrentList<{typeof(T)}>");
			
			for (var i = 0; i < this._size; i++)
			{
				sb.AppendLine($"{this._underlyingCollection[i]}");
			}

			return sb.ToString();
		}

		public bool Equals(ConcurrentList<T> other)
		{
			if (ReferenceEquals(null, other))
			{
				return false;
			}

			if (ReferenceEquals(this, other))
			{
				return true;
			}
			
			return Equals(this._underlyingCollection, other._underlyingCollection) && this._size == other._size;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj))
			{
				return false;
			}

			if (ReferenceEquals(this, obj))
			{
				return true;
			}

			if (obj.GetType() != this.GetType())
			{
				return false;
			}
			
			return this.Equals(obj as ConcurrentList<T>);
		}

		public bool DeepEquals(ConcurrentList<T> other)
		{
			if (ReferenceEquals(this, other))
			{
				return true;
			}

			if (this is null || other is null)
			{
				return false;
			}

			return this.SequenceEqual(other);
		}

		public override int GetHashCode()
		{
			return this._underlyingCollection.Values.GetHashCode();
		}

		public static bool operator ==(ConcurrentList<T> left, ConcurrentList<T> right)
		{
			if ((left is null && right is null) || 
			    (left is null && right is not null) || 
			    (left is not null && right is null))
			{
				return false;
			}

			return left.Equals(right);
		}
		
		public static bool operator !=(ConcurrentList<T> left, ConcurrentList<T> right)
		{
			return !(left == right);
		}
	}
}