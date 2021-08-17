namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatAggregateException : AggregateException
	{
		public NeatAggregateException(string message) 
			: base(message) {}
		
		public NeatAggregateException(string message, Exception innerException) 
			: base(message, innerException) {}
		
		public NeatAggregateException(IEnumerable<Exception> innerExceptions) 
			: base(innerExceptions) {}
		
		public NeatAggregateException(params Exception[] innerExceptions) 
			: base(innerExceptions) {}
		
		public NeatAggregateException(string message, IEnumerable<Exception> innerExceptions) 
			: base(message, innerExceptions) {}
		
		public NeatAggregateException(string message, Exception[] innerExceptions) 
			: base(message, innerExceptions) {}

		public NeatAggregateException(string paramName, string message, IEnumerable<Exception> innerExceptions) 
			: base($"{message} (Parameter '{paramName}')" , innerExceptions) {}
		
		protected NeatAggregateException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}