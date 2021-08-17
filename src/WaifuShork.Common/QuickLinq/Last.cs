
namespace WaifuShork.Common.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    using Microsoft.Toolkit.Diagnostics;

	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// --------------------------  Arrays --------------------------------------------

        /// <summary>
        /// Returns the last element of a sequence.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>The value at the last position in the source sequence.</returns>
        public static T LastQ<T>(this T[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            return source[^1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">A sequence to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>       
        public static T LastQ<T>(this T[] source, Predicate<T> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var lastIndex = Array.FindLastIndex(source, predicate);

            if (lastIndex == -1)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            return source[lastIndex];
        }

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>default value if the source sequence is empty; otherwise, 
        /// the last element in the sequence</returns>
        public static T LastOrDefaultQ<T>(this T[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                return default;
            }
            return source[^1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
        /// </summary>        
        /// <param name="source">A sequence to return the last element of.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>default value if the sequence is empty or if no elements pass the test 
        /// in the predicate function; otherwise, the last element that passes the test in the 
        /// predicate function.</returns>
        public static T LastOrDefaultQ<T>(this T[] source, Predicate<T> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var lastIndex = Array.FindLastIndex(source, predicate);

            if (lastIndex == -1)
            {
                return default;
            }
            
            return source[lastIndex];
        }

        // --------------------------  this Spans --------------------------------------------

        /// <summary>
        /// Returns the last element of a sequence.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>The value at the last position in the source sequence.</returns>
        public static T LastQ<T>(this Span<T> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            return source[^1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">A sequence to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>       
        public static T LastQ<T>(this Span<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            for (var i = source.Length - 1; i >= 0; i--)
            {
                if (predicate(source[i])) return source[i];
            }
            
            ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            return (T)(object)null;
        }

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>default value if the source sequence is empty; otherwise, 
        /// the last element in the sequence</returns>
        public static T LastOrDefaultQ<T>(this Span<T> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                return default;
            }
            return source[^1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
        /// </summary>        
        /// <param name="source">A sequence to return the last element of.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>default value if the sequence is empty or if no elements pass the test 
        /// in the predicate function; otherwise, the last element that passes the test in the 
        /// predicate function.</returns>
        public static T LastOrDefaultQ<T>(this Span<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }
            
            for (var i = source.Length - 1; i >= 0; i--)
            {
                if (predicate(source[i])) return source[i];
            }

            
            return default;
            
        }

        // --------------------------  Lists --------------------------------------------

        /// <summary>
        /// Returns the last element of a sequence.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>The value at the last position in the source sequence.</returns>
        public static T LastQ<T>(this List<T> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            return source[^1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">A sequence to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        public static T LastQ<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var lastIndex = source.FindLastIndex(predicate);

            if (lastIndex == -1)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            return source[lastIndex];
        }

        /// <summary>
        /// Returns the last element of a sequence, or a default value if the sequence contains no elements.
        /// </summary>        
        /// <param name="source">An sequence to return the last element of.</param>
        /// <returns>default value if the source sequence is empty; otherwise, 
        /// the last element in the sequence</returns>        
        public static T LastOrDefaultQ<T>(this List<T> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                return default;
            }
            return source[^1];
        }

        /// <summary>
        /// Returns the last element of a sequence that satisfies a condition or a default value if no such element is found.
        /// </summary>        
        /// <param name="source">A sequence to return the last element of.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>default value if the sequence is empty or if no elements pass the test 
        /// in the predicate function; otherwise, the last element that passes the test in the 
        /// predicate function.</returns>
        public static T LastOrDefaultQ<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var lastIndex = source.FindLastIndex(predicate);

            if (lastIndex == -1)
            {
                return default;
            }
            
            return source[lastIndex];
        }
	}
}