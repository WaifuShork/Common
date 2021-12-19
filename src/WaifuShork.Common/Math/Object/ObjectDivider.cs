using System;
using WaifuShork.Common.Math.Generic;

namespace WaifuShork.Common.Math.Object;

public class ObjectDivider : IObjectDivisionOperators
{
	public static object? Divide(object left, object right)
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
						return GenericOperators.Divide((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((decimal)left, (decimal)right);
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
						return GenericOperators.Divide((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Divide((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Divide((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Divide((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Divide((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Divide((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Divide((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Divide((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Divide((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Divide((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Divide((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Divide((decimal)left, (decimal)right);
				}
				break;
			}
		}

		return null;
	}
}