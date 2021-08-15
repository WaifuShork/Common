namespace Wyvern.QuickLinq
{
	using System.Collections.Generic;
    
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		// ------------------------ Arrays ---------------------------

		/// <summary>
		/// Generates a sequence that contains one repeated value.
		/// </summary>        
		/// <param name="element">The value to be repeated.</param>
		/// <param name="count">The number of times to repeat the value in the generated sequence.</param>
		/// <returns>A sequence that contains a repeated value</returns>
		public static T[] RepeatArrayF<T>(T element, int count)
		{
			var result = new T[count];
			for (var i = 0; i < result.Length; i++)
			{
				result[i] = element;
			}
			return result;
		}

		// ------------------------ Lists ---------------------------

		/// <summary>
		/// Generates a sequence that contains one repeated value.
		/// </summary>        
		/// <param name="element">The value to be repeated.</param>
		/// <param name="count">The number of times to repeat the value in the generated sequence.</param>
		/// <returns>A sequence that contains a repeated value</returns>
		public static List<T> RepeatListF<T>(T element, int count)
		{
			var result = new List<T>(count);
			for (var i = 0; i < count; i++)
			{
				result.Add(element);
			}
			return result;
		}
	}
}