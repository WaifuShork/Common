﻿namespace WaifuShork.Common.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    using Microsoft.Toolkit.Diagnostics;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		/// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>A sequence that contains the specified number of elements from the start of the input sequence.</returns>
        public static T[] TakeQ<T>(this T[] source, int count)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > source.Length)
            {
                count = source.Length;
            }

            var result = new T[count];
            Array.Copy(source, 0, result, 0, count);
            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>        
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains the elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static T[] TakeWhileQ<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var count = 0;
            for (; count < source.Length; count++)
            {
                if (!predicate(source[count]))
                {
                    break;
                }                
            }
            var result = new T[count];
            Array.Copy(source, 0, result, 0, count);
            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence that contains elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static T[] TakeWhileQ<T>(this T[] source, Func<T,int, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var count = 0;
            for (; count < source.Length; count++)
            {
                if (!predicate(source[count], count))
                {
                    break;
                }                
            }
            var result = new T[count];
            Array.Copy(source, 0, result, 0, count);
            return result;
        }

        /*---- spans ---- */
        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>A sequence that contains the specified number of elements from the start of the input sequence.</returns>
        public static T[] TakeQ<T>(this Span<T> source, int count)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > source.Length)
            {
                count = source.Length;
            }

            var result = new T[count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = source[i];
            }       
            
            return result;
        }


        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>        
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains the elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static T[] TakeWhileQ<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var count = 0;
            for (; count < source.Length; count++)
            {
                if (!predicate(source[count]))
                {
                    break;
                }
            }
            var result = new T[count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = source[i];
            }
            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence that contains elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static T[] TakeWhileQ<T>(this Span<T> source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var count = 0;
            for (; count < source.Length; count++)
            {
                if (!predicate(source[count], count))
                {
                    break;
                }
            }
            var result = new T[count];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = source[i];
            }
            return result;
        }


        // ------------- Lists ----------------

        /// <summary>
        /// Returns a specified number of contiguous elements from the start of a sequence.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="count">The number of elements to return.</param>
        /// <returns>A sequence that contains the specified number of elements from the start of the input sequence.</returns>
        public static List<T> TakeQ<T>(this List<T> source, int count)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (count < 0)
            {
                count = 0;
            }
            else if (count > source.Count)
            {
                count = source.Count;
            }

            var result = new List<T>(count);
            for (var i = 0; i < count; i++)
            {
                result.Add(source[i]);
            }
            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true.
        /// </summary>        
        /// <param name="source">A sequence to return elements from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A sequence that contains the elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static List<T> TakeWhileQ<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var result = new List<T>();
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    result.Add(source[i]);
                }
                else
                {
                    return result;
                }
            }

            return result;
        }

        /// <summary>
        /// Returns elements from a sequence as long as a specified condition is true. The element's index is used in the logic of the predicate function.
        /// </summary>        
        /// <param name="source">The sequence to return elements from.</param>
        /// <param name="predicate">A function to test each source element for a condition; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence that contains elements from the input sequence that occur before the element at which the test no longer passes.</returns>
        public static List<T> TakeWhileQ<T>(this List<T> source, Func<T, int, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (predicate == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(predicate));
            }

            var result = new List<T>();
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i], i))
                {
                    result.Add(source[i]);
                }
                else
                {
                    return result;
                }
            }
            return result;
        }
	}
}