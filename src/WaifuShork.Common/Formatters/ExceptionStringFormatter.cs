namespace WaifuShork.Common.Formatters
{
	using System;
	using QuickLinq;
	using Extensions;
	using System.Text;
	using System.Linq;
	using System.Dynamic;
	using System.Diagnostics;
	using System.Globalization;
	using System.Collections.Generic;

	/// <summary>
	/// A very nice new Exception format, that's incredibly readable, and easy to debug.
	/// </summary>
	public static class ExceptionStringFormatter 
	{
		private const char CurlyBracketLeft = '{';
		private const char CurlyBracketRight = '}';
		private const char SquareBracketLeft = '[';
		private const char SquareBracketRight = ']';
		private const string RaquoSpacer = " » ";
		private const int IndentWidth = 3;
		
		/// <summary>
		/// Formats an exception to be *exceptionally* pretty and easy to read.
		/// </summary>
		/// <remarks>
		///	This exception currently uses "dynamic" and "ExpandoObject" to easily make this possible.
		/// I plan to fully rework this into a custom solution called "NeatException" or "Neatceptions".
		/// Please provide an issue or PR if you have any ideas on improving for now.
		/// </remarks>
		/// <param name="exception">The exception to be formatted</param>
		/// <typeparam name="TException">The type of exception that will be formatted</typeparam>
		/// <returns>A pretty exception, with all of the same data that was in the original exception, but much easier to read.</returns>
		public static string Format<TException>(this TException exception) where TException : Exception
		{
			var exceptionInfos = GetExceptionInfos(exception).Reverse();
			
			var exceptionString = new StringBuilder();
			foreach (var exceptionInfo in exceptionInfos)
			{
				var exceptionName = exceptionInfo.ExceptionType.Name as string;
				var exceptionMessage = exceptionInfo.ExceptionMessage as string;
				
				exceptionString
					.Append(exceptionName).Append(RaquoSpacer)
					.Append(exceptionMessage)
					.Append($" [{DateTime.UtcNow.ToString("HH:m:s tt zzz", DateTimeFormatInfo.CurrentInfo)}]")
					.AppendLine();

				exceptionString.Append(CurlyBracketLeft).AppendLine();
				
				// format properties
				exceptionString.Append(Indent(1)).Append("ExtraInfo:").AppendLine();
				exceptionString.Append(Indent(1)).Append(SquareBracketLeft).AppendLine();
				var customProperties = (IDictionary<string, object>)exceptionInfo.CustomProperties;
				foreach (var (key, value) in customProperties)
				{
					exceptionString
						.Append(Indent(2))
						.Append($"{key}: ").Append($"\"{value}\"")
						.AppendLine();
				}

				exceptionString.Append(Indent(1)).Append(SquareBracketRight).AppendLine();

				exceptionString.Append(Indent(1)).Append("StackTrace:").AppendLine();
				exceptionString.Append(Indent(1)).Append(SquareBracketLeft).AppendLine();

				foreach (var stackFrame in exceptionInfo.StackTrace)
				{
					var lineNumber = stackFrame.LineNumber as int?;
					var callerSignature = stackFrame.CallerSignature as string;
					var fileName = stackFrame.FileName as string;
					
					exceptionString
						.Append(Indent(2))
						.Append($"(Line:{lineNumber})").Append(RaquoSpacer)
						.Append(callerSignature).Append(RaquoSpacer)
						.Append($"{fileName}:{lineNumber}")
						.AppendLine();
				}

				exceptionString.Append(Indent(1)).Append(SquareBracketRight).AppendLine();
				exceptionString.Append(CurlyBracketRight).AppendLine();
			}

			return exceptionString.ToString();
		}
		
		private static IEnumerable<dynamic> GetExceptionInfos<TException>(TException exceptionSource) where TException : Exception
		{
			foreach (var exception in exceptionSource.AsEnumerable())
			{
				dynamic exceptionInfo = new ExpandoObject();
				exceptionInfo.ExceptionType = exception.GetType();
				exceptionInfo.ExceptionMessage = exception.Message;

				exceptionInfo.CustomProperties = new ExpandoObject() as dynamic;
				foreach (var (key, value) in exception.GetCustomProperties())
				{
					((IDictionary<string, object>)exceptionInfo.CustomProperties)[key] = value;
				}

				var stackTrace = new StackTrace(exception, true);
				var stackFrames = stackTrace.GetFrames();

				exceptionInfo.StackTrace = stackFrames.SelectQ(sf =>
				{
					dynamic stackFrame = new ExpandoObject();
					stackFrame.CallerSignature = sf.GetMethod().Format();
					stackFrame.FileName = sf.GetFileName();
					stackFrame.LineNumber = sf.GetFileLineNumber();
					return stackFrame;
				});

				yield return exceptionInfo;
			}
		}

		private static string Indent(int depth)
		{
			return string.Empty.PadLeft(IndentWidth * depth);
		}
	}
}