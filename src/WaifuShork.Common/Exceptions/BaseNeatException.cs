namespace WaifuShork.Common.Exceptions
{
	using System;
	using Formatters;

	[Serializable]
	public abstract class BaseNeatException : Exception
	{
		protected BaseNeatException(string message, Exception innerException)
			: base (message, innerException) {}
		
		protected BaseNeatException(string message) : base(message) {}

		public override string ToString()
		{
			return this.Format() ?? base.ToString();
		}
	}
}