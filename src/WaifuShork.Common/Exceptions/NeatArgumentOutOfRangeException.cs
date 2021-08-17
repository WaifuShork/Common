namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatArgumentOutOfRangeException : ArgumentOutOfRangeException
	{
		public NeatArgumentOutOfRangeException() 
			: base() {}
		
		public NeatArgumentOutOfRangeException(string paramName) 
			: base(paramName) {}
		
		public NeatArgumentOutOfRangeException(string paramName, string message) 
			: base(paramName, message) {}
		
		public NeatArgumentOutOfRangeException(string paramName, string message, object actualValue) 
			: base(paramName, actualValue, message) {}

		public NeatArgumentOutOfRangeException(string message, Exception innerException) 
			: base(message, innerException) {}

		protected NeatArgumentOutOfRangeException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}