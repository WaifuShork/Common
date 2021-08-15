namespace WaifuShork.Common.Utilities
{
	using System;
	
	internal static class SliceExtensions
	{
		public static Span<T> Slice<T>(this T[] array, int start, int length)
		{
			return array.AsSpan().Slice(start, length);
		}
	}
}