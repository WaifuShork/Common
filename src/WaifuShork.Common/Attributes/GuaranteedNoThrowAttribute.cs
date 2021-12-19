using System;

namespace WaifuShork.Common.Attributes;

[AttributeUsage(AttributeTargets.Method | 
                AttributeTargets.Delegate | 
                AttributeTargets.Property |
                AttributeTargets.Constructor)]
public class GuaranteedNoThrowAttribute : Attribute
{
	
}