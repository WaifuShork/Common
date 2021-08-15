namespace Wyvern.QuickLinq.Utilities
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.CompilerServices;

	internal sealed class ComparerReverser<T> : IComparer<T> 
	{
		private readonly IComparer<T> _wrappedComparer;

		public ComparerReverser(IComparer<T> wrappedComparer) 
		{
			this._wrappedComparer = wrappedComparer;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y) 
		{
			return this._wrappedComparer.Compare(y, x);
		}
	}
	
	internal static class ComparerExtensions 
	{

		// Lets us reverse a comparer with comparer.Reverse();
		public static IComparer<T> Reverse<T>(this IComparer<T> comparer) 
		{
			return new ComparerReverser<T>(comparer);
		}
	}

	internal sealed class LambdaComparer<T, U> : IComparer<T> 
	{
		private readonly IComparer<U> _comparer;
		private readonly Func<T, U> _selector;

		public LambdaComparer(Func<T, U> selector, IComparer<U> comparer) 
		{
			this._comparer = comparer;
			this._selector = selector;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y) 
		{
			return this._comparer.Compare(this._selector(x), this._selector(y));
		}
	}

	internal sealed class ReverseLambdaComparer<T, U> : IComparer<T> 
	{
		private readonly IComparer<U> comparer;
		private readonly Func<T, U> selector;

		public ReverseLambdaComparer(Func<T, U> selector, IComparer<U> comparer) 
		{
			this.comparer = comparer;
			this.selector = selector;
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public int Compare(T x, T y) 
		{
			return comparer.Compare(selector(y), selector(x));
		}
	}
}