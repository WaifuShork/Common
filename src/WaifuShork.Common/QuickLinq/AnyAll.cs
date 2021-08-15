﻿using System.Linq;

namespace WaifuShork.Common.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// --------------------------  ARRAYS --------------------------------------------

        /// <summary>
        /// Determines whether an array contains any elements
        /// </summary>        
        /// <param name="source">The array to check for emptiness</param>
        /// <returns>true if the source array contains any elements, otherwise, false/</returns>
        public static bool AnyF<T>(this T[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            
            return source.Length > 0;
        }
        
        /// <summary>
        /// Determines whether any element of an array satisfies a condition.
        /// </summary>        
        /// <param name="source">An array whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if any elements in the source array pass the test in the specified predicate; otherwise, false.</returns>
        public static bool AnyF<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            return Array.Exists(source, predicate);
        }

     
        /// <summary>
        /// Determines whether all elements of an array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains the elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if every element of the source array passes the test in the specified
        /// predicate, or if the array is empty; otherwise, false</returns>
        public static bool AllF<TSource>(this TSource[] source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            return Array.TrueForAll(source, predicate);
        }

        // --------------------------  this SpanS --------------------------------------------

        /// <summary>
        /// Determines whether an array contains any elements
        /// </summary>        
        /// <param name="source">The array to check for emptiness</param>
        /// <returns>true if the source array contains any elements, otherwise, false/</returns>
        public static bool AnyF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            return source.Length > 0;
        }

        /// <summary>
        /// Determines whether any element of an array satisfies a condition.
        /// </summary>        
        /// <param name="source">An array whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if any elements in the source array pass the test in the specified predicate; otherwise, false.</returns>
        public static bool AnyF<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i])) return true;
            }
            return false;
        }


        /// <summary>
        /// Determines whether all elements of an array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains the elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if every element of the source array passes the test in the specified
        /// predicate, or if the array is empty; otherwise, false</returns>
        public static bool AllF<TSource>(this Span<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            for (var i = 0; i < source.Length; i++)
            {
                if (!predicate(source[i])) return false;
            }
            return true;
        }
        

        // --------------------------  Lists --------------------------------------------
        /// <summary>
        /// Determines whether a list contains any elements
        /// </summary>        
        /// <param name="source">The list to check for emptiness</param>
        /// <returns>true if the source list contains any elements, otherwise, false/</returns>
        public static bool AnyF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            return source.Count > 0;
        }

        /// <summary>
        /// Determines whether any element of an array satisfies a condition.
        /// </summary>        
        /// <param name="source">An array whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if any elements in the source array pass the test in the specified predicate; otherwise, false.</returns>
        public static bool AnyF<TSource>(this List<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            return source.Exists(predicate);
        }

        /// <summary>
        /// Determines whether all elements of a list satisfy a condition.
        /// </summary>        
        /// <param name="source">A list that contains the elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if every element of the source array passes the test in the specified
        /// predicate, or if the list is empty; otherwise, false</returns>
        public static bool AllF<TSource>(this List<TSource> source, Predicate<TSource> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            return source.TrueForAll(predicate);
        }
        
        // --------------------------  STRINGS --------------------------------------------

        /// <summary>
        /// Determines whether an array contains any elements
        /// </summary>        
        /// <param name="source">The array to check for emptiness</param>
        /// <returns>true if the source array contains any elements, otherwise, false/</returns>
        public static bool AnyF(this string source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }
            
            return source.Length > 0;
        }
        
        /// <summary>
        /// Determines whether any element of an array satisfies a condition.
        /// </summary>        
        /// <param name="source">An array whose elements to apply the predicate to.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>true if any elements in the source array pass the test in the specified predicate; otherwise, false.</returns>
        public static bool AnyF(this string source, Predicate<char> predicate)
        {
            var r = new char[source.Length];
            for (var i = 0; i < source.Length; i++)
            {
                r[i] = source[i];
            }
			
            return Array.Exists(r, predicate);
        }
	}
}