using System;
using WaifuShork.Common.Math.Generic;

namespace WaifuShork.Common.Math.Object;

public class ObjectMultiplier : IObjectMultiplyOperators
{
	public static object? Multiply(object left, object right)
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
						return GenericOperators.Multiply((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((decimal)left, (decimal)right);
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
						return GenericOperators.Multiply((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Multiply((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Multiply((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Multiply((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Multiply((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Multiply((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Multiply((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Multiply((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Multiply((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Multiply((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Multiply((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Multiply((decimal)left, (decimal)right);
				}
				break;
			}
		}

		return null;
	}
}