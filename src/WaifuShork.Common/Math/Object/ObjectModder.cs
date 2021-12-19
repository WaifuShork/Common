using System;
using WaifuShork.Common.Math.Generic;

namespace WaifuShork.Common.Math.Object;

public class ObjectModder : IObjectModulusOperators
{
	public static object? Modulo(object left, object right)
	{
		ArgumentNullException.ThrowIfNull(left, "left != null");
		ArgumentNullException.ThrowIfNull(right, "right != null");

		var leftCode = Type.GetTypeCode(left.GetType());
		var rightCode = Type.GetTypeCode(right.GetType());
		
		switch (leftCode)
		{
			case TypeCode.SByte:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((decimal)left, (decimal)right);
				}
				break;
			}
		}
		
		// RIGHT CODE
		switch (rightCode)
		{
			case TypeCode.SByte:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Mod((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Mod((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Mod((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Mod((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Mod((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Mod((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Mod((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Mod((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Mod((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Mod((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Mod((decimal)left, (decimal)right);
				}
				break;
			}
		}

		return null;
	}
}