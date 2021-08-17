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
	public class ConcurrentList<T> : IList<T>, IReadOnlyList<T>, IEquatable<ConcurrentList<T>>
	{
		// It's not necessary to implement custom collection concurrency so this just uses a concurrent dictionary of
		// <int, T> for indexing object. 
		private readonly ConcurrentDictionary<int, T> _underlyingCollection;
		
		public ConcurrentList(IEnumerable<T> source)
		{
			this._underlyingCollection = new ConcurrentDictionary<int, T>();
			this.PopulateCollectionInternal(source);
		}

		public ConcurrentList()
		{
			this._underlyingCollection = new ConcurrentDictionary<int, T>();
		}

		public int Count => this._underlyingCollection.Count;
		public bool IsReadOnly => false;
		
		public T this[int index]
		{
			get => this._underlyingCollection[index];
			set => this._underlyingCollection[index] = value;
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
		
		public void Add(T item)
		{
			var ok = this._underlyingCollection.TryAdd(this.Count + 1, item);
			if (!ok)
			{
				ThrowHelper.ThrowInvalidOperationException($"Unable to successfully add {nameof(item)} to the collection. This was probably due to an internal key issue.");
			}
		}

		public bool TryAdd(T item)
		{
			return this._underlyingCollection.TryAdd(this.Count + 1, item);
		}
		
		public T AddOrUpdate(int index, T item, Func<int, T, T> factory)
		{
			return this._underlyingCollection.AddOrUpdate(index, item, factory);
		}
		
		public void AddRange(List<T> items)
		{
			for (var i = 0; i < items.Count; i++)
			{
				this._underlyingCollection.TryAdd(this.Count + 1, items[i]);
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