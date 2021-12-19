namespace WaifuShork.Common
{
	using System;
	using System.Linq;
	using System.Collections;
	using System.Collections.Generic;
	using Microsoft.Toolkit.Diagnostics;
	using System.Collections.Concurrent;
	
	/// <summary>
	/// Represents a thread-safe ordered list of <see cref="T"/>, with the underlying safety coming from <seealso cref="ConcurrentDictionary{TKey,TValue}"/>,
	/// with an integer as TKey and <see cref="T"/> as the value, giving you a near identical experience to as if Microsoft directly implemented a ConcurrentList
	/// </summary>
	/// <typeparam name="T"></typeparam>
	[Serializable]
	public class ConcurrentList<T> : IList<T>, IReadOnlyList<T>, IDeepEquatable<ConcurrentList<T>>
	{
		// It's not necessary to implement custom collection concurrency so this just uses a concurrent dictionary of
		// <int, T> for indexing object. 
		private readonly ConcurrentDictionary<int, T> _underlyingCollection;
		private static int _defaultConcurrencyLevel => Environment.ProcessorCount;
		
		public ConcurrentList()
		{
			this._underlyingCollection = new ConcurrentDictionary<int, T>();
		}

		public ConcurrentList(int concurrencyLevel, int capacity)
		{
			if (capacity < 0)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(capacity), "Capacity cannot be a negative value.");
			}

			if (capacity == 0)
			{
				this._underlyingCollection = new ConcurrentDictionary<int, T>();
			}
			else
			{
				this._underlyingCollection = new ConcurrentDictionary<int, T>(concurrencyLevel, capacity);
			}
			
		}
		
		public ConcurrentList(IEnumerable<T> collection)
		{
			if (collection == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(collection), $"Cannot initialize ConcurrentList<{typeof(T)}> with a null collection of {typeof(T)}");
			}

			if (collection is ICollection<T> c)
			{
				var count = c.Count;
				if (count == 0)
				{
					this._underlyingCollection = new ConcurrentDictionary<int, T>(_defaultConcurrencyLevel, 0);
				}
				else
				{
					this._underlyingCollection = new ConcurrentDictionary<int, T>();

					foreach (var item in c)
					{
						this.Add(item);
					}
				}
			}
			else
			{
				this._underlyingCollection = new ConcurrentDictionary<int, T>(_defaultConcurrencyLevel, 0);

				using var enumerator = collection.GetEnumerator();
				while (enumerator.MoveNext())
				{
					this.Add(enumerator.Current);
				}
			}
		}

		public int Count => this._underlyingCollection.Count;
		public bool IsReadOnly => false;
		
		public T this[int index]
		{
			get => this._underlyingCollection[index];
			set => this._underlyingCollection[index] = value;
		}

		private static bool IsValueWriteAtomic()
		{
			// Section 12.6.6 of ECMA CLI explains which types can be read and written atomically without
			// the risk of tearing. See https://www.ecma-international.org/publications/files/ECMA-ST/ECMA-335.pdf
			if (!typeof(T).IsValueType ||
			    typeof(T) == typeof(IntPtr) ||
			    typeof(T) == typeof(UIntPtr))
			{
				return true;
			}

			switch (Type.GetTypeCode(typeof(T)))
			{
				case TypeCode.Boolean:
				case TypeCode.Byte:
				case TypeCode.SByte:
				case TypeCode.Char:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Single:
				{
					return true;
				}
				case TypeCode.Double:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				{
					return IntPtr.Size == 8;
				}
				default:
				{
					return false;
				}
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
		
		public void Add(T item)
		{
			this._underlyingCollection[this.Count] = item;
		}

		public bool TryAdd(T item)
		{
			try
			{
				this._underlyingCollection[this.Count] = item;
				return true;
			}
			catch
			{
				return false;
			}
		}
		
		public T AddOrUpdate(int index, T item, Func<int, T, T> factory)
		{
			return this._underlyingCollection.AddOrUpdate(index, item, factory);
		}
		
		public void AddRange(IEnumerable<T> items)
		{
			var itemArray = items.ToArray();
			foreach (var item in itemArray)
			{
				var ok = this._underlyingCollection.TryAdd(this.Count + 1, item);
				if (!ok)
				{
					continue;
				}
			}
		}

		public bool TryUpdate(int index, T newValue, T comparisonValue)
		{
			return this._underlyingCollection.TryUpdate(index, newValue, comparisonValue);
		}
		
		public void Insert(int index, T item)
		{
			this._underlyingCollection[index] = item;
		}

		public bool Remove(T item)
		{
			for (var i = 0; i < this.Count; i++)
			{
				var ok = this._underlyingCollection.TryGetValue(i, out var value);
				
				if (!ok)
				{
					continue;
				}

				if (value == null)
				{
					continue;
				}

				if (!value.Equals(item))
				{
					continue;
				}
				
				return this._underlyingCollection.Remove(i, out _);
			}

			return false;
		}
		
		public void RemoveAt(int index)
		{
			this._underlyingCollection.TryRemove(index, out _);
		}

		public void Remove(Func<T, bool> predicate)
		{
			var foundMatch = false;
			for (var i = 0; i < this.Count; i++)
			{
				var ok = this._underlyingCollection.TryGetValue(i, out var value);
				if (!ok)
				{
					continue;
				}

				if (value == null)
				{
					continue;
				}
				
				if (predicate(value))
				{
					if (foundMatch)
					{
						ThrowHelper.ThrowInvalidOperationException("Sequence contains more than one matching element.");
					}

					ok = this._underlyingCollection.TryRemove(i, out _);
					if (!ok)
					{
						ThrowHelper.ThrowInvalidOperationException($"Unable to remove the selected item based on the given predicate.");
					}
					
					foundMatch = true;
				}
			}
		}
		
		public void Clear()
		{
			this._underlyingCollection.Clear();
		}

		public bool Contains(T item)
		{
			for (var i = 0; i < this.Count; i++)
			{
				var value = this._underlyingCollection[i];
				if (value.Equals(item))
				{
					return true;
				}
			}

			return false;
			
			// return this._underlyingCollection.Values.Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			/*for (var i = 0; i < this.Count; i++)
			{
				var ok = this._underlyingCollection.TryGetValue(i, out var value);
				if (!ok)
				{
					continue;
				}

				if (value == null)
				{
					continue;
				}

				array[i] = value;
			}*/
			
			this._underlyingCollection.Values.CopyTo(array, arrayIndex);
		}

		
		public int IndexOf(T item)
		{
			for (var i = 0; i < this.Count; i++)
			{
				var ok = this._underlyingCollection.TryGetValue(i, out var value);
				if (!ok)
				{
					continue;
				}

				if (value == null)
				{
					continue;
				}

				if (value.Equals(item))
				{
					return i;
				}
			}

			ThrowHelper.ThrowArgumentException(nameof(item), $"Unable to locate {item?.ToString() ?? nameof(item)} to get a valid index for.");
			return default;
			// return 0;
			// return Array.IndexOf(this._underlyingCollection.Values.ToArray(), item, 0, this._underlyingCollection.Count);
		}

		public static implicit operator List<T>(ConcurrentList<T> collection)
		{
			return collection._underlyingCollection.Values.ToList();
		}

		public static explicit operator ConcurrentList<T>(List<T> collection)
		{
			return new(collection);
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

			return Equals(this._underlyingCollection, other._underlyingCollection) && this.Count == other.Count;
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
			if (left is null && right is null)
			{
				return false;
			}

			if (left is null && right is not null)
			{
				return false;
			}

			if (left is not null && right is null)
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