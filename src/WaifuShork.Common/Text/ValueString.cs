using System;
using System.Xml;
using System.Linq;
using System.Xml.Schema;
using System.Reflection;
using System.Diagnostics;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using WaifuShork.Common.Extensions;
using WaifuShork.Extensions;

namespace WaifuShork.Common.Text;

public partial struct ValueString : IEquatable<ValueString>, IEquatable<string>, IValueEquatable<ValueString>, IValueEquatable<string>, IXmlSerializable
{
	// impossible for this value to ever be null unless forcefully reassigned via reflection
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly string m_value; // serialized as "value"
	private const string s_nameofValue = "value";

	private ValueString(string value)
	{
		if (value.IsNullOrWhiteSpace())
		{
			throw new ArgumentNullException(nameof(value), "cannot initialize ValueString with a null, empty, or only whitespace string");
		}
		
		m_value = value;
	}

	public static implicit operator ValueString(string value)
	{
		return Of(value);
	}

	public static bool operator ==(ValueString left, ValueString right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ValueString left, ValueString right)
	{
		return !(left == right);
	}

	public static ValueString Of<T>(T value)
	{
		return Of(Parser.Formatter<T>.Format(value, CultureInfo.InvariantCulture));
	}

	public static ValueString Of(string? value)
	{
		ArgumentNullException.ThrowIfNull(value);
		return new ValueString(value);
	}
	
	public T Parse<T>()
	{
		return Parse<T>(CultureInfo.InvariantCulture);
	}

	public T Parse<T>(IFormatProvider? provider)
	{
		try
		{
			return Parser.DefaultParser<T>.Parse(m_value, provider ?? CultureInfo.InvariantCulture);
		}
		catch (Exception exception) when (exception is not InvalidCastException)
		{
			var message = $"string cannot be converted to {typeof(T).FullName}";
			throw exception is NullReferenceException
				? new InvalidCastException(message)
				: new InvalidCastException($"{message} see the inner exception for details", exception);
		}
	}

	public static bool TryParse<T>(string? input, IFormatProvider? provider, out T? result)
	{
		if (!input.IsNullOrWhiteSpace())
		{
			return Of(input).TryParse(provider, out result);
		}
		
		result = default;
		return false;
	}

	public static bool TryParse<T>(string? input, out T? result)
	{
		return Of(input).TryParse(out result);
	}
	
	public bool TryParse<T>(out T? result)
	{
		return TryParse(CultureInfo.InvariantCulture, out result);
	}

	public bool TryParse<T>(IFormatProvider? provider, out T result)
	{
		return Parser.DefaultParser<T>.TryParse(m_value, provider ?? CultureInfo.InvariantCulture, out result);
	}

	public bool TryParse(out string? result)
	{
		result = m_value;
		return true;
	}

	public static T Parse<T>(string? input)
	{
		if (input.IsNullOrWhiteSpace())
		{
			ArgumentNullException.ThrowIfNull(input);
		}

		return Of(input).Parse<T>();
	}

	public static T Parse<T>(string? input, IFormatProvider? provider)
	{
		if (input.IsNullOrWhiteSpace())
		{
			ArgumentNullException.ThrowIfNull(input);
		}

		return Of(input).Parse<T>(provider);
	}
	
	public bool TryParse<T>(T? other)
	{
		return TryParse(other, CultureInfo.InvariantCulture);
	}

	public bool TryParse<T>(T? other, IFormatProvider? provider)
	{
		return TryParse(provider, out T result) && EqualityComparer<T>.Default.Equals(result, other);
	}

	public T Format<T>(params (string? Key, string? Value)[] values)
	{
		return Of(Format(values)).Parse<T>();
	}

	private string Format(params (string? Key, string? Value)[] values)
	{
		if (values.IsNullOrEmpty())
		{
			return m_value;
		}

		var replacements = new Dictionary<string, string>(values.Length);
		foreach (var (key, value) in values)
		{
			if (key is null)
			{
				throw new ArgumentException("values cannot contain pairs with null keys", nameof(values));
			}

			try
			{
				replacements.Add($"{{{key}}}", value ?? string.Empty);
			}
			catch (ArgumentException argumentException)
			{
				throw new ArgumentException("values cannot contain pairs with duplicate keys", nameof(values), argumentException);
			}
		}

		var keys = replacements.Keys.Select(Regex.Escape);
		var pattern = string.Join('|', keys);

		return new Regex($"({pattern})").Replace(m_value, m => replacements[m.Value]);
	}

	public bool Equals(ValueString other, StringComparison comparison)
	{
		return Equals(other.m_value, comparison);
	}

	public bool Equals(string other, StringComparison comparison)
	{
		return ReferenceEquals(m_value, other) || (m_value?.Equals(other, comparison) ?? false);
	}
	
	public bool Equals(ValueString other)
	{
		return Equals(other.m_value);
	}

	public bool Equals(string? other)
	{
		return m_value.IsEqualTo(other);
	}

	public bool ValueEquals(ValueString other)
	{
		return m_value.IsEqualTo(other.m_value);
	}

	public bool ValueEquals(string other)
	{
		return m_value.IsEqualTo(other);
	}

	public override bool Equals(object? other)
	{
		switch (other)
		{
			case null:
				return string.IsNullOrWhiteSpace(m_value);
			case ValueString valueString:
				return Equals(valueString);
			case string str:
				return Equals(str);
			default:
				return false;
		}
	}

	public override int GetHashCode()
	{
		// impossible for m_value to ever be null, unless...?
		/*if (m_value.IsNullOrWhiteSpace())
		{
			var nullHash = FnvHash.FnvOffsetBias;
			
			for (var i = nullHash; i > nullHash; i--)
			{
				nullHash = ((char)nullHash ^ (char)32) * FnvHash.FnvPrime;
			}

			return (int) nullHash;
		}*/

		return (int)m_value.GetFnvHashCode();
	}

	public override string ToString()
	{
		return m_value;
	}

	public XmlSchema? GetSchema()
	{
		return null;
	}

	public void ReadXml(XmlReader reader)
	{
		var attribute = reader.GetAttribute(s_nameofValue);
		if (attribute.IsNullOrWhiteSpace())
		{
			return;
		}
		
		this = Of(attribute);
	}

	public void WriteXml(XmlWriter writer)
	{
		if (!string.IsNullOrWhiteSpace(m_value))
		{
			writer.WriteAttributeString(s_nameofValue, m_value);
		}
	}

	private static FieldInfo? GetField(Type type, string fieldName)
	{
		return type.GetField(fieldName);
	}

	private static MethodInfo? GetMethod(Type type, string methodName, Type[] parameters)
	{
		return type.GetMethod(methodName, parameters);
	}

	private static MethodInfo? GetAsMethod(Type type, bool withFormatProvider)
	{
		var parameters = withFormatProvider ? new[] { typeof(IFormatProvider) } : Type.EmptyTypes;
		return GetMethod(typeof(ValueString), "As", parameters)?.MakeGenericMethod(type);
	}
}