using System.Runtime.CompilerServices;
using System.Text;

namespace WaifuShork.Common
{
    using System;
    using QuickLinq;
    using Utilities;
    using Extensions;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    
	/// <summary>
    /// A circular buffer collection.
    /// </summary>
    /// <typeparam name="T">Type of elements within this ring buffer.</typeparam>
    [Serializable]
	public class ConcurrentRingBuffer<T> : ICollection<T>, IDeepEquatable<ConcurrentRingBuffer<T>>
    {
        private readonly object _syncLock = new();
        private bool _reachedEnd;

        /// <summary>
        /// Creates a new ring buffer with specified size.
        /// </summary>
        /// <param name="size">Size of the buffer to create.</param>
        /// <exception cref="ArgumentOutOfRangeException" />
        public ConcurrentRingBuffer(int size)
        {
            if (size <= 0)
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(size), "Size must be positive.");
            }

            this.CurrentIndex = 0;
            this.Capacity = size;
            this.InternalBuffer = new T[this.Capacity];
        }
        
        /// <summary>
        /// Creates a new ring buffer, filled with specified elements, and starting at specified index.
        /// </summary>
        /// <param name="elements">Elements to fill the buffer with.</param>
        /// <param name="index">Starting element index.</param>
        /// <exception cref="ArgumentException" />
        /// <exception cref="ArgumentOutOfRangeException" />
        public ConcurrentRingBuffer(T[] elements, int index = 0)
        {
            if (!elements.AnyF())
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(elements), "Cannot create a RingBuffer with no elements");    
            }
            
            this.CurrentIndex = index;
            this.InternalBuffer = elements.DeepClone();
            this.Capacity = this.InternalBuffer.Length;

            if (this.CurrentIndex >= this.InternalBuffer.Length || this.CurrentIndex < 0)
            {
                ThrowHelper.ThrowArgumentOutOfRangeException(nameof(index), "Index must be less than buffer capacity, and greater than zero.");
            }
        }
        
        /// <summary>
        /// Gets the current index of the buffer items.
        /// </summary>
        public int CurrentIndex
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets the capacity of this ring buffer.
        /// </summary>
        public int Capacity { get; protected set; }

        /// <summary>
        /// Gets the number of items in this ring buffer.
        /// </summary>
        public int Count => this._reachedEnd ? this.Capacity : this.CurrentIndex;

        /// <summary>
        /// Gets whether this ring buffer is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the internal collection of items.
        /// </summary>
        protected T[] InternalBuffer { get; set; }

        /// <summary>
        /// Inserts an item into this ring buffer.
        /// </summary>
        /// <param name="item">Item to insert.</param>
        public void Add(T item)
        {
            lock (this._syncLock)
            {
                this.InternalBuffer[this.CurrentIndex++] = item;

                if (this.CurrentIndex == this.Capacity)
                {
                    this.CurrentIndex = 0;
                    this._reachedEnd = true;
                }
            }
        }

        /// <summary>
        /// Gets first item from the buffer that matches the predicate.
        /// </summary>
        /// <param name="predicate">Predicate used to find the item.</param>
        /// <param name="item">Item that matches the predicate, or default value for the type of the items in this ring buffer, if one is not found.</param>
        /// <returns>Whether an item that matches the predicate was found or not.</returns>
        public bool TryGet(Func<T, bool> predicate, out T item)
        {
            lock (this._syncLock)
            {
                for (var i = this.CurrentIndex; i < this.InternalBuffer.Length; i++)
                {
                    if (this.InternalBuffer[i] != null && predicate(this.InternalBuffer[i]))
                    {
                        item = this.InternalBuffer[i];
                        return true;
                    }
                }
                for (var i = 0; i < this.CurrentIndex; i++)
                {
                    if (this.InternalBuffer[i] != null && predicate(this.InternalBuffer[i]))
                    {
                        item = this.InternalBuffer[i];
                        return true;
                    }
                }

                item = default;
                return false;
            }
        }

        /// <summary>
        /// Clears this ring buffer and resets the current item index.
        /// </summary>
        public void Clear()
        {
            lock (this._syncLock)
            {
                for (var i = 0; i < this.InternalBuffer.Length; i++)
                {
                    this.InternalBuffer[i] = default;
                }

                this.CurrentIndex = 0;
            }
        }

        /// <summary>
        /// Checks whether given item is present in the buffer. This method is not implemented. Use <see cref="Contains(Func{T, bool})"/> instead.
        /// </summary>
        /// <param name="item">Item to check for.</param>
        /// <returns>Whether the buffer contains the item.</returns>
        /// <exception cref="NotImplementedException" />
        public bool Contains(T item)
        {
            throw new NotImplementedException("This method is not implemented. Use .Contains(predicate) instead.");
        }

        /// <summary>
        /// Checks whether given item is present in the buffer using given predicate to find it.
        /// </summary>
        /// <param name="predicate">Predicate used to check for the item.</param>
        /// <returns>Whether the buffer contains the item.</returns>
        public bool Contains(Predicate<T> predicate)
        {
            lock (this._syncLock)
            {
                return this.InternalBuffer.AnyF(predicate);
            }
        }

        /// <summary>
        /// Copies this ring buffer to target array, attempting to maintain the order of items within.
        /// </summary>
        /// <param name="array">Target array.</param>
        /// <param name="index">Index starting at which to copy the items to.</param>
        public void CopyTo(T[] array, int index)
        {
            if (array.Length - index < 1)
            {
                ThrowHelper.ThrowArgumentException(nameof(array), "Target array is too small to contain the elements from this buffer.");
            }
            
            lock (this._syncLock)
            {
                var ci = 0;
                for (var i = this.CurrentIndex; i < this.InternalBuffer.Length; i++)
                {
                    array[ci++] = this.InternalBuffer[i];
                }

                for (var i = 0; i < this.CurrentIndex; i++)
                {
                    array[ci++] = this.InternalBuffer[i];
                }
            }
        }

        /// <summary>
        /// Removes an item from the buffer. This method is not implemented. Use <see cref="Remove(Func{T, bool})"/> instead.
        /// </summary>
        /// <param name="item">Item to remove.</param>
        /// <returns>Whether an item was removed or not.</returns>
        public bool Remove(T item)
        {
            throw new NotImplementedException("This method is not implemented. Use .Remove(predicate) instead.");
        }

        /// <summary>
        /// Removes an item from the buffer using given predicate to find it.
        /// </summary>
        /// <param name="predicate">Predicate used to find the item.</param>
        /// <returns>Whether an item was removed or not.</returns>
        public bool Remove(Predicate<T> predicate)
        {
            lock (this._syncLock)
            {
                for (var i = 0; i < this.InternalBuffer.Length; i++)
                {
                    if (this.InternalBuffer[i] != null && predicate(this.InternalBuffer[i]))
                    {
                        this.InternalBuffer[i] = default;
                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// Returns an enumerator for this ring buffer.
        /// </summary>
        /// <returns>Enumerator for this ring buffer.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            lock (this._syncLock)
            {
                if (!this._reachedEnd)
                {
                    return this.InternalBuffer.AsEnumerable().GetEnumerator();
                }
                return this.InternalBuffer.SkipF(this.CurrentIndex)
                    .Concat(this.InternalBuffer.TakeF(this.CurrentIndex))
                    .GetEnumerator();
            }
        }

        /// <summary>
        /// Returns an enumerator for this ring buffer.
        /// </summary>
        /// <returns>Enumerator for this ring buffer.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        
        public static implicit operator List<T>(ConcurrentRingBuffer<T> collection)
        {
            return collection.InternalBuffer.ToList();
        }

        public static explicit operator ConcurrentRingBuffer<T>(List<T> collection)
        {
            return new(collection.ToArray());
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"ConcurrentRingBuffer<{typeof(T)}>");
			
            for (var i = 0; i < this.Count; i++)
            {
                sb.AppendLine($"{this.InternalBuffer[i]}");
            }

            return sb.ToString();
        }

        public bool Equals(ConcurrentRingBuffer<T> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
			
            return Equals(this.InternalBuffer, other.InternalBuffer) && this.Count == other.Count;
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
			
            return this.Equals(obj as ConcurrentRingBuffer<T>);
        }

        public bool DeepEquals(ConcurrentRingBuffer<T> other)
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
            return this.InternalBuffer.GetHashCode();
        }

        public static bool operator ==(ConcurrentRingBuffer<T> left, ConcurrentRingBuffer<T> right)
        {
            if (left is null && right is null || 
                left is null && right is not null || 
                left is not null && right is null)
            {
                return false;
            }

            return left.Equals(right);
        }
		
        public static bool operator !=(ConcurrentRingBuffer<T> left, ConcurrentRingBuffer<T> right)
        {
            return !(left == right);
        }
    }
}