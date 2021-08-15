﻿namespace WaifuShork.Common.QuickLinq
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
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int SumF(this int[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            
            var sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int SumF<T>(this T[] source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            var sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long SumF(this long[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long SumF<T>(this T[] source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float SumF(this float[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return (float)sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static float SumF<T>(this T[] source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return (float)sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double SumF(this double[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double SumF<T>(this T[] source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal SumF(this decimal[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal SumF<T>(this T[] source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            decimal sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum;
        }

        /*---- Spans ---*/
        
        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int SumF(this Span<int> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            var sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int SumF<T>(this Span<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            var sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long SumF(this Span<long> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long SumF<T>(this Span<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float SumF(this Span<float> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum +=  source[i];
            }

            return (float)sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static float SumF<T>(this Span<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return (float)sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double SumF(this Span<double> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double SumF<T>(this Span<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal SumF(this Span<decimal> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal SumF<T>(this Span<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            decimal sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum;
        }

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int SumF(this List<int> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            var sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += source[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int SumF<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            var sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long SumF(this List<long> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += source[i];
                }
            }
            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long SumF<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float SumF(this List<float> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            double sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return (float)sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static float SumF<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            double sum = 0;
            for (var i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return (float)sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double SumF(this List<double> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            double sum = 0;
            for (var i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double SumF<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            double sum = 0;
            for (var i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum;
        }

        /// <summary>
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal SumF(this List<decimal> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            decimal sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return sum;
        }

        /// <summary>
        /// Adds the transformed sequence of elements.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal SumF<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (selector == null)
            {
                throw ThrowHelper.ArgumentNull("selector");
            }

            decimal sum = 0;
            for (var i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum;
        }
    }
}