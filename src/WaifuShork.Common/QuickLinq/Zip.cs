namespace WaifuShork.Common.QuickLinq
{
	using System;
	using System.Collections.Generic;
    using Microsoft.Toolkit.Diagnostics;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		/// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>A sequence that contains merged elements of two input sequences.</returns>
        public static R[] ZipQ<T, U, R>(this T[] first, U[] second, Func<T, U, R> selector)
        {
            if (first == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(second));
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            // maintain array bounds elision
            if (first.Length < second.Length)
            {
                var result = new R[first.Length];
                for (var i = 0; i < first.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;

            }
            else
            {
                var result = new R[second.Length];
                for (var i = 0; i < second.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;
            }

        }

        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>A sequence that contains merged elements of two input sequences.</returns>
        public static R[] ZipQ<T, U, R>(this Span<T> first, Span<U> second, Func<T, U, R> selector)
        {
            if (first == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(second));
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            // maintain array bounds elision
            if (first.Length < second.Length)
            {
                var result = new R[first.Length];
                for (var i = 0; i < first.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;

            }
            else
            {
                var result = new R[second.Length];
                for (var i = 0; i < second.Length; i++)
                {
                    result[i] = selector(first[i], second[i]);
                }
                return result;
            }
        }

        /// <summary>
        /// Applies a specified function to the corresponding elements of two sequences, producing a sequence of the results.
        /// </summary>
        /// <param name="first">The first sequence to merge.</param>
        /// <param name="second">The second sequence to merge.</param>
        /// <param name="selector">A function that specifies how to merge the elements from the two sequences.</param>
        /// <returns>A sequence that contains merged elements of two input sequences.</returns>
        public static List<R> ZipQ<T, U, R>(this List<T> first, List<U> second, Func<T, U, R> selector)
        {
            if (first == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(first));
            }
            if (second == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(second));
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            // maintain array bounds elision
            if (first.Count < second.Count)
            {
                var result = new List<R>(first.Count);
                for (var i = 0; i < first.Count; i++)
                {
                    result.Add(selector(first[i], second[i]));
                }

                return result;

            }
            else
            {
                var result = new List<R>(second.Count);
                for (var i = 0; i < second.Count; i++)
                {
                    result.Add(selector(first[i], second[i]));
                }

                return result;
            }
        }
    }
}