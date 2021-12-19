namespace WaifuShork.Common.Utilities;

using System.Collections.Generic;

public class ReferenceEqualityComparer : EqualityComparer<object>
{
	public override bool Equals(object x, object y)
	{
		return ReferenceEquals(x, y);
	}

	public override int GetHashCode(object obj)
	{
		return obj.GetHashCode();
	}
}