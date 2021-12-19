using System;
using System.Collections.Generic;
using System.Globalization;

namespace WaifuShork.Common.Text;

public static class ValueStringUtils
{
	public static bool TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, ValueString> source, TKey key, out TValue value)
	{
		return source.TryGetValue(key, CultureInfo.InvariantCulture, out value);
	}

	public static bool TryGetValue<TKey, TValue>(this IReadOnlyDictionary<TKey, ValueString> source, TKey key, IFormatProvider provider, out TValue? value)
	{
		ArgumentNullException.ThrowIfNull(source, "source != null");
		if (source.TryGetValue(key, out ValueString vsValue) && vsValue.TryParse(provider, out value))
		{
			return true;
		}

		value = default;
		return false;
	}

	public static void Add<TKey, TValue>(this IDictionary<TKey, ValueString> source, TKey key, TValue value)
	{
		ArgumentNullException.ThrowIfNull(source, "source != null");
		source.Add(key, ValueString.Of(value));
	}

	public static void Set<TKey, TValue>(this IDictionary<TKey, ValueString> source, TKey key, TValue value)
	{
		ArgumentNullException.ThrowIfNull(source, "source != null");

		source[key] = ValueString.Of(value);
	}
}