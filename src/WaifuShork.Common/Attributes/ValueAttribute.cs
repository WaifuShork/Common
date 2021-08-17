namespace WaifuShork.Common.Attributes
{
	using System;

	[AttributeUsage(AttributeTargets.All, AllowMultiple = false)]
	public sealed class ValueAttribute : Attribute
	{
		public ValueAttribute(string value)
		{
			this.Value = value;
		}
		
		public string Value { get; }
	}
}