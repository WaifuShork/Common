namespace WaifuShork.Common.Extensions;

using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

public static class IEnumerableExtensions
{
	[ContractAnnotation("input:null => true")]
	public static bool IsNullOrEmpty<T>(this IEnumerable<T>? input) 
		where T : notnull
	{
		return input is null || !input.Any();
	}
	
	[ContractAnnotation("input:notnull => true")]
	public static bool IsNotNullOrEmpty<T>(this IEnumerable<T>? input) 
		where T : notnull
	{
		return !input.IsNullOrEmpty();
	}
	
	[ContractAnnotation("input:null => true")]
	public static bool IsNullOrEmpty<TKey, TValue>(this KeyValuePair<TKey, TValue>[] input)
		where TKey : notnull
		where TValue : notnull
	{
		return input is null || !input.Any();
	}
	
	[ContractAnnotation("input:notnull => true")]
	public static bool IsNotNullOrEmpty<TKey, TValue>(this KeyValuePair<TKey, TValue>[] input)
		where TKey : notnull
		where TValue : notnull
	{
		return !input.IsNullOrEmpty();
	}
}