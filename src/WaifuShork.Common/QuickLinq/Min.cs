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
		// --------------------------  ARRAYS  --------------------------------------------

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinQ<T>(this T[] source)
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
                    if (source[i] != null && comparer.Compare(source[i], r) < 0)
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
                    if (comparer.Compare(source[i], r) < 0)
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
        public static TResult MinQ<T, TResult>(this T[] source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
                    if (v != null && comparer.Compare(v, r) < 0)
                    {
                        r = v;
                    }
                }
            }
            else
            {
                r = selector(source[0]);
                for (int i = 1; i < source.Length; i++)
                {
                    var v = selector(source[i]);
                    if (comparer.Compare(v, r) < 0) r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinQ(this int[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = int.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
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
        public static int MinQ<T>(this T[] source, Func<T, int> selector)
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

            var r = int.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinQ(this long[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = long.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
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
        public static long MinQ<T>(this T[] source, Func<T, long> selector)
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

            var r = long.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinQ(this float[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = float.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
                }
                else if (float.IsNaN(source[i]))
                {
                    return source[i];
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
        public static float MinQ<T>(this T[] source, Func<T, float> selector)
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
            var r = float.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
                else if (float.IsNaN(v))
                {
                    return v;
                }

            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinQ(this double[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = double.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
                }
                else if (double.IsNaN(source[i]))
                {
                    return source[i];
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
        public static double MinQ<T>(this T[] source, Func<T, double> selector)
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
            var r = double.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
                else if (double.IsNaN(v))
                {
                    return v;
                }

            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinQ(this decimal[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
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
        public static decimal MinQ<T>(this T[] source, Func<T, decimal> selector)
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
            var r = decimal.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }
        // --------------------------  this Spans  --------------------------------------------

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinQ<T>(this Span<T> source)
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
                    if (source[i] != null && comparer.Compare(source[i], r) < 0)
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
                    if (comparer.Compare(source[i], r) < 0)
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
        public static TResult MinQ<T, TResult>(this Span<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
                    if (v != null && comparer.Compare(v, r) < 0)
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
                    if (comparer.Compare(v, r) < 0)
                    {
                        r = v;
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinQ(this Span<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = int.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
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
        public static int MinQ<T>(this Span<T> source, Func<T, int> selector)
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

            var r = int.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinQ(this Span<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = long.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
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
        public static long MinQ<T>(this Span<T> source, Func<T, long> selector)
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

            var r = long.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinQ(this Span<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = float.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
                }
                else if (float.IsNaN(source[i]))
                {
                    return source[i];
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
        public static float MinQ<T>(this Span<T> source, Func<T, float> selector)
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
            var r = float.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
                else if (float.IsNaN(v))
                {
                    return v;
                }

            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinQ(this Span<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = double.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
                }
                else if (double.IsNaN(source[i]))
                {
                    return source[i];
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
        public static double MinQ<T>(this Span<T> source, Func<T, double> selector)
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
            var r = double.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
                else if (double.IsNaN(v))
                { 
                    return v;
                }

            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinQ(this Span<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                if (source[i] < r)
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
        public static decimal MinQ<T>(this Span<T> source, Func<T, decimal> selector)
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
            var r = decimal.MaxValue;
            for (var i = 0; i < source.Length; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinQ<T>(this List<T> source)
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
                    if (source[i] != null && comparer.Compare(source[i], r) < 0)
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
                    if (comparer.Compare(source[i], r) < 0)
                    {
                        r = source[i];
                    }
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static int MinQ(this List<int>source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = int.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] < r)
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
        public static int MinQ<T>(this List<T> source, Func<T, int> selector)
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

            var r = int.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static long MinQ(this List<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = long.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] < r) r = source[i];
            }
            return r;
        }

        /// <summary>
        /// Invokes a transform function on each element of a sequence and returns the maximum value.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the maximum value of.</param>
        /// <param name="selector">A transform function to apply to each element.</param>
        /// <returns>The maximum value in the transform of the sequence.</returns>
        public static long MinQ<T>(this List<T> source, Func<T, long> selector)
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
            var r = long.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static float MinQ(this List<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = float.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
                }
                else if (float.IsNaN(source[i]))
                {
                    return source[i];
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
        public static float MinQ<T>(this List<T> source, Func<T, float> selector)
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

            var r = float.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r) r = v;
                else if (float.IsNaN(v))
                {
                    return v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static double MinQ(this List<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = double.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] < r)
                {
                    r = source[i];
                }
                else if (double.IsNaN(source[i]))
                {
                    return source[i];
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
        public static double MinQ<T>(this List<T> source, Func<T, double> selector)
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

            var r = double.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
                }
                else if (double.IsNaN(v))
                {
                    return v;
                }
            }
            return r;
        }

        /// <summary>
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static decimal MinQ(this List<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                if (source[i] < r)
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
        public static decimal MinQ<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            var r = decimal.MaxValue;
            for (var i = 0; i < source.Count; i++)
            {
                var v = selector(source[i]);
                if (v < r)
                {
                    r = v;
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
        public static TResult MinQ<T, TResult>(this List<T> source, Func<T, TResult> selector)
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
                    if (v != null && comparer.Compare(v, r) < 0)
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
                    if (comparer.Compare(v, r) < 0)
                    {
                        r = v;
                    }
                }
            }
            return r;
        }
	}
}