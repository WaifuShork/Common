﻿namespace WaifuShork.Common.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// --------------------------- Arrays ----------------------------

        /// <summary>
        /// Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>        
        /// <param name="source">A sequence to return the single element of</param>
        /// <returns>The single element of the input sequence or default if no elements exist.</returns>
        public static T SingleF<T>(this T[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }

            if (source.Length > 1) 
            {
                throw ThrowHelper.MoreThanOneElement();
            }

            return source[0];
        }

        /// <summary>
        /// Returns the only element of a sequence, or the default if no elements exist, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>        
        /// <param name="source">A sequence to return the single element of</param>
        /// <returns>The single element of the input sequence</returns>
        public static T SingleOrDefaultF<T>(this T[] source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                return default;
            }

            if (source.Length > 1)
            {
                throw ThrowHelper.MoreThanOneElement();
            }

            return source[0];
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// </summary>        
        /// <param name="source">A sequence to return a single element from.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <returns>The single element of the input sequence that satisfies a condition.</returns>
        public static T SingleF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var result = default(T);
            var foundMatch = false;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw ThrowHelper.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return result;
            }
            
            throw ThrowHelper.NoMatch();
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, or a default value if
        /// no such element exists, and throws an exception if more than one such element exists.
        /// </summary>        
        /// <param name="source">A sequence to return a single element from.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <returns>The single element of the input sequence that satisfies a condition or default value if no such element is found.</returns>
        public static T SingleOrDefaultF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }
          

            var result = default(T);
            var foundMatch = false;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw ThrowHelper.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            return result;
        }
       
        // --------------------------- Spans ----------------------------

        /// <summary>
        /// Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>        
        /// <param name="source">A sequence to return the single element of</param>
        /// <returns>The single element of the input sequence or default if no elements exist.</returns>
        public static T SingleF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                throw ThrowHelper.NoElements();
            }

            if (source.Length > 1)
            {
                throw ThrowHelper.MoreThanOneElement();
            }

            return source[0];
        }

        /// <summary>
        /// Returns the only element of a sequence, or the default if no elements exist, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>        
        /// <param name="source">A sequence to return the single element of</param>
        /// <returns>The single element of the input sequence</returns>
        public static T SingleOrDefaultF<T>(this Span<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (source.Length == 0)
            {
                return default(T);
            }

            if (source.Length > 1)
            {
                throw ThrowHelper.MoreThanOneElement();
            }

            return source[0];
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// </summary>        
        /// <param name="source">A sequence to return a single element from.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <returns>The single element of the input sequence that satisfies a condition.</returns>
        public static T SingleF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var result = default(T);
            var foundMatch = false;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw ThrowHelper.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return result;
            }
            
            throw ThrowHelper.NoMatch();
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, or a default value if
        /// no such element exists, and throws an exception if more than one such element exists.
        /// </summary>        
        /// <param name="source">A sequence to return a single element from.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <returns>The single element of the input sequence that satisfies a condition or default value if no such element is found.</returns>
        public static T SingleOrDefaultF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }


            var result = default(T);
            var foundMatch = false;
            for (var i = 0; i < source.Length; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw ThrowHelper.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            return result;
        }

        // --------------------------- Lists ----------------------------

        /// <summary>
        /// Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>        
        /// <param name="source">A sequence to return the single element of</param>
        /// <returns>The single element of the input sequence</returns>
        public static T SingleF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                throw ThrowHelper.NoElements();
            }

            if (source.Count > 1) 
            {
                throw ThrowHelper.MoreThanOneElement();
            }

            return source[0];
        }

        /// <summary>
        /// Returns the only element of a sequence, or default if no elements exist, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>        
        /// <param name="source">A sequence to return the single element of</param>
        /// <returns>The single element of the input sequence or default if no elements exist.</returns>
        public static T SingleOrDefaultF<T>(this List<T> source)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (source.Count == 0)
            {
                return default;
            }

            if (source.Count > 1) 
            {
                throw ThrowHelper.MoreThanOneElement();
            }

            return source[0];
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.
        /// </summary>        
        /// <param name="source">A sequence to return a single element from.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <returns>The single element of the input sequence that satisfies a condition.</returns>
        public static T SingleF<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var result = default(T);
            var foundMatch = false;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw ThrowHelper.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            if (foundMatch)
            {
                return result;
            }
            
            throw ThrowHelper.NoMatch();
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition, or a default value if
        /// no such element exists, and throws an exception if more than one such element exists.
        /// </summary>        
        /// <param name="source">A sequence to return a single element from.</param>
        /// <param name="predicate">A function to test an element for a condition.</param>
        /// <returns>The single element of the input sequence that satisfies a condition or default value if no such element is found.</returns>
        public static T SingleOrDefaultF<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var result = default(T);
            var foundMatch = false;
            for (var i = 0; i < source.Count; i++)
            {
                if (predicate(source[i]))
                {
                    if (foundMatch)
                    {
                        throw ThrowHelper.MoreThanOneMatch();
                    }

                    result = source[i];
                    foundMatch = true;
                }
            }

            return result;
        }
	}
}