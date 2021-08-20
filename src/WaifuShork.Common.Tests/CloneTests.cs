using System.Runtime.InteropServices;
using WaifuShork.Common.Extensions;
using Xunit;

namespace WaifuShork.Common.Tests
{
	public class CloneTests
	{
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
	}
}