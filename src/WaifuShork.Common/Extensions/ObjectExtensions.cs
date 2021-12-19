namespace WaifuShork.Extensions;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using JetBrains.Annotations;
using Common.Text;

public static class ObjectExtensions
{
	///  <summary>
	/// 		A generic way to take <see cref="System.Object"/>, and convert/cast it to another type,
	/// 		in a way that replicates the C#
	/// 		<a href="https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/expressions#the-as-operato">as operator</a>
	/// 		in as cleanly of way as possible, it's not currently the fastest implementation,
	/// 		but it's one of the cleanest I've been able to come up with,
	/// 		that doesn't involve hundreds of lines for custom parsing method calls.
	///  </summary>
	///  <remarks>
	/// 		This method actually takes advantage of a library called ValueString, which can be found <a href="https://github.com/antiufo/Shaman.ValueString">here</a>
	///			(I have no idea how long this library is planning on being supported, but I'll most likely end up making my own variant if you see this message)
	///			it is the default fallback, when the type converter is unable to successfully convert a type due to: <br/>
	/// 		1) the type converting from doesn't implement the right <see cref="IConvertible"/> interface (or even at all) <br/>
	/// 		2) you're attempting to convert something like (byte) to (int), since when unboxing in .NET <br/>
	/// 		   if have a type mismatch, a <see cref="InvalidCastException"/> will be thrown, so it attempts to convert <br/>
	/// 		   your given value into a string, and parse it as you would normally with a TryParse call, using <br/>
	/// 		   entirely Invariant formatting to accept the largest range of values. <br/>
	/// 		3) the default value for <typeparamref name="TResult"/> will be returned if a null value is given,
	/// 		   a parser/converter is unable to be located for your type, or an unexpected/unhandled mishap occured <br/><br/>
	/// 
	/// 		Keep in mind, this method isn't magic, it will do it's best to convert/cast your type in a clean and fast manner, but it's (almost)
	/// 		impossible to fully cast a type that doesn't implement converters/parsers, without using
	/// 		<a href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/reflection">reflection</a>, but maybe that's a task for another time... unless?
	///  </remarks>
	///  <param name="input">
	/// 		The input to convert/parse into <typeparamref name="TResult"/>, if input is null, you will get null/default value
	/// 		for the type of <typeparamref name="TResult"/>
	///  </param>
	///  <typeparam name="TResult">
	/// 		The type that <paramref name="input"/> will attempt to be converted/parsed into
	///  </typeparam>
	///  <returns>
	/// 		The successfully converted value or default value of <typeparamref name="TResult"/>,
	/// 		for numeric types, that value will be 0, or in the case of a <see cref="Nullable{TResult}"/>,
	/// 		use a null check to validate the value
	///  </returns>
	[SuppressMessage("ReSharper", "RedundantCast")]
	[SuppressMessage("ReSharper", "SuggestVarOrType_BuiltInTypes")]
	[SuppressMessage("ReSharper", "SuggestVarOrType_SimpleTypes")]
	[SuppressMessage("ReSharper", "InlineTemporaryVariable")]
	[ContractAnnotation("input:null => null")]
	public static TResult? As<TResult>(this object? input)
	{
		if (input is null)
		{
			return default;
		}

		// explicitly typed as non-nullable object type for the sake of 
		// letting the compiler know that "value" *actually* can't be null,
		// since we are using Nullable Reference Types (NRT), even though
		// System.Object *can* be null, it never will be. Link:
		// https://docs.microsoft.com/en-us/dotnet/csharp/nullable-references
		object value = input;

		var underlyingType = Nullable.GetUnderlyingType(value.GetType());
		// I probably don't even need to call this method? I already know the value
		// will never be null (thonk). I'm just overcautious I guess
		if (underlyingType is not null && value is null)
		{
			return default;
		}

		// see comment above ^^
		// var baseType = (Type) (underlyingType ?? value.GetType()) will still 
		// return (Type?), so I've opted to explicitly type the variable so the
		// compiler knows that baseType will never be null
		Type baseType = underlyingType ?? value.GetType();
		try
		{
			// will throw if:
			// 1) "value" does not implement the IConvertible interface
			// 2) conversion is not supported, value is null and baseType is null
			// 3) value represents a number that is out of range of the baseType
			// 4) baseType is null (event if value is null), can't convert null to... null?
			if (!value.IsNumber())
			{
				// Since we know it's not a number type, let's try to invoke the converter for
				// the given type e.g. any type that implements IConvertable, this allows us to
				// attempt conversion even on user defined types
				return (TResult)Convert.ChangeType(value, baseType);
			}
			
			// It must be some form of number
			var strValue = value.ToString() ?? "";
			var valueStr = ValueString.Of(strValue);
			
			// Special casing when then input is a floating point (or decimal), and the result is an integer,
			// InvalidCastException will be thrown or a TryParse will fail if you attempt to create an integer 
			// from any number with a decimal point 
			if (value.IsFloat() && typeof(TResult).IsInteger())
			{
				var newValueStr = ValueString.Of(strValue[..strValue.IndexOf('.')]);
				if (newValueStr.TryParse(CultureInfo.InvariantCulture, out TResult res))
				{
					return res;
				}
				return default;
			}
			
			// InvariantCulture is slower, but covers more edge cases
			if (valueStr.TryParse(CultureInfo.InvariantCulture, out TResult result))
			{
				return result;
			}
			return default;
		}
		// If an exception has been thrown here and a default value is returned, you should just 
		// implement a custom parsing/converting method for your type, or implement IConvertable
		catch (Exception)
		{
			return default;
		}
	}

	public static bool IsNumber(this Type type)
	{
		return type.IsInteger() || type.IsFloat();
	}
	
	public static bool IsNumber(this object? value)
	{
		if (value is null)
		{
			return false;
		}
		
		return value.IsFloat() || value.IsInteger();
	}

	public static bool IsFloat(this object? value)
	{
		if (value is null)
		{
			return false;
		}

		return !value.IsInteger() && value is float
		       || value is double
		       || value is decimal
		       || (value is string str && ValueString.Of(str).TryParse(str));
	}

	public static bool IsFloat(this Type? type)
	{
		if (type is null)
		{
			return false;
		}
		
		var code = Type.GetTypeCode(type);
		return code == TypeCode.Single
		       || code == TypeCode.Double
		       || code == TypeCode.Decimal;
	}

	public static bool IsInteger(this Type? type)
	{
		if (type is null)
		{
			return false;
		}

		var code = Type.GetTypeCode(type);
		return code == TypeCode.SByte
		       || code == TypeCode.Byte
		       || code == TypeCode.Int16
		       || code == TypeCode.UInt16
		       || code == TypeCode.Int32
		       || code == TypeCode.UInt32
		       || code == TypeCode.Int64
		       || code == TypeCode.UInt64
		       || type == typeof(BigInteger);
	}
	
	public static bool IsInteger(this object? value)
	{
		if (value is null)
		{
			return false;
		}

		return value is sbyte
		       || value is byte
		       || value is short
		       || value is ushort
		       || value is int
		       || value is uint
		       || value is long
		       || value is ulong
		       || value is BigInteger // why not? no reason not to support it, it's a valid integer after-all
		       || (value is string str && ValueString.Of(str).TryParse(str));
	}
}