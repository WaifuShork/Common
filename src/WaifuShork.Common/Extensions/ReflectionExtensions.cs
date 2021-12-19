
namespace WaifuShork.Common.Extensions;

using System.Reflection;
using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using WaifuShork.Common.QuickLinq;


public static class ReflectionExtensions
{
	public static string ToShortString(this MethodInfo method)
	{
		if (method == null)
		{
			throw new ArgumentNullException(nameof(method), "");
		}

		const int indentWidth = 4;
		var indent = new Func<int, string>(depth => new string(' ', indentWidth * depth));

		var parameters = method.GetParameters().SelectQ(p => $"{p.ParameterType.ToShortString()} {p.Name}");

		var accessModifiers = new[]
		{
			method.IsPublic ? "public" : "",
			method.IsAssembly ? "internal" : "",
			method.IsPrivate ? "private" : "",
			method.IsFamily ? "protected" : ""
		}.FirstQ(m => !string.IsNullOrWhiteSpace(m));

		var inheritanceModifiers = new[]
		{
			method.IsAbstract ? " abstract" : "",
			method.IsVirtual ? " virtual" : "",
			method.GetBaseDefinition() != method ? " override" : ""
		}.FirstOrDefaultQ(m => !string.IsNullOrWhiteSpace(m));

		var signature = new StringBuilder()
			.Append(method.DeclaringType?.FullName)
			.Append(" { ")
			.Append(accessModifiers)
			.Append(method.IsStatic ? " static" : "")
			.Append(inheritanceModifiers)
			.Append(method.GetCustomAttribute<AsyncStateMachineAttribute>() != null ? " async" : "")
			.Append($" {method.ReturnType.ToShortString()}")
			.Append($" {method.Name}")
			.Append($"({string.Join(", ", parameters)}) ").Append("{ ... }")
			.Append(" } ")
			.ToString();

		return signature;
	}

	public static string ToShortString(this Type type)
	{
		var codeDomProvider = CodeDomProvider.CreateProvider("C#");
		var typeReferenceExpression = new CodeTypeReferenceExpression(type);
		using var writer = new StringWriter();
		codeDomProvider.GenerateCodeFromExpression(typeReferenceExpression, writer, new CodeGeneratorOptions());
		return writer.GetStringBuilder().ToString();
	}
}