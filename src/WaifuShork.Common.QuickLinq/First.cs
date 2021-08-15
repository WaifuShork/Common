﻿namespace Wyvern.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// --------------------------  Arrays --------------------------------------------

        /// <summary>
        /// Returns the first element of an array.
        /// </summary>        
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>The first element in the specified array.</returns>
        public static T FirstF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            return source[0];
        }

        /// <summary>
        /// Returns the first element in an array that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">An array to return an element from.</param>
        /// <param name="predicate">A function to teast each element for a condition.</param>
        /// <returns>The first element that satisfies the condition.</returns>
        public static T FirstF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }

            throw Error.NoMatch();
        }

       


        /// <summary>
        /// Returns the first element of an array, or a default value if the
        /// array contains no elements.
        /// </summary>             
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>default value if source is empty, otherwise, the first element
        /// in source.</returns>        
        public static T FirstOrDefaultF<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                return default;
            }
            return source[0];
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a 
        /// default value if no such element is found.
        /// </summary>        
        /// <param name="source">An IEnumerable to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        public static T FirstOrDefaultF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }

            return default;
        }
        
        // --------------------------  Span --------------------------------------------

        /// <summary>
        /// Returns the first element of an array.
        /// </summary>        
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>The first element in the specified array.</returns>
        public static T FirstF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                throw Error.NoElements();
            }
            
            return source[0];
        }

        /// <summary>
        /// Returns the first element in an array that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">An array to return an element from.</param>
        /// <param name="predicate">A function to teast each element for a condition.</param>
        /// <returns>The first element that satisfies the condition.</returns>
        public static T FirstF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }

            throw Error.NoMatch();
        }




        /// <summary>
        /// Returns the first element of an array, or a default value if the
        /// array contains no elements.
        /// </summary>             
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>default value if source is empty, otherwise, the first element
        /// in source.</returns>        
        public static T FirstOrDefaultF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length == 0)
            {
                return default;
            }
            
            return source[0];
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a 
        /// default value if no such element is found.
        /// </summary>        
        /// <param name="source">An IEnumerable to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        public static T FirstOrDefaultF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    return source[i];
                }
            }

            return default;
        }

        // --------------------------  Lists --------------------------------------------

        /// <summary>
        /// Returns the first element of a list
        /// </summary>        
        /// <param name="source">The list to return the first element of.</param>
        /// <returns>The first element in the specified list.</returns>   
        public static T FirstF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                throw Error.NoElements();
            }
            return source[0];
        }

        /// <summary>
        /// Returns the first element in a list that satisfies a specified condition.
        /// </summary>        
        /// <param name="source">An list to return an element from.</param>
        /// <param name="predicate">A function to teast each element for a condition.</param>
        /// <returns>The first element in the list that satisfies the condition.</returns>       
        public static T FirstF<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var firstIndex = source.FindIndex(predicate);
            if (firstIndex == -1)
            {
                throw Error.NoMatch();
            }
            
            return source[firstIndex];
        }

        /// <summary>
        /// Returns the first element of an array, or a default value if the
        /// array contains no elements.
        /// </summary>             
        /// <param name="source">The array to return the first element of.</param>
        /// <returns>default value if source is empty, otherwise, the first element
        /// in source.</returns>      
        public static T FirstOrDefaultF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Count == 0)
            {
                return default;
            }
            
            return source[0];
        }

        /// <summary>
        /// Returns the first element of the sequence that satisfies a condition or a 
        /// default value if no such element is found.
        /// </summary>        
        /// <param name="source">An IEnumerable to return an element from.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns></returns>
        public static T FirstOrDefaultF<T>(this List<T> source, Predicate<T> predicate)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw Error.ArgumentNull("predicate");
            }

            var firstIndex = source.FindIndex(predicate);
            if (firstIndex == -1)
            {
                return default;
            }
            
            return source[firstIndex];
        }
	}
}