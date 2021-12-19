using System;
using System.Runtime.Serialization;
using System.Security;

namespace WaifuShork.Common.Text;

[Serializable]
public partial struct ValueString : ISerializable
{
	private ValueString(SerializationInfo info, StreamingContext context)
	{
		m_value = info.GetString(nameof(m_value)) ?? string.Empty;
	}
	
	[SecurityCritical]
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(nameof(m_value), m_value);
	}
}