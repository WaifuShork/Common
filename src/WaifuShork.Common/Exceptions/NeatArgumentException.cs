namespace WaifuShork.Common.Exceptions
{ 
	using System;
	using Formatters;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatArgumentException : ArgumentException
	{
		public NeatArgumentException(string message) 
			: base(message) {}
		
		public NeatArgumentException(string message, Exception innerException) 
			: base(message, innerException) {}

		public NeatArgumentException(string paramName, string message, Exception innerException) 
			: base(message, paramName, innerException) {}
		
		public NeatArgumentException(string paramName, string message) 
			: base(message, paramName) {}
		
		protected NeatArgumentException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}