using System;

namespace WaifuShork.Common.Text;

public partial struct ValueString
{
    /// <summary>Represents a thread-safe, insertion only cache of values by type.</summary>
    /// <typeparam name="T">The type of cached values.</typeparam>
    private sealed class TypeCache<T>
    {
#if CONCURRENT_COLLECTIONS
            /// <summary>The internal dictionary.</summary>
            private readonly System.Collections.Concurrent.ConcurrentDictionary<Type, T> dictionary
                = new System.Collections.Concurrent.ConcurrentDictionary<Type, T>();
#else
        /// <summary>The internal dictionary.</summary>
        private readonly System.Collections.Generic.Dictionary<Type, T> dictionary
            = new System.Collections.Generic.Dictionary<Type, T>();

        /// <summary>The locker to synchronize access to <see cref="dictionary" />.</summary>
        private readonly System.Threading.ReaderWriterLockSlim locker
            = new System.Threading.ReaderWriterLockSlim();
#endif

        /// <summary>
        ///     Gets the value for the specified type, if it exists;
        ///     otherwise, creates a new one using the specified factory.
        /// </summary>
        /// <param name="key">The type to search.</param>
        /// <param name="valueFactory">The delegate to create a new value to cache.</param>
        /// <returns>The value that is retrieved from or added to the cache.</returns>
        public T GetOrAdd(Type key, Func<Type, T> valueFactory)
        {
#if CONCURRENT_COLLECTIONS
                return this.dictionary.GetOrAdd(key, valueFactory);
#else
            T result;

            this.locker.EnterUpgradeableReadLock();
            try
            {
                if (this.dictionary.TryGetValue(key, out result))
                    return result;

                result = valueFactory(key);
                this.locker.EnterWriteLock();
                try
                {
                    this.dictionary[key] = result;
                }
                finally
                {
                    this.locker.ExitWriteLock();
                }
            }
            finally
            {
                this.locker.ExitUpgradeableReadLock();
            }

            return result;
#endif
        }
    }
}