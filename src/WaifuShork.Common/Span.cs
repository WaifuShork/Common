using System;
using JetBrains.Annotations;

namespace WaifuShork.Common;

public struct Span<T>
{
	private byte[] m_array;
	private int m_start;
	private int m_length;

	public Span(byte[] bytes, int index, int length)
	{
		m_array = bytes;
		m_start = index;
		m_length = length;
	}

	public int Length => m_length;

	public byte this[int index]
	{
		get => m_array[m_start + index];
		set => m_array[m_start + index] = value;
	}

	public uint ReadUInt16()
	{
		return BitConverter.ToUInt16(m_array, m_start);
	}

	public unsafe void Write(uint value)
	{
		fixed (byte* ptr = m_array)
		{
			*(uint*)ptr = value;
		}
	}

	public unsafe void Write(ushort value)
	{
		fixed (byte* ptr = m_array)
		{
			*(uint*)ptr = value;
		}
	}

	public Span<byte> Slice(int index)
	{
		return new Span<byte>(m_array, m_start + index, m_length - index);
	}

	public uint ReadUInt32()
	{
		return BitConverter.ToUInt32(m_array, m_start);
	}

	public Span<byte> Slice(int index, int length)
	{
		return new Span<byte>(m_array, m_start + index, length);
	}
}