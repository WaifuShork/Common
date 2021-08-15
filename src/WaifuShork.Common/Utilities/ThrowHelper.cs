namespace WaifuShork.Common.Utilities
{
	using System;
	using System.Diagnostics.CodeAnalysis;

	public static class ThrowHelper
	{
		[DoesNotReturn]
		internal static Exception ArgumentNull(string input)
		{
			return new ArgumentNullException(input);
		}

		[DoesNotReturn]
		internal static Exception ArgumentOutOfRange(string input)
		{
			return new ArgumentOutOfRangeException(input);
		}

		[DoesNotReturn]
		internal static Exception MoreThanOneElement()
		{
			return new InvalidOperationException("Sequence contains more than one element");
		}

		[DoesNotReturn]
		internal static Exception MoreThanOneMatch()
		{
			return new InvalidOperationException("Sequence contains more than one matching element");
		}

		[DoesNotReturn]
		internal static Exception NoElements()
		{
			return new InvalidOperationException("Sequence contains no elements");
		}

		[DoesNotReturn]
		internal static Exception NoMatch()
		{
			return new InvalidOperationException("Sequence contains no matching element");
		}

		[DoesNotReturn]
		internal static Exception NotSupported()
		{
			return new NotSupportedException();
		}
		
		
		[DoesNotReturn]
		public static Exception ThrowException(string paramName, string message = null)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				message = "No exception message has been defined.";
			}
			
			throw new Exception($"(ParamName: {paramName})\n" +
			                    $"Message: {message}");
		}

		[DoesNotReturn]
		public static void ThrowArgumentNullException(string paramName, string message = null)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				message = "No exception message has been defined.";
			}
			
			throw new ArgumentNullException(paramName, message);
		}

		[DoesNotReturn]
		public static void ThrowArgumentException(string paramName, string message = null)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				message = "No exception message has been defined.";
			}
			
			throw new ArgumentException(message, paramName);
		}

		[DoesNotReturn]
		public static void ThrowArgumentOutOfRangeException(string paramName, string message = null)
		{
			if (string.IsNullOrWhiteSpace(message))
			{
				message = "No exception message has been defined.";
			}

			throw new ArgumentOutOfRangeException(paramName, message);
		}
	}
}