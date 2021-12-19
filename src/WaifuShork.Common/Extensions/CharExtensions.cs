using System.Globalization;

namespace WaifuShork.Common.Extensions;

public static class CharExtensions
{
	public static char ToLower(this char ch, CultureInfo cultureInfo)
	{
		if (cultureInfo.Equals(CultureInfo.CurrentCulture))
		{
			return char.ToLower(ch);
		}

		if (cultureInfo.Equals(CultureInfo.InvariantCulture))
		{
			return char.ToLowerInvariant(ch);
		}

		return ch;
	}
	
	public static char ToLower(this char ch)
	{
		return ch.ToLower(CultureInfo.CurrentCulture);
	}

	public static char ToLowerInvariant(this char ch)
	{
		return ch.ToLower(CultureInfo.InvariantCulture);
	}
}