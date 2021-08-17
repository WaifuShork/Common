namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatAccessViolationException : AccessViolationException
	{
		public NeatAccessViolationException(string message)
			: base(message) { }
		
		public NeatAccessViolationException(string message, Exception innerException) 
			: base(message, innerException) {}

		protected NeatAccessViolationException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}