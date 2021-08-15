namespace Wyvern.QuickLinq
{
	using System;
	using Utilities;
	using System.Collections.Generic;
	
	public partial class QuickLinq
	{
		// ReSharper disable LoopCanBeConvertedToQuery
		// ReSharper disable ForCanBeConvertedToForeach
		public static T[] ToArrayF<T>(this IEnumerable<T> source)
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

				var result = new T[list.Count];
				for (var i = 0; i < list.Count; i++)
				{
					result[i] = list[i];
				}

				if (result == null)
				{
					throw Error.ArgumentNull("result");
				}

				return result;
			}
		}
		
		public static T[] ToArrayF<T>(this Span<T> source)
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

			var result = new T[list.Count];
			for (var i = 0; i < list.Count; i++)
			{
				result[i] = list[i];
			}

			if (result == null)
			{
				throw Error.ArgumentNull("result");
			}

			return result;
		}
	}
}