namespace WaifuShork.Common.Extensions
{
	using System;
	using QuickLinq;
	using System.Linq;
	using System.Reflection;
	using System.Collections.Generic;

	public static class ExceptionExtensions
	{
		private static readonly HashSet<string> _exceptionPropertyNames 
			= new(typeof(Exception).GetProperties(BindingFlags.Instance | BindingFlags.Public).SelectQ(p => p.Name));

		/// <summary>
		/// Traverses the entire stack trace to collect every last exception message. 
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		public static IEnumerable<string> GetAllMessages(this Exception exception)
		{
			if (exception == null)
			{
				yield break;
			}

			var innerExceptions = Enumerable.Empty<Exception>();

			if (exception is AggregateException && ((AggregateException)exception).InnerExceptions.Any())
			{
				innerExceptions = ((AggregateException)exception).InnerExceptions;
			}
			else if (exception.InnerException != null)
			{
				innerExceptions = new[] { exception.InnerException };
			}

			foreach (var innerException in innerExceptions)
			{
				foreach (var message in innerException.GetAllMessages())
				{
					yield return message;
				}
			}
		}
		
		/// <summary>
		/// Gets all the custom properties that live on the exception type
		/// </summary>
		/// <param name="exception"></param>
		/// <typeparam name="TException"></typeparam>
		/// <returns></returns>
		public static IDictionary<string, object> GetCustomProperties<TException>(this TException exception)
			where TException : Exception
		{
			var currentExceptionProperties = exception.GetType()
				.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
				.WhereQ(p => !_exceptionPropertyNames.Contains(p.Name));

			var result = currentExceptionProperties.ToDictionary(property => 
				property.Name, 
				property => property.GetValue(exception));

			return result;
		}

		/// <summary>
		/// Converts an exception (and every inner exception) into an enumerable object,
		/// you'll almost never need this. This purely exists for the ExceptionFormatter
		/// </summary>
		/// <param name="exception"></param>
		/// <returns></returns>
		public static IEnumerable<Exception> AsEnumerable(this Exception exception)
		{
			var currentException = exception;
			do
			{
				yield return currentException;
				currentException = currentException.InnerException;
			} while (currentException != null);
		}
	}
}