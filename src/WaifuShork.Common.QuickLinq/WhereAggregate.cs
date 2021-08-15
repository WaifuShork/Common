﻿namespace Wyvern.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// ----------------------------- Arrays ------------------

        /// <summary>
        /// Combines Where and Aggregate for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static T WhereAggregateF<T>(this T[] source, Func<T, bool> predicate, Func<T, T, T> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }
            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            var result = default(T);

            var i = 0;
            for (; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result = source[i];
                    i++;
                    break;
                }
            }
            for (; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result = func(result, source[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate with index for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence and it's index with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static T WhereAggregateF<T>(this T[] source, Func<T, int, bool> predicate, Func<T, T,T> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = default(T);

            var i = 0;
            for (; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result = source[i];
                    i++;
                    break;
                }
            }            
            for (; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result = func(result, source[i]);                    
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TAccumulate WhereAggregateF<TSource, TAccumulate>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = seed;
            foreach (var v in source)
            {
                if (predicate(v))
                {
                    result = func(result, v);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed and a result transformation.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="resultSelector">A function to transform the final result.</param>
        /// <returns>The filtered then aggregated then transformed sequence.</returns>
        public static TResult WhereAggregateF<TSource, TAccumulate, TResult>(this TSource[] source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (resultSelector == null)
            {
                throw Error.ArgumentNull("resultSelector");
            }

            var result = seed;
            // var count = 0;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result = func(result, source[i]);
                    // count++;
                }
            }

            return resultSelector(result);
        }

        // ----------------------------- Spans ------------------

        /// <summary>
        /// Combines Where and Aggregate for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static T WhereAggregateF<T>(this Span<T> source, Func<T, bool> predicate, Func<T, T, T> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }
            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            var result = default(T);

            var i = 0;
            for (; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result = source[i];
                    i++;
                    break;
                }
            }
            for (; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    result = func(result, source[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate with index for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence and it's index with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static T WhereAggregateF<T>(this Span<T> source, Func<T, int, bool> predicate, Func<T, T, T> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = default(T);

            var i = 0;
            for (; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result = source[i];
                    i++;
                    break;
                }
            }
            for (; i < source.Length; i++)
            {
                if (predicate(source[i], i))
                {
                    result = func(result, source[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TAccumulate WhereAggregateF<TSource, TAccumulate>(this Span<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = seed;
            foreach (var v in source)
            {
                if (predicate(v))
                {
                    result = func(result, v);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed and a result transformation.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="resultSelector">A function to transform the final result.</param>
        /// <returns>The filtered then aggregated then transformed sequence.</returns>
        public static TResult WhereAggregateF<TSource, TAccumulate, TResult>(this Span<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (resultSelector == null)
            {
                throw Error.ArgumentNull("resultSelector");
            }

            var result = seed;
            // var count = 0;
            foreach (var v in source)
            {
                if (predicate(v))
                {
                    result = func(result, v);
                    // count++;
                }
            }
            return resultSelector(result);
        }


        // --------------------------- Lists -------------------------

        /// <summary>
        /// Combines Where and Aggregate for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static T WhereAggregateF<T>(this List<T> source, Func<T, bool> predicate, Func<T, T, T> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            var result = default(T);

            var i = 0;
            for (; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    result = source[i];
                    i++;
                    break;
                }
            }
            for (; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    result = func(result, source[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate with index for optimal performance
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence and it's index with.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static T WhereAggregateF<T>(this List<T> source, Func<T, int, bool> predicate, Func<T, T, T> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = default(T);

            var i = 0;
            for (; i < source.Count; i++)
            {
                if (predicate(source[i], i))
                {
                    result = source[i];
                    i++;
                    break;
                }
            }            
            for (; i < source.Count; i++)
            {
                if (predicate(source[i], i))
                {
                    result = func(result, source[i]);                    
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <returns>The filtered then aggregated sequence.</returns>
        public static TAccumulate WhereAggregateF<TSource, TAccumulate>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var result = seed;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    result = func(result, source[i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Combines Where and Aggregate for optimal performance with a starting seed and a result transformation.
        /// </summary>        
        /// <param name="source">The input to filter then aggregate.</param>
        /// <param name="predicate">The function to filter the input sequence with.</param>
        /// <param name="seed">The initial value to aggregate on.</param>
        /// <param name="func">The function to aggregate the filtered sequence.</param>
        /// <param name="resultSelector">A function to transform the final result.</param>
        /// <returns>The filtered then aggregated then transformed sequence.</returns>
        public static TResult WhereAggregateF<TSource, TAccumulate, TResult>(this List<TSource> source, Func<TSource, bool> predicate, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, Func<TAccumulate, TResult> resultSelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (func == null)
            {
                throw Error.ArgumentNull("func");
            }

            if (resultSelector == null)
            {
                throw Error.ArgumentNull("resultSelector");
            }

            var result = seed;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    result = func(result, source[i]);
                }
            }
            return resultSelector(result);
        }
	}
}