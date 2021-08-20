namespace WaifuShork.Common.QuickLinq
{
	using System.Collections.Generic;
	using Microsoft.Toolkit.Diagnostics;

	public static partial class QuickLinq
	{
		public static T[] ConcatQ<T>(this T[] first, T[] second)
		{
			if (first == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(first));
			}
			if (second == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(second));
			}
			
			var result = new T[first.Length + second.Length];
			
			// Populate part 1
			for (var i = 0; i < first.Length; i++)
			{
				result[i] = first[i];
			}
			
			// Array.Copy(first, 0, result, 0, first.Length);
			// Array.Copy(second, 0, result, first.Length, second.Length);
			
			// Populate part 2
			for (var i = first.Length; i < result.Length; i++)
			{
				result[i] = second[i - second.Length];
			}

			return result;
		}
		
		public static T[] ConcatQ<T>(this T[] first, IList<T> second)
		{
			if (first == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(first));
			}
			if (second == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(second));
			}
			
			var result = new T[first.Length + second.Count];
			
			// Populate part 1
			for (var i = 0; i < first.Length; i++)
			{
				result[i] = first[i];
			}
			
			// Array.Copy(first, 0, result, 0, first.Length);
			// Array.Copy(second, 0, result, first.Length, second.Length);
			
			// Populate part 2
			for (var i = first.Length; i < result.Length; i++)
			{
				result[i] = second[i - second.Count];
			}
			
			return result;
		}
		
		public static T[] ConcatQ<T>(this IList<T> first, T[] second)
		{
			if (first == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(first));
			}
			if (second == null)
			{
				ThrowHelper.ThrowArgumentNullException(nameof(second));
			}
			
			var result = new T[first.Count + second.Length];
			
			// Populate part 1
			for (var i = 0; i < first.Count; i++)
			{
				result[i] = first[i];
			}
			
			// Array.Copy(first, 0, result, 0, first.Length);
			// Array.Copy(second, 0, result, first.Length, second.Length);
			
			// Populate part 2
			for (var i = first.Count; i < result.Length; i++)
			{
				result[i] = second[i - second.Length];
			}
			
			return result;
		}
	}
}