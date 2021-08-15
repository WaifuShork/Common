namespace Wyvern.QuickLinq
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
        public static T MaxF<T>(this T[] source)
        {            
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static TResult MaxF<T, TResult>(this T[] source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static int MaxF(this int[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static int MaxF<T>(this T[] source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static long MaxF(this long[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static long MaxF<T>(this T[] source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static float MaxF(this float[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static float MaxF<T>(this T[] source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static double MaxF(this double[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static double MaxF<T>(this T[] source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static decimal MaxF(this decimal[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static decimal MaxF<T>(this T[] source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static T MaxF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static TResult MaxF<T, TResult>(this Span<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static int MaxF(this Span<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static int MaxF<T>(this Span<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static long MaxF(this Span<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static long MaxF<T>(this Span<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static float MaxF(this Span<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static float MaxF<T>(this Span<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static double MaxF(this Span<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static double MaxF<T>(this Span<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static decimal MaxF(this Span<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
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
        public static decimal MaxF<T>(this Span<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static T MaxF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static TResult MaxF<T, TResult>(this List<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
            }

            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static int MaxF(this List<int> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static int MaxF<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static long MaxF(this List<long> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static long MaxF<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("source");
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
        public static float MaxF(this List<float> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static float MaxF<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static double MaxF(this List<double> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static double MaxF<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            if (selector == null)
            {
                throw Error.ArgumentNull("selector");
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
        public static decimal MaxF(this List<decimal> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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
        public static decimal MaxF<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
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