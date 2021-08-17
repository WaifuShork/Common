using System.Linq;
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
        ///  Adds a sequence of values.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int SumQ(this int[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static int SumQ<T>(this T[] source, Func<T, int> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static long SumQ(this long[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static long SumQ<T>(this T[] source, Func<T, long> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static float SumQ(this float[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static float SumQ<T>(this T[] source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static double SumQ(this double[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static double SumQ<T>(this T[] source, Func<T, double> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static decimal SumQ(this decimal[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static decimal SumQ<T>(this T[] source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static int SumQ(this Span<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static int SumQ<T>(this Span<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static long SumQ(this Span<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static long SumQ<T>(this Span<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static float SumQ(this Span<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static float SumQ<T>(this Span<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static double SumQ(this Span<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static double SumQ<T>(this Span<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static decimal SumQ(this Span<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static decimal SumQ<T>(this Span<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static int SumQ(this List<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static int SumQ<T>(this List<T> source, Func<T, int> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static long SumQ(this List<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static long SumQ<T>(this List<T> source, Func<T, long> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static float SumQ(this List<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static float SumQ<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static double SumQ(this List<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static double SumQ<T>(this List<T> source, Func<T, double> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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
        public static decimal SumQ(this List<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
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
        public static decimal SumQ<T>(this List<T> source, Func<T, decimal> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
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