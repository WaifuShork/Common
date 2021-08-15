namespace WaifuShork.Common
{
	using System;

	public interface IDeepEquatable<T> : IEquatable<T>
	{
		bool DeepEquals(T other);
	}
}