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
		// --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static T MaxQ<T>(this T[] source)
        {            
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var comparer = Comparer<T>.Default;
            var r = default(T);
            if (r == null)
            {
                r = source[0];
                for (var i = 1; i < source.Length; i++)
                {
                    if (source[i] != null && comparer.Compare(source[i], r) > 0)
                    {
                        r = source[i];
                    }
                }
            }
            else
            {
                r = source[0];
                for (var i = 1; i < source.Length; i++)
                {
                    if (comparer.Compare(source[i], r) > 0)
                    {
                        r = source[i];
                    }
                }
            }
            return r;
        }
       
        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static TResult MaxQ<T, TResult>(this T[] source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var comparer = Comparer<TResult>.Default;
            var r = default(TResult);
            if (r == null)
            {
                r = selector(source[0]);
                for (var i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (v != null && comparer.Compare(v, r) > 0)
                    {
                        r = v;
                    }
                }
            }
            else
            {
                r = selector(source[0]);                
                for (var i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (comparer.Compare(v, r) > 0)
                    {
                        r = v;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static int MaxQ(this int[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = int.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static int MaxQ<T>(this T[] source, Func<T, int> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = int.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static long MaxQ(this long[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            var r = long.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }


        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static long MaxQ<T>(this T[] source, Func<T, long> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = long.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static float MaxQ(this float[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            var r = source[0];
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (!float.IsNaN(source[startIndex]))
                {
                    r = source[startIndex];
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static float MaxQ<T>(this T[] source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = selector(source[0]);
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                var v = selector(source[startIndex]);
                if (!float.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static double MaxQ(this double[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = source[0];
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (!double.IsNaN(source[startIndex]))
                {
                    r = source[startIndex];
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static double MaxQ<T>(this T[] source, Func<T, double> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = selector(source[0]);
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                var v = selector(source[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }


        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static decimal MaxQ(this decimal[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static decimal MaxQ<T>(this T[] source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }
            var r = decimal.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        // --------------------------  this Spans  --------------------------------------------

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static T MaxQ<T>(this Span<T> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var comparer = Comparer<T>.Default;
            var r = default(T);
            if (r == null)
            {
                r = source[0];
                for (var i = 1; i < source.Length; i++)
                {
                    if (source[i] != null && comparer.Compare(source[i], r) > 0)
                    {
                        r = source[i];
                    }
                }
            }
            else
            {
                r = source[0];
                for (var i = 1; i < source.Length; i++)
                {
                    if (comparer.Compare(source[i], r) > 0)
                    {
                        r = source[i];
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static TResult MaxQ<T, TResult>(this Span<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var comparer = Comparer<TResult>.Default;
            var r = default(TResult);
            if (r == null)
            {
                r = selector(source[0]);
                for (var i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (v != null && comparer.Compare(v, r) > 0)
                    {
                        r = v;
                    }
                }
            }
            else
            {
                r = selector(source[0]);
                for (var i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (comparer.Compare(v, r) > 0)
                    {
                        r = v;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static int MaxQ(this Span<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = int.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static int MaxQ<T>(this Span<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = int.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static long MaxQ(this Span<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = long.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }


        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static long MaxQ<T>(this Span<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = long.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static float MaxQ(this Span<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            var r = source[0];
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (!float.IsNaN(source[startIndex]))
                {
                    r = source[startIndex];
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static float MaxQ<T>(this Span<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = selector(source[0]);
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                var v = selector(source[startIndex]);
                if (!float.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static double MaxQ(this Span<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = source[0];
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                if (!double.IsNaN(source[startIndex]))
                {
                    r = source[startIndex];
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static double MaxQ<T>(this Span<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = selector(source[0]);
            var startIndex = 0;
            for (; startIndex < source.Length; startIndex++)
            {
                var v = selector(source[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (var i = startIndex; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }


        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static decimal MaxQ(this Span<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static decimal MaxQ<T>(this Span<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }
            var r = decimal.MinValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static T MaxQ<T>(this List<T> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var comparer = Comparer<T>.Default;
            var r = default(T);
            if (r == null)
            {
                r = source[0];
                for (var i = 1; i < source.Count; i++)
                {
                    if (source[i] != null && comparer.Compare(source[i], r) > 0)
                    {
                        r = source[i];
                    }
                }
            }
            else
            {
                r = source[0];
                for (var i = 1; i < source.Count; i++)
                {
                    if (comparer.Compare(source[i], r) > 0)
                    {
                        r = source[i];
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static TResult MaxQ<T, TResult>(this List<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var comparer = Comparer<TResult>.Default;
            var r = default(TResult);
            if (r == null)
            {
                r = selector(source[0]);
                for (var i = 1; i < source.Count; i++)
                {
                    var v = selector(source[i]);
                    if (v != null && comparer.Compare(v, r) > 0)
                    {
                        r = v;
                    }
                }
            }
            else
            {
                r = selector(source[0]);
                for (var i = 1; i < source.Count; i++)
                {
                    var v = selector(source[i]);
                    if (comparer.Compare(v, r) > 0)
                    {
                        r = v;
                    }
                }
            }
            return r;
        }


        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static int MaxQ(this List<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = int.MinValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static int MaxQ<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = int.MinValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static long MaxQ(this List<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = long.MinValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static long MaxQ<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            var r = long.MinValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static float MaxQ(this List<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = source[0];
            var startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                if (!float.IsNaN(source[startIndex]))
                {
                    r = source[startIndex];
                    break;
                }
            }
            for (var i = startIndex; i < source.Count; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static float MaxQ<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }
            var r = selector(source[0]);
            var startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                var v = selector(source[startIndex]);
                if (!float.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (var i = startIndex; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static double MaxQ(this List<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = source[0];
            var startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                if (!double.IsNaN(source[startIndex]))
                {
                    r = source[startIndex];
                    break;
                }
            }
            for (var i = startIndex; i < source.Count; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static double MaxQ<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }
            var r = selector(source[0]);
            var startIndex = 0;
            for (; startIndex < source.Count; startIndex++)
            {
                var v = selector(source[startIndex]);
                if (!double.IsNaN(v))
                {
                    r = v;
                    break;
                }
            }
            for (var i = startIndex; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the maximum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum of.</param>
        /// <returns>The maximum value in the sequence</returns>
        public static decimal MaxQ(this List<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MinValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] > r)
                {
                    r = source[i];
                }
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static decimal MaxQ<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MinValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v > r)
                {
                    r = v;
                }
            }
            return r;
        }
	}
}