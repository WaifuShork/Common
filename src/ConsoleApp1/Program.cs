using System;
using System.Text;
using WaifuShork.Common;
using WaifuShork.Common.Extensions;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			var buffer = new RingBuffer<int>(100);
			for (var i = 0; i < buffer.Capacity; i++)
			{
				buffer.Add(i);
			}

			var clone = buffer.DeepClone();

			var sb = new StringBuilder();
			foreach (var item in buffer)
			{
				sb.AppendLine(item.ToString());
			}
			
			Console.Out.WriteLine(sb.ToString());

			sb.Clear();
			foreach (var item in clone)
			{
				sb.AppendLine(item.ToString());
			}
			
			Console.Out.WriteLine(sb.ToString());

			// Assert.Equal(buffer, clone);
			// Assert.Equal(100, buffer.Capacity);
			
			// buffer.GrowBy(100);
			// Assert.Equal(200, buffer.Capacity);
		}
	}
}