using WaifuShork.Common.Extensions;

namespace WaifuShork.Common.Attributes;

using System;
using Microsoft.Toolkit.Diagnostics;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class TimeSpanFormatAttribute : Attribute
{
	public const string FormatISO8061 = @"ddThh\:mm\:ss\.fff";
	public const string FormatConstant = "c";
	public const string FormatLong = "G";
	public const string FormatShort = "g";

	public TimeSpanFormatAttribute(TimeSpanFormatType type)
	{
		if (type < 0 || type > TimeSpanFormatType.InvariantLocaleShort)
		{
			ThrowHelper.ThrowArgumentOutOfRangeException(nameof(type), "Specified format type is not legal or supported.");
		}

		Type = type;
		Format = null;
	}

	public TimeSpanFormatAttribute(string? format, TimeSpanFormatType type = TimeSpanFormatType.Custom)
	{
		if (format.IsNullOrWhiteSpace())
		{
			ThrowHelper.ThrowArgumentNullException(nameof(format), "Specified format cannot be null, empty, or only whitespace.");
		}

		Format = format;
		Type = type;
	}
		
	public string? Format { get; }
	public TimeSpanFormatType Type { get; }
}

public enum TimeSpanFormatType
{
	ISO8601 = 0,
	InvariantConstant = 1,
		
	CurrentLocaleLong = 2,
	CurrentLocaleShort = 3,
		
	InvariantLocaleLong = 4,
	InvariantLocaleShort = 5,
		
	Custom = int.MaxValue
}