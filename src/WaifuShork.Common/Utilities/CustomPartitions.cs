namespace WaifuShork.Common.Utilities;

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
	
public class EmptyOrderablePartitioner<T> : OrderablePartitioner<T>
{
	// Constructor just grabs the collection to wrap
	public EmptyOrderablePartitioner() : base(true, true, true)
	{                        
	}

	public override IList<IEnumerator<KeyValuePair<long, T>>> GetOrderablePartitions(int partitionCount)
	{
		return new List<IEnumerator<KeyValuePair<long, T>>>();
	}

        
	public override IEnumerable<KeyValuePair<long, T>> GetOrderableDynamicPartitions()
	{            
		return new List<KeyValuePair<long, T>>();
	}

	// Must be set to true if GetDynamicPartitions() is supported.
	public override bool SupportsDynamicPartitions => true;
}

public static class CustomPartition
{
	public static OrderablePartitioner<Tuple<int,int>> MakePartition(int len, int? batchSize)
	{
		if (len == 0) return new EmptyOrderablePartitioner<Tuple<int, int>>();

		if (batchSize == null)
		{
			return Partitioner.Create(0, len);
		}            
            
		return Partitioner.Create(0, len, batchSize.Value);
	}
      
	public static OrderablePartitioner<Tuple<int, int>> MakeSIMDPartition(int len, int chunkSize, int? batchSize)
	{
		if (len == 0)
		{
			return new EmptyOrderablePartitioner<Tuple<int, int>>();
		}

		var chunkLen = len - len % chunkSize;
		var numChunks = chunkLen / chunkSize;
		if (batchSize == null)
		{                
			return Partitioner.Create(0, numChunks,numChunks/Environment.ProcessorCount);
		}            
            
		return Partitioner.Create(0, numChunks, batchSize.Value);
	}
}