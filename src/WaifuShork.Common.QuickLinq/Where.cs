namespace Wyvern.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// --------------------------  ARRAYS --------------------------------------------

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>        
        public static T[] WhereF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new T[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result[idx] = source[i];
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate that includes the index in it's logic.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition along with the element's index.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static T[] WhereF<T>(this T[] source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }
            
            
            var result = new T[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result[idx] = source[i];
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        // --------------------------  Spans --------------------------------------------

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>        
        public static T[] WhereF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = new T[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result[idx] = source[i];
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate that includes the index in it's logic.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition along with the element's index.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static T[] WhereF<T>(this Span<T> source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }


            var result = new T[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result[idx] = source[i];
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }
        
        // --------------------------  LISTS --------------------------------------------

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static List<T> WhereF<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }            

            return source.FindAll(predicate);            
        }


        /// <summary>
        /// Filters a sequence of values based on a predicate that includes the index in it's logic.
        /// </summary>        
        /// <param name="source">A sequence to filter.</param>
        /// <param name="predicate">A function to test each element for a condition along with the element's index.</param>
        /// <returns>A sequence that contains elements from the input sequence that satisfy the condition.</returns>
        public static List<T> WhereF<T>(this List<T> source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var r = new List<T>();
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i], i))
                {
                    r.Add(source[i]);
                }
            }
            return r;
        }
	}
}