namespace WaifuShork.Common.QuickLinq
{
	using System.Collections.Generic;
	using Microsoft.Toolkit.Diagnostics;
	
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public static partial class QuickLinq
	{
		/// <summary>
		/// Generates a sequence of integral numbers within a specified range.
		/// </summary>
		/// <param name="start">The value of the first integer in the sequence.</param>
		/// <param name="count">The number of sequential integers to generate.</param>
		/// <returns>A sequence that contains a range of sequential integral numbers.</returns>
		public static int[] RangeArrayQ(int start, int count)
		{
			var max = ((long)start) + count - 1;
			if (count < 0 || max > int.MaxValue)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
			}
			
			var result = new int[count];
			for (var i = 0; i < result.Length; i++)
			{
				result[i] = i + start;
			}
			return result;
		}


		/// <summary>
		/// Generates a sequence of integral numbers within a specified range.
		/// </summary>
		/// <param name="start">The value of the first integer in the sequence.</param>
		/// <param name="count">The number of sequential integers to generate.</param>
		/// <returns>A sequence that contains a range of sequential integral numbers.</returns>
		public static List<int> RangeListQ(int start, int count)
		{
			var max = ((long)start) + count - 1;
			if (count < 0 || max > int.MaxValue)
			{
				ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));
			}
			
			var result = new List<int>(count);
			for (var i = 0; i < count; i++)
			{
				result.Add(i + start);
			}
			return result;
		}
	}
}