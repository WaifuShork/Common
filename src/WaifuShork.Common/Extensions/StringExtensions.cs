namespace WaifuShork.Common.Extensions;

using System.Linq;
using JetBrains.Annotations;

public static class StringExtensions
{
	[ContractAnnotation("value:null => true")]
	public static bool IsNullOrWhiteSpace(this string? value)
	{
		if (value is null || value.Length == 0)
		{
			return true;
		}

		return value.All(char.IsWhiteSpace);
	}

	[ContractAnnotation("left:null => false;right:null => false")]
	public static bool IsEqualTo(this string? left, string? right)
	{
		if (left is null && right is null)
		{
			return true;
		}
			
		if (left.IsNullOrWhiteSpace() || right.IsNullOrWhiteSpace())
		{
			return false;
		}

		var length = left?.Length ?? 0;
		var result = string.CompareOrdinal(left, 0, right, 0, length);
		return result == 0;
	}
}