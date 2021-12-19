using System;
using WaifuShork.Common.Math.Generic;

namespace WaifuShork.Common.Math.Object;

public class ObjectAdder : IObjectAdditionOperators
{
	public static object? Add(object left, object right)
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
						return GenericOperators.Add((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (rightCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Add((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((decimal)left, (decimal)right);
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
						return GenericOperators.Add((sbyte)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((sbyte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((sbyte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((sbyte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((sbyte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((sbyte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((sbyte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((sbyte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((sbyte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((sbyte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((sbyte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Byte:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((byte)left, (byte)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((byte)left, (short)(byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((byte)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((byte)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((byte)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((byte)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((byte)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((byte)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((byte)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((byte)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((byte)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((short)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((short)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((short)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((short)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((short)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((short)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((short)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((short)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((short)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((short)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((short)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt16:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((ushort)left, (int)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((ushort)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((ushort)left, (int) (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((ushort)left, (int)(ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((ushort)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((ushort)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((ushort)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((ushort)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((ushort)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((ushort)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((ushort)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((int)left, (sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((int)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((int)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((int)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((int)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((int)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((int)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((int)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((int)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((int)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((int)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt32:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((uint)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((uint)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((uint)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((uint)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((uint)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((uint)left, (long)(uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((uint)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((uint)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((uint)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((uint)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((uint)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Int64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((long)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((long)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((long)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((long)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((long)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((long)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((long)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((long)left, (long)(ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((long)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((long)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((long)left, (decimal)right);
				}
				break;
			}
			case TypeCode.UInt64:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((ulong)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((ulong)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((ulong)left, (uint)(short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((ulong)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((ulong)left, (uint) (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((ulong)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((ulong)left, (ulong) (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((ulong)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((ulong)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((ulong)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((ulong)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Single:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((float)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((float)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((float)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((float)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((float)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((float)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((float)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((float)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((float)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((float)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((decimal)(float)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Double:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((double)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((double)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((double)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((double)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((double)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((double)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((double)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((double)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((double)left, (float)right);
					case TypeCode.Double:
						return GenericOperators.Add((double)left, (double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((decimal)(double)left, (decimal)right);
				}
				break;
			}
			case TypeCode.Decimal:
			{
				switch (leftCode)
				{
					case TypeCode.SByte:
						return GenericOperators.Add((decimal)left, (ushort)(sbyte)right);
					case TypeCode.Byte:
						return GenericOperators.Add((decimal)left, (byte)right);
					case TypeCode.Int16:
						return GenericOperators.Add((decimal)left, (short)right);
					case TypeCode.UInt16:
						return GenericOperators.Add((decimal)left, (ushort)right);
					case TypeCode.Int32:
						return GenericOperators.Add((decimal)left, (int)right);
					case TypeCode.UInt32:
						return GenericOperators.Add((decimal)left, (uint)right);
					case TypeCode.Int64:
						return GenericOperators.Add((decimal)left, (long)right);
					case TypeCode.UInt64:
						return GenericOperators.Add((decimal)left, (ulong)right);
					case TypeCode.Single:
						return GenericOperators.Add((decimal)left, (decimal)(float)right);
					case TypeCode.Double:
						return GenericOperators.Add((decimal)left, (decimal)(double)right);
					case TypeCode.Decimal:
						return GenericOperators.Add((decimal)left, (decimal)right);
				}
				break;
			}
		}

		return null;
	}
}