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
        ///  Adds the values in the sequence that match the where predicate.
        /// </summary>
        /// <param name="source">The sequence to add.</param>
        /// <param name="predicate">A function to filter the sequence with before summing.</param>
        /// <returns>The sum of the sequence.</returns>
        public static int WhereSumF(this int[] source, Func<int,bool> predicate)
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
        public static int WhereSumF<T>(this T[] source,Func<T,bool> predicate, Func<T, int> selector)
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
        public static long WhereSumF(this long[] source,Func<long,bool> predicate)
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
        public static long WhereSumF<T>(this T[] source,Func<T,bool> predicate, Func<T, long> selector)
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
        public static float WhereSumF(this float[] source, Func<float,bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static float WhereSumF<T>(this T[] source, Func<T,bool> predicate,Func<T, float> selector)
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
        public static double WhereSumF(this double[] source, Func<double,bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static double WhereSumF<T>(this T[] source, Func<T,bool> predicate,Func<T, double> selector)
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
        public static decimal WhereSumF(this decimal[] source, Func<decimal,bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static decimal WhereSumF<T>(this T[] source,Func<T,bool> predicate, Func<T, decimal> selector)
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
        public static int WhereSumF(this Span<int> source, Func<int, bool> predicate)
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
        public static int WhereSumF<T>(this Span<T> source, Func<T, bool> predicate, Func<T, int> selector)
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
        public static long WhereSumF(this Span<long> source, Func<long, bool> predicate)
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
        public static long WhereSumF<T>(this Span<T> source, Func<T, bool> predicate, Func<T, long> selector)
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
        public static float WhereSumF(this Span<float> source, Func<float, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static float WhereSumF<T>(this Span<T> source, Func<T, bool> predicate, Func<T, float> selector)
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
        public static double WhereSumF(this Span<double> source, Func<double, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static double WhereSumF<T>(this Span<T> source, Func<T, bool> predicate, Func<T, double> selector)
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
        public static decimal WhereSumF(this Span<decimal> source, Func<decimal, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static decimal WhereSumF<T>(this Span<T> source, Func<T, bool> predicate, Func<T, decimal> selector)
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
        public static int WhereSumF(this List<int> source, Func<int,bool> predicate)
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
        public static int WhereSumF<T>(this List<T> source, Func<T,bool> predicate, Func<T, int> selector)
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
        public static long WhereSumF(this List<long> source, Func<long,bool> predicate)
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
        public static long WhereSumF<T>(this List<T> source, Func<T,bool> predicate, Func<T, long> selector)
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
        public static float WhereSumF(this List<float> source, Func<float,bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static float WhereSumF<T>(this List<T> source, Func<T,bool> predicate,Func<T, float> selector)
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
        public static double WhereSumF(this List<double> source, Func<double,bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static double WhereSumF<T>(this List<T> source,Func<T,bool> predicate, Func<T, double> selector)
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
        public static decimal WhereSumF(this List<decimal> source, Func<decimal,bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
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
        public static decimal WhereSumF<T>(this List<T> source, Func<T,bool> predicate,Func<T, decimal> selector)
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
                if (predicate(source[i]))
                {
                    sum += selector(source[i]);
                }
            }

            return sum;
        }
	}
}