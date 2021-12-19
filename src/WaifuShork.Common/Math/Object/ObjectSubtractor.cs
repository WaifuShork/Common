using System;
using WaifuShork.Common.Math.Generic;

namespace WaifuShork.Common.Math.Object;

public class ObjectSubtractor : IObjectSubtractionOperators
{
	public static object? Subtract(object left, object right)
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
						return GenericOperators.Subtract((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((decimal)left, (decimal)right);
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
						return GenericOperators.Subtract((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Subtract((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Subtract((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Subtract((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Subtract((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Subtract((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Subtract((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Subtract((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Subtract((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Subtract((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Subtract((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Subtract((decimal)left, (decimal)right);
				}
				break;
			}
		}

		return null;
	}
}