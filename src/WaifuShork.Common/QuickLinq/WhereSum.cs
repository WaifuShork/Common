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
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int WhereSumQ(this int[] source, Func<int,bool> predicate)
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
                    if (predicate(source[i]))
                    {
                        sum += source[i];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int WhereSumQ<T>(this T[] source,Func<T,bool> predicate, Func<T, int> selector)
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
                    if (predicate(source[i]))
                    {
                        sum += selector(source[i]);
                    }
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long WhereSumQ(this long[] source,Func<long,bool> predicate)
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
                    if (predicate(source[i]))
                    {
                        sum += source[i];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long WhereSumQ<T>(this T[] source,Func<T,bool> predicate, Func<T, long> selector)
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
                    if (predicate(source[i]))
                    {
                        sum += selector(source[i]);
                    }
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float WhereSumQ(this float[] source, Func<float,bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return (float)sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>        
        /// <returns>The sum of the transformed elements.</returns>
        public static float WhereSumQ<T>(this T[] source, Func<T,bool> predicate,Func<T, float> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return (float)sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double WhereSumQ(this double[] source, Func<double,bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double WhereSumQ<T>(this T[] source, Func<T,bool> predicate,Func<T, double> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal WhereSumQ(this decimal[] source, Func<decimal,bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            
            decimal sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal WhereSumQ<T>(this T[] source,Func<T,bool> predicate, Func<T, decimal> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }

        // --------------------------  SPANS  --------------------------------------------

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int WhereSumQ(this Span<int> source, Func<int, bool> predicate)
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
                    if (predicate(source[i]))
                    {
                        sum += source[i];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int WhereSumQ<T>(this Span<T> source, Func<T, bool> predicate, Func<T, int> selector)
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
                    if (predicate(source[i]))
                    {
                        sum += selector(source[i]);
                    }
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long WhereSumQ(this Span<long> source, Func<long, bool> predicate)
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
                    if (predicate(source[i]))
                    {
                        sum += source[i];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long WhereSumQ<T>(this Span<T> source, Func<T, bool> predicate, Func<T, long> selector)
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
                    if (predicate(source[i]))
                    {
                        sum += selector(source[i]);
                    }
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float WhereSumQ(this Span<float> source, Func<float, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return (float)sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>        
        /// <returns>The sum of the transformed elements.</returns>
        public static float WhereSumQ<T>(this Span<T> source, Func<T, bool> predicate, Func<T, float> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return (float)sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double WhereSumQ(this Span<double> source, Func<double, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            double sum = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double WhereSumQ<T>(this Span<T> source, Func<T, bool> predicate, Func<T, double> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal WhereSumQ(this Span<decimal> source, Func<decimal, bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal WhereSumQ<T>(this Span<T> source, Func<T, bool> predicate, Func<T, decimal> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }

        // --------------------------  LISTS  --------------------------------------------

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int WhereSumQ(this List<int> source, Func<int,bool> predicate)
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
                    if (predicate(source[i]))
                    {
                        sum += source[i];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static int WhereSumQ<T>(this List<T> source, Func<T,bool> predicate, Func<T, int> selector)
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
                    if (predicate(source[i]))
                    {
                        sum += selector(source[i]);
                    }
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static long WhereSumQ(this List<long> source, Func<long,bool> predicate)
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
                    if (predicate(source[i]))
                    {
                        sum += source[i];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static long WhereSumQ<T>(this List<T> source, Func<T,bool> predicate, Func<T, long> selector)
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
                    if (predicate(source[i]))
                    {
                        sum += selector(source[i]);
                    }
                }
            }
            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static float WhereSumQ(this List<float> source, Func<float,bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            double sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return (float)sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static float WhereSumQ<T>(this List<T> source, Func<T,bool> predicate,Func<T, float> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return (float)sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static double WhereSumQ(this List<double> source, Func<double,bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            double sum = 0;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static double WhereSumQ<T>(this List<T> source,Func<T,bool> predicate, Func<T, double> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }

        /// <summary>
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static decimal WhereSumQ(this List<decimal> source, Func<decimal,bool> predicate)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }
            decimal sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    sum += source[i];
                }
            }

            return sum;
        }

        /// <summary>
        /// Performs a filter with the where predicate, then sums the transformed values.
        /// </summary>        
        /// <param name="source">The sequence of values to transform then sum.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <param name="selector">A transformation function.</param>
        /// <returns>The sum of the transformed elements.</returns>
        public static decimal WhereSumQ<T>(this List<T> source, Func<T,bool> predicate,Func<T, decimal> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }
	}
}