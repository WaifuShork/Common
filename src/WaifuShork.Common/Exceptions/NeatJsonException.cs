namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;
	using System.Text.Json;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatJsonException : JsonException
	{
		public NeatJsonException(string message, string path, long lineNumber, long bytePositionInLine, Exception innerException) 
			: base(message, path, lineNumber, bytePositionInLine, innerException) {}
		
		public NeatJsonException(string message, string path, long lineNumber, long bytePositionInLine) 
			: base(message, path, lineNumber, bytePositionInLine) {}
		
		public NeatJsonException(string message, Exception innerException) 
			: base(message, innerException) {}
		
		public NeatJsonException(string message) 
			: base(message) {}

		protected NeatJsonException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}