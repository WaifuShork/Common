using Xunit;
using System.Linq;
using System.Threading;
using Xunit.Abstractions;
using System.Collections.Generic;
using WaifuShork.Common.QuickLinq;
using WaifuShork.Common.Extensions;
using System.Runtime.InteropServices;

namespace WaifuShork.Common.Tests
{
	public class ConcurrentListTests
	{
		private readonly ITestOutputHelper _output;
		
		public ConcurrentListTests(ITestOutputHelper output)
		{
			this._output = output;
		}

		[Fact]
		public void Tests_Concurrent_WorksAsExpected()
		{
			var list = new List<int>(Enumerable.Range(0, 100));
			var concurrentList = new ConcurrentList<int>(Enumerable.Range(0, 100));

			var item1 = list[12];
			var item2 = concurrentList[12];
			
			Assert.Equal(item1, item2);
			Assert.Equal(list.Count, concurrentList.Count);
		}

		[Fact]
		public void Tests_Concurrent_TryAdd()
		{
			var concurrentList = new ConcurrentList<int>(Enumerable.Range(0, 100));

			if (concurrentList.TryAdd(12))
			{
				Assert.Equal(101, concurrentList.Count);	
			}
			else
			{
				Assert.Equal(100, concurrentList.Count);
			}
		}
		
		[Fact]
		public void Test_Concurrent_ItemsNotNull()
		{
			var concurrentList = new ConcurrentList<object>();
			for (var i = 0; i < 100; i++)
			{
				concurrentList[i] = new object();
			}

			foreach (var item in concurrentList)
			{
				Assert.NotNull(item);
			}
		}

		[Fact]
		public void Test_AddingItems()
		{
			var list = new ConcurrentList<string>();
			list.Add("Hello world");
			list.Add("Goodbye world");
			list.Add("I'm doing fine thanks for asking");

			for (var i = 0; i < 20; i++)
			{
				list.Add($"Number: {i * 20 + 12}");
			}
			
			Assert.NotNull(list);

			Assert.NotEmpty(list);
			Assert.Equal(23, list.Count);
		}
	}
}