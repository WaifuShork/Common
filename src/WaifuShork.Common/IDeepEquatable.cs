namespace WaifuShork.Common
{
	using System;

	/// <summary>
	/// Provides the implementation for DeepEquals,
	/// allowing you to explicitly separate reference equals, and deepl equals on your types.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IDeepEquatable<in T>
	{
		bool DeepEquals(T other);
	}
}