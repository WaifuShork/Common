﻿namespace WaifuShork.Common.QuickLinq
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
        ///  Projects each element of a sequence into a new form in place.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>        
        public static void SelectInPlaceQ<T>(this T[] source, Func<T,T> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            for (int i = 0; i < source.Length; i++)
            {
                source[i] = selector(source[i]);
            }
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form, in place, by incorporating the element's index.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>        
        public static void SelectInPlaceQ<T>(this T[] source, Func<T, int, T> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            for (var i = 0; i < source.Length; i++)
            {
                source[i] = selector(source[i], i);
            }
        }


        /// <summary>
        ///  Projects each element of a sequence into a new form. (map in every other language)
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
        public static TResult[] SelectQ<T, TResult>(this T[] source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                r[i] = selector(source[i]);
            }
            return r;
        }

     
     
        /// <summary>
        ///  Projects each element of a sequence into a new form by incorporating the element's index.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element of source.</returns>
        public static TResult[] SelectQ<T, TResult>(this T[] source, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }
            var r = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                r[i] = selector(source[i], i);
            }
            return r;
        }

        // --------------------------  this SpanS  --------------------------------------------

        /// <summary>
        ///  Projects each element of a sequence into a new form in place.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>        
        public static void SelectInPlaceQ<T>(this Span<T> source, Func<T, T> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            for (var i = 0; i < source.Length; i++)
            {
                source[i] = selector(source[i]);
            }
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form, in place, by incorporating the element's index.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>        
        public static void SelectInPlaceQ<T>(this Span<T> source, Func<T, int, T> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            for (var i = 0; i < source.Length; i++)
            {
                source[i] = selector(source[i], i);
            }
        }


        /// <summary>
        ///  Projects each element of a sequence into a new form. (map in every other language)
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
        public static TResult[] SelectQ<T, TResult>(this Span<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                r[i] = selector(source[i]);
            }
            return r;
        }



        /// <summary>
        ///  Projects each element of a sequence into a new form by incorporating the element's index.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element of source.</returns>
        public static TResult[] SelectQ<T, TResult>(this Span<T> source, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }
            var r = new TResult[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                r[i] = selector(source[i], i);
            }
            return r;
        }

        // --------------------------  LISTS --------------------------------------------

        /// <summary>
        ///  Projects each element of a sequence into a new form in place.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>        
        public static void SelectInPlaceQ<T>(this List<T> source, Func<T, T> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            for (var i = 0; i < source.Count; i++)
            {
                source[i] = selector(source[i]);
            }
        }

        /// <summary>
        ///  Projects each element of a sequence into a new form, in place, by incorporating the element's index.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>        
        public static void SelectInPlaceQ<T>(this List<T> source, Func<T, int, T> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            for (var i = 0; i < source.Count; i++)
            {
                source[i] = selector(source[i], i);
            }
        }


        /// <summary>
        ///  Projects each element of a sequence into a new form. (map in every other language)
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on (map).</param>
        /// <param name="selector">A transform function to apply (map) to each element.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element (mapping) of source.</returns>
        public static List<TResult> SelectQ<T, TResult>(this List<T> source, Func<T, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = new List<TResult>(source.Count);

            for (var i = 0; i < source.Count; i++)
            {
                r.Add(selector(source[i]));
            }

            return r;
        }


        /// <summary>
        ///  Projects each element of a sequence into a new form by incorporating the element's index.
        /// </summary>        
        /// <param name="source">A sequence of values to invoke a transform function on.</param>
        /// <param name="selector">A transform function to apply to each source element; the second parameter of the function represents the index of the source element.</param>
        /// <returns>A sequence whose elements are the result of invoking the transform function on each element of source.</returns>
        public static List<TResult> SelectQ<T, TResult>(this List<T> source, Func<T, int, TResult> selector)
        {
            if (source == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(source));
            }

            if (selector == null)
            {
                ThrowHelper.ThrowArgumentNullException(nameof(selector));
            }

            var r = new List<TResult>(source.Count);

            for (var i = 0; i < source.Count; i++)
            {
                r.Add(selector(source[i],i));
            }

            return r;
        }
	}
}