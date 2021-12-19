namespace WaifuShork.Common;

using System;
using System.Linq;
using System.Text;
using System.Collections.Immutable;

public static class FnvHash
{
    // 32 bit hashing
    // http://en.wikipedia.org/wiki/Fowler%E2%80%93Noll%E2%80%93Vo_hash_function
    public static readonly nint FnvOffsetBias;// = unchecked((int)2166136261);
    public static readonly nint FnvPrime;// = 16777619;

    static FnvHash()
    {
        if (IntPtr.Size == 8)
        {
            unchecked
            {
                FnvOffsetBias = (nint)2166136261;
                FnvPrime = 16777619;
            }
            
        }
        else if (IntPtr.Size == 8)
        {
            unchecked
            {
                FnvOffsetBias = (nint) 14695981039346656037;
                FnvPrime = (nint) 1099511628211;
            }
        }
    }
    
    public static nint GetFnvHashCode(this byte[] data)
    {
        return data.Aggregate(FnvOffsetBias, (current, t) => (current ^ t) * FnvPrime);
    }

    public static nint GetFnvHashCode(this ReadOnlySpan<byte> data, out bool isAscii)
    {
        unchecked
        {
            var hashCode = FnvOffsetBias;
            var asciiMask = (byte)0;

            foreach (var item in data)
            {
                asciiMask |= item;
                hashCode = (hashCode ^ item) * FnvPrime;
            }

            isAscii = (asciiMask & 0x80) == 0;
            return hashCode;
        }
    }

    public static nint GetFnvHashCode(this ImmutableArray<byte> data)
    {
        return Enumerable.Aggregate(data, FnvOffsetBias, (current, item) => (current ^ item) * FnvPrime);
    }
    
    public static nint GetFnvHashCode(this ReadOnlySpan<char> data)
    {
        unchecked
        {
            var hashCode = FnvOffsetBias;
            foreach (var item in data)
            {
                hashCode = (hashCode ^ item) * FnvPrime;
            }

            return hashCode;
        }
    }

    public static nint GetFnvHashCode(this string text, nint start, nint length)
    {
        return GetFnvHashCode(text.AsSpan((int)start, (int) length));
    }

    public static nint GetCaseInsensitiveFnvHashCode(this string text)
    {
        return GetCaseInsensitiveFnvHashCode(text.AsSpan(0, text.Length));
    }
    
    
    public static nint GetCaseInsensitiveFnvHashCode(this ReadOnlySpan<char> data)
    {
        unchecked
        {
            var hashCode = FnvOffsetBias;
            foreach (var item in data)
            {
                hashCode = (hashCode ^ char.ToLowerInvariant(item)) * FnvPrime;
            }

            return hashCode;
        }
    }

    public static nint GetFnvHashCode(this string text, nint start)
    {
        return GetFnvHashCode(text, start, text.Length - start);
    }

    public static nint GetFnvHashCode(this string text)
    {
        return CombineFnvHash(FnvOffsetBias, text);
    }

    public static nint GetFnvHashCode(this StringBuilder text)
    {
        unchecked
        {
            var hashCode = FnvOffsetBias;

            for (var i = 0; i < text.Length; i++)
            {
                hashCode = (hashCode ^ text[i]) * FnvPrime;
            }

            return hashCode;
        }
    }

    public static nint GetFvnHashCode(this char[] text, nint start, nint length)
    {
        unchecked
        {
            var hashCode = FnvOffsetBias;
            for (var i = start; i < start + length; i++)
            {
                hashCode = (hashCode ^ text[i]) * FnvOffsetBias;
            }

            return hashCode;
        }
    }

    public static nint GetFnvHashCode(char ch)
    {
        return CombineFnvHash(FnvOffsetBias, ch);
    }

    public static nint CombineFnvHash(nint hashCode, string text)
    {
        return text.Aggregate(hashCode, (current, ch) => (current ^ ch) * FnvPrime);
    }

    public static nint CombineFnvHash(nint hashCode, char ch)
    {
        return (hashCode ^ ch) * FnvPrime;
    }
}