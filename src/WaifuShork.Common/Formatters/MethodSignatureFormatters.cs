namespace WaifuShork.Common.Formatters
{
	using QuickLinq;
	using System.Text;
	using System.Reflection;

	/// <summary>
	/// Various formatters for pretty printing methods in a very human readable format.
	/// </summary>
	public static class MethodSignatureFormatters
	{
		/// <summary>
		/// Generic formatter to print a method signature in string format 
		/// </summary>
		/// <example>
		///	public int Sum(int x, int y) 
		/// </example>
		/// <param name="method">The method that is to be formatted</param>
		/// <returns>A pretty string of the method signature</returns>
		public static string Format(this MethodBase method)
		{
			if (method is MethodInfo methodInfo)
			{
				var accessor = "private";
				
				if (methodInfo.IsPublic)
				{
					accessor = "public";
				}

				return new StringBuilder()
					.Append(accessor).Append(' ')
					.Append(methodInfo.IsStatic ? "static " : "")
					.Append(methodInfo.ReturnType.FullName)
					.Append(' ').Append(methodInfo.DeclaringType?.FullName)
					.Append('.').Append(methodInfo.Name)
					.Append('(')
					.Append(string.Join(", ", methodInfo.GetParameters().SelectQ(p => p.ParameterType.FullName + " " + p.Name)))
					.Append(')')
					.ToString();
			}

			return method.Name;
		}
	}
}