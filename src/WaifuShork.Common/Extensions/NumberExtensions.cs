namespace WaifuShork.Common.Extensions;

using System;
using WaifuShork.Extensions;

public static class NumberExtensions
{
	public static bool IsNegative<T>(this T input)
		where T : INumber<T>, ISignedNumber<T>, IComparisonOperators<T, T>
	{
		return input <= (0.As<T>() ?? (T)(object)0);
	}

	public static bool IsPositive<T>(this T input)
		where T : INumber<T>, 
		ISignedNumber<T>, 
		IUnsignedNumber<T>, 
		IComparisonOperators<T, T>
	{
		return input >= (1.As<T>() ?? (T)(object)1);
	}
}