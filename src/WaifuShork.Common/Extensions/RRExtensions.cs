namespace WaifuShork.Common.Extensions;

using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

public static class RRExtensions
{
	public static async Task<T?> DeserializeAsync<T>(this HttpResponseMessage response, CancellationToken token, JsonSerializerOptions? options = default)
	{
		await using var stream = await response.Content.ReadAsStreamAsync(token);
		options ??= new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true };
		return await JsonSerializer.DeserializeAsync<T>(stream, options, token);
	}

	public static async Task<string?> SerializeAsync<T>(this T type, CancellationToken token, JsonSerializerOptions? options = default)
	{
		await using var stream = new MemoryStream();
		options ??= new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true };
		await JsonSerializer.SerializeAsync(stream, type, options, token);
		return Encoding.UTF8.GetString(stream.ToArray());
	}
}