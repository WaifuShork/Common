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
        /// Returns the minimum value in a sequence of values.
        /// </summary>        
        /// <param name="source">A sequence of values to determine the minimum of.</param>
        /// <returns>The minimum value in the sequence</returns>
        public static T MinF<T>(this T[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static TResult MinF<T, TResult>(this T[] source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static int MinF(this int[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static int MinF<T>(this T[] source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static long MinF(this long[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static long MinF<T>(this T[] source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static float MinF(this float[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static float MinF<T>(this T[] source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static double MinF(this double[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static double MinF<T>(this T[] source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static decimal MinF(this decimal[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static decimal MinF<T>(this T[] source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static T MinF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static TResult MinF<T, TResult>(this Span<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static int MinF(this Span<int> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static int MinF<T>(this Span<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static long MinF(this Span<long> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static long MinF<T>(this Span<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static float MinF(this Span<float> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static float MinF<T>(this Span<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static double MinF(this Span<double> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static double MinF<T>(this Span<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static decimal MinF(this Span<decimal> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static decimal MinF<T>(this Span<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static T MinF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static int MinF(this List<int>source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static int MinF<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static long MinF(this List<long> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static long MinF<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static float MinF(this List<float> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static float MinF<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static double MinF(this List<double> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static double MinF<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
            }
            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
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
        public static decimal MinF(this List<decimal> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static decimal MinF<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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
        public static TResult MinF<T, TResult>(this List<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
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