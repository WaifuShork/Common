using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

namespace WaifuShork.Common.Benchmarks
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			// _ = BenchmarkRunner.Run<Benchmarks>(ManualConfig.Create(DefaultConfig.Instance).AddJob(Job.RyuJitX64));
		}
	}
	
	// I use this purely as a testing environment for benchmarking new features,
	// so leftover data is likely to linger as everything isn't implemented properly. 
	[MemoryDiagnoser]
	public partial class Benchmarks
	{
		private List<int> _list;
		private int[] _intArray;
		private int[] _intArray2;
		private float[] _floatArray;
		private string[] _stringArray;
		
		[Params(1000000)]
		private int TestSize { get; set; }

		public Benchmarks()
		{
			
		}

		[GlobalSetup]
		public void Setup()
		{
			var random = new Random();
			this._intArray = new int[this.TestSize];
			this._intArray2 = new int[this.TestSize];
			this._floatArray = new float[this.TestSize];
			this._list = new List<int>(this.TestSize);
			this._stringArray = new string[this.TestSize];
                                    
			for (var i = 0; i < this.TestSize; i++)
			{
				this._intArray[i] = i % 2;
				this._intArray2[i] = i % 2;
				this._list.Add(this._intArray[i]);
				this._stringArray[i] = this._intArray[i].ToString();
				this._floatArray[i] = this._intArray[i];
			}
			
			this._intArray2[this.TestSize / 2] = 0;
		}

		/*[Benchmark]
		public void CountUpLoop()
		{
			for (var i = 0; i < 1000; i++)
			{
				var x = i;
				// Console.WriteLine(i);
			}
		}

		[Benchmark]
		public void CountDownLoop()
		{
			for (var i = 1000; i > 0; i--)
			{
				var x = i;
			}
		}*/
		
		/*[Benchmark]
		public int[] ConcatByLinq()
		{
			return this.array.Concat(this.array).ToArray();
		}*/

		/*[Benchmark]
		public int[] ConcatByQ()
		{
			return this.array.ConcatQ(this.array);
		}*/
	}
}