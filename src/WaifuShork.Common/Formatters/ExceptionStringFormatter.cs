namespace WaifuShork.Common.Formatters
{
	using System;
	using System.IO;
	using QuickLinq;
	using Extensions;
	using System.Text;
	using System.Linq;
	using System.Reflection;
	using System.Diagnostics;
	using System.Collections.Generic;

	/// <summary>
	/// A very nice new Exception format, that's incredibly readable, and easy to debug.
	/// </summary>
	public static class ExceptionStringFormatter
	{
		public static string Prettify(this Exception exception, ExceptionOrder order = ExceptionOrder.Descending, int indentWidth = 4)
		{
			switch (order)
			{
				case ExceptionOrder.Ascending:
					return string.Join(Environment.NewLine, exception.PrettifyCore(0, indentWidth).Reverse());
				case ExceptionOrder.Descending:
					return string.Join(Environment.NewLine, exception.PrettifyCore(0, indentWidth));
				default:
					throw new ArgumentOutOfRangeException(nameof(order), order, $"unsupported order {order}");
			}
		}
		
		private static IEnumerable<string> PrettifyCore(this Exception exception, int indent, int indentWidth)
		{
			var builder = new StringBuilder();

			var makeIndent = new Func<int, string>((depth) => new string(' ', indentWidth * (depth + indent)));

			builder.AppendLine($"{makeIndent(1)}{exception.GetType().Name}: \"{exception.Message}\"");

			if (exception is AggregateException)
			{
				builder.AppendLine($"{makeIndent(2)}InnerExceptions: \"{((AggregateException)exception).InnerExceptions.Count}\"");
			}

			foreach (var property in exception.GetPropertiesExcept<Exception>())
			{
				builder.AppendLine($"{makeIndent(1)}{property.Name}: \"{property.Value}\"");
			}

			foreach (var property in exception.GetData())
			{
				builder.AppendLine($"{makeIndent(1)}Data[{property.Key}]: \"{property.Value}\"");
			}

			builder.AppendLine($"{makeIndent(2)}StackTrace:");

			foreach (var stackTrace in exception.GetStackTrace() ?? Enumerable.Empty<StackFrame>())
			{
				builder.AppendLine($"{makeIndent(3)}{stackTrace.Caller} in \"{stackTrace.FileName}\" Ln {stackTrace.LineNumber}");
			}

			yield return builder.ToString();

			if (exception is AggregateException)
			{
				foreach (var subStrings in ((AggregateException)exception).InnerExceptions.Select(ex => ex.PrettifyCore(indent + 1, indentWidth)))
				{
					foreach (var subString in subStrings)
					{
						yield return subString;
					}
				}
			}
			else if (exception.InnerException != null)
			{
				foreach (var subString in exception.InnerException.PrettifyCore(indent + 1, indentWidth))
				{
					yield return subString;
				}
			}
		}
		

		public static IEnumerable<Property> GetPropertiesExcept<TException>(this Exception exception) where TException : Exception
		{
			var propertyFlags = BindingFlags.Instance | BindingFlags.Public;

			var properties = exception.GetType()
				.GetProperties(propertyFlags)
				.Except(typeof(TException).GetProperties(propertyFlags))
				.Select(p => new Property
				{
					Name = p.Name, 
					Value = p.GetValue(exception)
				})
				.Where(p => p.Value != null && !string.IsNullOrWhiteSpace(p.Value as string));
			
			return properties;
		}

		private static IEnumerable<Data> GetData(this Exception exception)
		{
			foreach (var key in exception.Data.Keys)
			{
				yield return new()
				{
					Key = key,
					Value = exception.Data[key]
				};
			}
		}

		private static IEnumerable<StackFrame> GetStackTrace(this Exception exception)
		{
			var stackTrace = new StackTrace(exception, true);
			var stackFrames = stackTrace.GetFrames();
			var result = stackFrames?.SelectQ(sf => new StackFrame
			{
				Caller = (sf.GetMethod() as MethodInfo)?.ToShortString() ?? "",
				FileName = Path.GetFileName(sf.GetFileName()),
				LineNumber = sf.GetFileLineNumber()
			});

			return result;
		}
	}

	public class Data
	{
		public object Key { get; init; }
		public object Value { get; init; }
	}

	public class Property
	{
		public string Name { get; init; }
		public object Value { get; init; }
	}

	public class ExceptionInfo
	{
		public Type ExceptionType { get; init; }
		public string ExceptionMessage { get; init; }
		public Dictionary<string, object> CustomProperties { get; init; }
		public StackFrame[] StackTrace { get; init; }
	}

	public class StackFrame
	{
		public string Caller { get; init; }
		public string FileName { get; init; }
		public int LineNumber { get; init; }
	}
}