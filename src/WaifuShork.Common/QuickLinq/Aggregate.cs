namespace WaifuShork.Common.QuickLinq
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Toolkit.Diagnostics;
    
    // ReSharper disable LoopCanBeConvertedToQuery
    // ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// ------------------------------ Arrays --------------------------

        /// <summary>
        /// Applies an accumulator function over an array.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TSource AggregateQ<TSource>(this TSource[] source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var result = source[0];
            for (var i = 1; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }
            
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over an array. The specified seed
        /// value is used as the initial accumulator value.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TAccumulate AggregateQ<TSource, TAccumulate>(this TSource[] source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            var result = seed;
            for (var i = 0; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }

            return result;
        }

        /// <summary>
        /// Applies an accumulator function over an array. The specified seed
        /// value is used as the initial accumulator value, and the specified 
        /// function is used to select the result value.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
        /// <returns>The transformed final accumulator value</returns>
        public static TResult AggregateQ<TSource, TAccumulate, TResult>(this TSource[] source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            if (resultSelector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(resultSelector));
            }

            var result = seed;
            for (var i = 0; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }

            return resultSelector(result);
        }

        // ------------------------------ this Spans --------------------------

        /// <summary>
        /// Applies an accumulator function over an array.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TSource AggregateQ<TSource>(this Span<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            if (source.Length == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var result = source[0];
            for (var i = 1; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over an array. The specified seed
        /// value is used as the initial accumulator value.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TAccumulate AggregateQ<TSource, TAccumulate>(this Span<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            var result = seed;
            for (var i = 0; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }

            return result;
        }

        /// <summary>
        /// Applies an accumulator function over an array. The specified seed
        /// value is used as the initial accumulator value, and the specified 
        /// function is used to select the result value.
        /// </summary>        
        /// <param name="source">An array to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
        /// <returns>The transformed final accumulator value</returns>
        public static TResult AggregateQ<TSource, TAccumulate, TResult>(this Span<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            if (resultSelector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(resultSelector));
            }

            var result = seed;
            for (var i = 0; i < source.Length; i++)
            {
                result = func(result, source[i]);
            }

            return resultSelector(result);
        }

        // ------------------------------ Lists --------------------------

        /// <summary>
        /// Applies an accumulator function over a List.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source">A List to aggregate over.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TSource AggregateQ<TSource>(this List<TSource> source, Func<TSource, TSource, TSource> func)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            if (source.Count == 0)
            {
                ThrowHelper.ThrowInvalidOperationException("Sequence contains no elements.");
            }

            var result = source[0];
            for (var i = 1; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over a List. The specified seed
        /// value is used as the initial accumulator value.
        /// </summary>        
        /// <param name="source">A List to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <returns>The final accumulator value</returns>
        public static TAccumulate AggregateQ<TSource, TAccumulate>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            var result = seed;
            for (var i = 0; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return result;
        }

        /// <summary>
        /// Applies an accumulator function over a List. The specified seed
        /// value is used as the initial accumulator value, and the specified 
        /// function is used to select the result value.
        /// </summary>        
        /// <param name="source">A List to aggregate over.</param>
        /// <param name="seed">The initial accumulator value.</param>
        /// <param name="func">An accumulator function to be invoked on each element</param>
        /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
        /// <returns>The transformed final accumulator value</returns>
        public static TResult AggregateQ<TSource, TAccumulate, TResult>(this List<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (func == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(func));
            }

            if (resultSelector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(resultSelector));
            }

            var result = seed;
            for (var i = 0; i < source.Count; i++)
            {
                result = func(result, source[i]);
            }
            return resultSelector(result);
        }
    }
}