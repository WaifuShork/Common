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
        /// Computes the average of an array
        /// </summary>
        /// <param(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ(this int[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this T[] source, Func<T, int> selector)
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

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            
            return (double) sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ(this long[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Length;
        }


        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this T[] source, Func<T, long> selector)
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

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageQ(this float[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageQ<T>(this T[] source, Func<T, float> selector)
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

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ(this double[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this T[] source, Func<T, double> selector)
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

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageQ(this decimal[] source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageQ<T>(this T[] source, Func<T, decimal> selector)
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


            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Length;
        }

        // --------------------------  this SpanS  --------------------------------------------

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ(this Span<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this Span<T> source, Func<T, int> selector)
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

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ(this Span<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Length;
        }


        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this Span<T> source, Func<T, long> selector)
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

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Length; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageQ(this Span<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageQ<T>(this Span<T> source, Func<T, float> selector)
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

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return (float)(sum / source.Length);
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ(this Span<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this Span<T> source, Func<T, double> selector)
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

            double sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of an array
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the average of.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageQ(this Span<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += source[i];
            }

            return sum / source.Length;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageQ<T>(this Span<T> source, Func<T, decimal> selector)
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
            
            decimal sum = 0;

            for (var i = 0; i < source.Length; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Length;
        }

        // --------------------------  Lists  --------------------------------------------

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name=nameof(source)>The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static double AverageQ(this List<int> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this List<T> source, Func<T, int> selector)
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

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name=nameof(source)>The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static double AverageQ(this List<long> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += source[i];
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this List<T> source, Func<T, long> selector)
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

            long sum = 0;
            checked
            {
                for (var i = 0; i < source.Count; i++)
                {
                    sum += selector(source[i]);
                }
            }
            return (double)sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name=nameof(source)>The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static float AverageQ(this List<float> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            double sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return (float)(sum / source.Count);
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static float AverageQ<T>(this List<T> source, Func<T, float> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            double sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return (float)(sum / source.Count);
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name=nameof(source)>The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static double AverageQ(this List<double> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }
            
            double sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static double AverageQ<T>(this List<T> source, Func<T, double> selector)
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
            double sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of a list.
        /// </summary>
        /// <param name=nameof(source)>The list to calculate the average of.</param>
        /// <returns>The average of the list.</returns>
        public static decimal AverageQ(this List<decimal> source)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            decimal sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += source[i];
            }

            return sum / source.Count;
        }

        /// <summary>
        /// Computes the average of values obtained by invoking a transform function on
        /// each element of the input array.
        /// </summary>
        /// <param name=nameof(source)>The array to calculate the transformed average of.</param>
        /// <param name=nameof(selector)>A transform function to apply to each element.</param>
        /// <returns>The average of the array.</returns>
        public static decimal AverageQ<T>(this List<T> source, Func<T, decimal> selector)
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

            decimal sum = 0;

            for (var i = 0; i < source.Count; i++)
            {
                sum += selector(source[i]);
            }

            return sum / source.Count;
        }
	}
}