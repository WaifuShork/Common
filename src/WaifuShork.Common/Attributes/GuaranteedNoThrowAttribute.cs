namespace WaifuShork.Common.Attributes;
using System;

[AttributeUsage(AttributeTargets.Method | 
                AttributeTargets.Delegate | 
                AttributeTargets.Property |
                AttributeTargets.Constructor)]
public class GuaranteedNoThrowAttribute : Attribute
{
	
}