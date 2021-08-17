namespace WaifuShork.Common.Attributes
{
	using System;
	
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TimeSpanInSecondsAttribute : Attribute { }
	
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
	public class TimeSpanInMillisecondsAttribute : Attribute { }
}