namespace WaifuShork.Common.Text;

using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

/// <content>Contains the <see cref="IConvertible" /> implementation.</content>
public partial struct ValueString : IConvertible
{
    /// <summary>
    ///     Contains cached <see cref="MethodInfo" /> instances of
    ///     <see cref="Parse{T}(System.IFormatProvider?)" /> to be used for
    ///     dynamic conversions.
    /// </summary>
    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private static readonly TypeCache<MethodInfo> asMethods
        = new TypeCache<MethodInfo>();

    /// <inheritdoc />
    TypeCode IConvertible.GetTypeCode()
        => TypeCode.Object;

    /// <inheritdoc />
    bool IConvertible.ToBoolean(IFormatProvider provider)
        => this.Parse<bool>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    byte IConvertible.ToByte(IFormatProvider provider)
        => this.Parse<byte>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    char IConvertible.ToChar(IFormatProvider provider)
        => this.Parse<char>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    DateTime IConvertible.ToDateTime(IFormatProvider provider)
        => this.Parse<DateTime>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    decimal IConvertible.ToDecimal(IFormatProvider provider)
        => this.Parse<decimal>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    double IConvertible.ToDouble(IFormatProvider provider)
        => this.Parse<double>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    short IConvertible.ToInt16(IFormatProvider provider)
        => this.Parse<short>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    int IConvertible.ToInt32(IFormatProvider provider)
        => this.Parse<int>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    long IConvertible.ToInt64(IFormatProvider provider)
        => this.Parse<long>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    sbyte IConvertible.ToSByte(IFormatProvider provider)
        => this.Parse<sbyte>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    float IConvertible.ToSingle(IFormatProvider provider)
        => this.Parse<float>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    string IConvertible.ToString(IFormatProvider provider)
        => this.ToString();

    /// <inheritdoc />
    object IConvertible.ToType(Type conversionType, IFormatProvider provider)
    {
        var method = asMethods.GetOrAdd(conversionType, t => GetAsMethod(t, true));
        return method.Invoke(this, new[] { provider ?? CultureInfo.InvariantCulture });
    }

    /// <inheritdoc />
    ushort IConvertible.ToUInt16(IFormatProvider provider)
        => this.Parse<ushort>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    uint IConvertible.ToUInt32(IFormatProvider provider)
        => this.Parse<uint>(provider ?? CultureInfo.InvariantCulture);

    /// <inheritdoc />
    ulong IConvertible.ToUInt64(IFormatProvider provider)
        => this.Parse<ulong>(provider ?? CultureInfo.InvariantCulture);
}