namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatArgumentNullException : ArgumentNullException
	{
		public NeatArgumentNullException() 
			: base() {}
		
		public NeatArgumentNullException(string paramName) 
			: base(paramName) {}
		
		public NeatArgumentNullException(string message, Exception innerException) 
			: base(message, innerException) {}
		
		public NeatArgumentNullException(string paramName, string message) 
			: base(paramName, message) {}

		protected NeatArgumentNullException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}