using System;
using System.IO;
using System.Threading.Tasks;

namespace WaifuShork.Common.Extensions
{
	public static class TextWriterExtensions
	{
		public static async Task WriteLineAsync<T>(this TextWriter writer, params T[] items)
		{
			if (items is null)
			{
				await writer.WriteLineAsync();
				return;
			}
			
			var message = string.Join(' ', items);
			if (message.IsNullOrWhiteSpace())
			{
				await Parallel.ForEachAsync(items, async (i, _) =>
				{
					await writer.WriteAsync((i?.ToString() ?? i?.GetType().FullName ?? "") + " ");
				});
				await writer.WriteLineAsync();
				return;
			}

			await writer.WriteLineAsync(message);
		}

		public static async Task WriteAsync<T>(this TextWriter writer, params T[] items)
		{
			if (items is null)
			{
				await writer.WriteLineAsync();
				return;
			}
			
			var message = string.Join(' ', items);
			if (message.IsNullOrWhiteSpace())
			{
				await Parallel.ForEachAsync(items, async (i, _) =>
				{
					await writer.WriteAsync((i?.ToString() ?? i?.GetType().FullName ?? "") + " ");
				});
				return;
			}

			await writer.WriteLineAsync(message);
		}
	}
}