namespace WaifuShork.Common.QuickLinq
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
        /// Returns a number that represents how many elements in the specified
        /// array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A number that represents how many elements in the array satisfy the condition
        /// in the predicate function.</returns>
        public static int CountF<T>(this T[] source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var count = 0;
            for (var i = 0; i < source.Length; i++)
            {
                checked
                {
                    if (predicate(source[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        // --------------------------  this Spans --------------------------------------------

        /// <summary>
        /// Returns a number that represents how many elements in the specified
        /// array satisfy a condition.
        /// </summary>        
        /// <param name="source">An array that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A number that represents how many elements in the array satisfy the condition
        /// in the predicate function.</returns>
        public static int CountF<T>(this Span<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var count = 0;
            for (var i = 0; i < source.Length; i++)
            {
                checked
                {
                    if (predicate(source[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }


        // ------------------------------ Lists ---------------------

        /// <summary>
        /// Returns a number that represents how many elements in the specified
        /// list satisfy a condition.
        /// </summary>        
        /// <param name="source">A list that contains elements to be tested and counted.</param>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A number that represents how many elements in the list satisfy the condition
        /// in the predicate function.</returns>
        public static int CountF<T>(this List<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                throw ThrowHelper.ArgumentNull("source");
            }

            if (predicate == null)
            {
                throw ThrowHelper.ArgumentNull("predicate");
            }

            var count = 0;
            for (var i = 0; i < source.Count; i++)
            {
                checked
                {
                    if (predicate(source[i]))
                    {
                        count++;
                    }
                }
            }

            return count;
        }

	}
}