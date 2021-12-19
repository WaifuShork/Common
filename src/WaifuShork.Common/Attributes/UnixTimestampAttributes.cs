namespace WaifuShork.Common.Attributes;

using System;
	
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class UnixInSecondsAttribute : Attribute { }
	
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
public class UnixInMillisecondsAttribute : Attribute { }