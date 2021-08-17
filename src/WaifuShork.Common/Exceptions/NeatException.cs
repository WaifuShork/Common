namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;
	using System.Runtime.Serialization;

	[Serializable]
	public class NeatException : Exception
	{
		public NeatException() : base() {}
		public NeatException(string message) : base(message) {}
		public NeatException(string message, Exception inner) : base(message, inner) {}

		protected NeatException(SerializationInfo info, StreamingContext context) 
			: base(info, context) {}
		
		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}