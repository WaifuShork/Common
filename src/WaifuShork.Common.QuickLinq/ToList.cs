namespace Wyvern.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
	
	// ReSharper disable LoopCanBeConvertedToQuery
	// ReSharper disable ForCanBeConvertedToForeach
	public partial class QuickLinq
	{
		private static readonly object _lock = new();
		public static List<T> ToListF<T>(this IEnumerable<T> source)
		{
			lock (_lock)
			{
				if (source == null)
				{
					throw Error.ArgumentNull("source");
				}
			
				var list = new List<T>();
				foreach (var item in source)
				{
					list.Add(item);
				}

				if (list == null)
				{
					throw Error.ArgumentNull("list");
				}

				return list;
			}
		}

		public static List<T> ToListF<T>(this T[] source)
		{
			if (source == null)
			{
				throw Error.ArgumentNull("source");
			}
			
			var list = new List<T>();
			for (var i = 0; i < source.Length; i++)
			{
				list.Add(source[i]);
			}

			if (list == null)
			{
				throw Error.ArgumentNull("list");
			}

			return list;
		}
		
		public static List<T> ToListF<T>(this Span<T> source)
		{
			if (source == null)
			{
				throw Error.ArgumentNull("source");
			}
			
			var list = new List<T>();
			foreach (var item in source)
			{
				list.Add(item);
			}

			if (list == null)
			{
				throw Error.ArgumentNull("list");
			}

			return list;
		}
	}
}