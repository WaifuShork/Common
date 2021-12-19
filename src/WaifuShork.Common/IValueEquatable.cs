namespace WaifuShork.Common;

/// <summary>
/// Provides the implementation for DeepEquals,
/// allowing you to explicitly separate reference equals, and deepl equals on your types.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IValueEquatable<in T>
{
	bool ValueEquals(T other);
}