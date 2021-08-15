using Xunit;
using System.Linq;
using Xunit.Abstractions;
using System.Collections.Generic;
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
		public void Test_Concurrent_ItemsNotNull()
		{
			var concurrentList = new ConcurrentList<int?>();
			for (var i = 0; i < 100; i++)
			{
				concurrentList[i] = i;
			}

			foreach (var item in concurrentList)
			{
				Assert.NotNull(item);
			}
		}

		private class Tester
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public int Age { get; set; }
		}
		
		[Fact]
		public void Test_DeepClone_Object()
		{
			var test = new Tester
			{
				FirstName = "John",
				LastName = "Doe",
				Age = 53
			};

			var clone = test.DeepClone();

			Assert.Equal(test.FirstName, clone.FirstName);
			Assert.Equal(test.LastName, clone.LastName);
			Assert.Equal(test.Age, clone.Age);

			test.FirstName = "Doe";
			test.LastName = "John";
			Assert.NotEqual(test.FirstName, clone.FirstName);
			Assert.NotEqual(test.LastName, clone.LastName);
			
			// Ensure References/Addresses aren't equal 
			var testHandle = GCHandle.Alloc(test, GCHandleType.WeakTrackResurrection);
			var cloneHandle = GCHandle.Alloc(clone, GCHandleType.WeakTrackResurrection);
			Assert.NotEqual(testHandle, cloneHandle);
			
			var testAddress = GCHandle.ToIntPtr(testHandle).ToInt64();
			var cloneAddress = GCHandle.ToIntPtr(cloneHandle).ToInt64();
			Assert.NotEqual(testAddress, cloneAddress);
			
			var testFirstHandler = GCHandle.Alloc(test.LastName, GCHandleType.WeakTrackResurrection);
			var cloneFirstHandler = GCHandle.Alloc(clone.LastName, GCHandleType.WeakTrackResurrection);
			Assert.NotEqual(testFirstHandler, cloneFirstHandler);
			
			var testFirstAddress = GCHandle.ToIntPtr(testFirstHandler).ToInt64();
			var cloneFirstAddress = GCHandle.ToIntPtr(cloneFirstHandler).ToInt64();
			Assert.NotEqual(testFirstAddress, cloneFirstAddress);
			
			var testLastHandler = GCHandle.Alloc(test.LastName, GCHandleType.WeakTrackResurrection);
			var cloneLastHandler = GCHandle.Alloc(clone.LastName, GCHandleType.WeakTrackResurrection);
			Assert.NotEqual(testLastHandler, cloneLastHandler);
			
			var testLastAddress = GCHandle.ToIntPtr(testLastHandler).ToInt64();
			var cloneLastAddress = GCHandle.ToIntPtr(cloneLastHandler).ToInt64();
			
			Assert.NotEqual(testLastAddress, cloneLastAddress);
		}

		[Fact]
		public void Test_RingBuffer()
		{
			var buffer = new RingBuffer<int>(100);
			for (var i = 0; i < buffer.Capacity; i++)
			{
				buffer.Add(i);
			}

			var clone = buffer.DeepClone();

			Assert.Equal(buffer, clone);
			Assert.Equal(100, buffer.Capacity);
			
			buffer.GrowBy(100);
			Assert.Equal(200, buffer.Capacity);
		}
	}
}