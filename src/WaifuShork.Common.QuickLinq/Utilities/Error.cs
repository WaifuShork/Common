namespace Wyvern.QuickLinq.Utilities
{
	using System;
	
	internal static class Error
	{
		internal static Exception ArgumentNull(string input)
		{
			return new ArgumentNullException(input);
		}

		internal static Exception ArgumentOutOfRange(string input) { return new ArgumentOutOfRangeException(input); }

		internal static Exception MoreThanOneElement()
		{
			return new InvalidOperationException("Sequence contains more than one element");
		}

		internal static Exception MoreThanOneMatch()
		{
			return new InvalidOperationException("Sequence contains more than one matching element");
		}

		internal static Exception NoElements()
		{
			return new InvalidOperationException("Sequence contains no elements");
		}

		internal static Exception NoMatch()
		{
			return new InvalidOperationException("Sequence contains no matching element");
		}

		internal static Exception NotSupported()
		{
			return new NotSupportedException();
		}
	}
}