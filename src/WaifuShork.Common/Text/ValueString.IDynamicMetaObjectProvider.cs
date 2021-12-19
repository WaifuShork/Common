using System;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using JetBrains.Annotations;

namespace WaifuShork.Common.Text;

public partial struct ValueString : IDynamicMetaObjectProvider
{
	DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter)
	{
		return new ValueStringMetaObject(parameter, this);
	}

	private sealed class ValueStringMetaObject : DynamicMetaObject
	{
		private static readonly TypeCache<MethodInfo?> asMethods = new();

		public ValueStringMetaObject(Expression expression, ValueString value)
			: base(expression, BindingRestrictions.Empty, value) { }

		public override DynamicMetaObject BindConvert(ConvertBinder binder)
		{
			var restrictions = BindingRestrictions.GetTypeRestriction(Expression, LimitType);
			if (binder.Type == LimitType)
			{
				return binder.FallbackConvert(new DynamicMetaObject(Expression, restrictions, Value ?? new object()));
			}

			var method = asMethods.GetOrAdd(binder.Type, t => GetAsMethod(t, false));
			var call = Expression.Call(Expression.Convert(Expression, LimitType), method!);
			return new DynamicMetaObject(call, restrictions);
		}
	}
}