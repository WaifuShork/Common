using System;

namespace WaifuShork.Common.Math.Generic;

public static class GenericOperators
{
	public static T Add<T>(T left, T right) 
    	where T : struct, IAdditionOperators<T, T, T>
    {
    	return left + right;
    }

    public static T Subtract<T>(T left, T right)
    	where T : struct, ISubtractionOperators<T, T, T>
    {
    	return left - right;
    }	
    
    public static T Divide<T>(T left, T right)
    	where T : struct, IDivisionOperators<T, T, T>
    {
    	return left / right;
    }

    public static T Multiply<T>(T left, T right)
    	where T : struct, IMultiplyOperators<T, T, T>
    {
    	return left * right;
    }

    public static T Mod<T>(T left, T right)
    	where T : struct, IModulusOperators<T, T, T>
    {
    	return left % right;
    }

    public static T BitwiseLogicalOr<T>(T left, T right)
    	where T : struct, IBitwiseOperators<T, T, T>
    {
    	return left | right;
    }

    public static T BitwiseExclusiveOr<T>(T left, T right)
    	where T : struct, IBitwiseOperators<T, T, T>
    {
    	return left ^ right;
    }

    public static T BitwiseAnd<T>(T left, T right)
    	where T : struct, IBitwiseOperators<T, T, T>
    {
    	return left & right;
    }
}