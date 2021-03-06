using Microsoft.Toolkit.Diagnostics;

namespace WaifuShork.Common.QuickLinq
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
        /// Combined Where and Select for optimal performance.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static TResult[] WhereSelectQ<T, TResult>(this T[] source, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var result = new TResult[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result[idx] = selector(source[i]);
                    idx++;
                }
            }
            
            Array.Resize(ref result, idx);
            return result;
        }

        /// <summary>
        /// Combined Where and Select for optimal performance that uses the index in the 
        /// predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static TResult[] WhereSelectQ<T, TResult>(this T[] source, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var result = new TResult[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result[idx] = selector(source[i], idx);
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }


        // --------------------------  SPANS --------------------------------------------
        
        /// <summary>
        /// Combined Where and Select for optimal performance.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static TResult[] WhereSelectQ<T, TResult>(this Span<T> source, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var result = new TResult[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result[idx] = selector(source[i]);
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }

        /// <summary>
        /// Combined Where and Select for optimal performance that uses the index in the 
        /// predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static TResult[] WhereSelectQ<T, TResult>(this Span<T> source, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var result = new TResult[source.Length];
            var idx = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result[idx] = selector(source[i], idx);
                    idx++;
                }
            }
            Array.Resize(ref result, idx);
            return result;
        }


        // --------------------------  LISTS --------------------------------------------

        /// <summary>
        /// Combined Where and Select for optimal performance.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static List<TResult> WhereSelectQ<T, TResult>(this List<T> source, Func<T, bool> predicate, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = new List<TResult>();
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    r.Add(selector(source[i]));
                }
            }
            return r;
        }

        /// <summary>
        /// Combined Where and Select for optimal performance that uses the index in the 
        /// predicate and selector.
        /// </summary>        
        /// <param name="source">The input sequence to filter then transform.</param>
        /// <param name="predicate">A function to use to filter the sequence.</param>
        /// <param name="selector">A function to transform the filtered elements.</param>
        /// <returns>A sequence of filtered and transformed elements.</returns>
        public static List<TResult> WhereSelectQ<T, TResult>(this List<T> source, Func<T, int, bool> predicate, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = new List<TResult>();
            var idx = 0;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i], i)) 
                {
                    r.Add(selector(source[i], idx));
                    idx++;
                }
            }
            
            return r;
        }
	}
}