using System;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using WaifuShork.Common.Attributes;
using WaifuShork.Common.Extensions;

namespace WaifuShork.Common.Helpers;

public static class Json
{
	private static JsonSerializerOptions s_options = new()
	{
		WriteIndented = true,
		AllowTrailingCommas = true
	};
	
	public static JsonSerializerOptions Options
	{
		get => s_options;
		set => s_options = value ?? throw new ArgumentNullException(nameof(value));
	}
	
	[GuaranteedNoThrow]
	public static async Task<T?> FromFileAsync<T>(string? file, JsonSerializerOptions? options = default, Encoding? encoding = default, CancellationToken token = default)
	{
		if (file.IsNullOrWhiteSpace())
		{
			return default;
		}
		
		if (!File.Exists(file))
		{
			return default;
		}

		try
		{
			var fileContent = await File.ReadAllTextAsync(file, encoding ?? Encoding.Default, token);
			return await FromStringAsync<T>(fileContent, options, encoding, token);
		}
		catch
		{
			return default;
		}
	}

	[GuaranteedNoThrow]
	public static async Task<T?> FromStringAsync<T>(string? value, JsonSerializerOptions? options = default, Encoding? encoding = default, CancellationToken token = default)
	{
		if (value.IsNullOrWhiteSpace())
		{
			return default;
		}
		
		try
		{
			encoding ??= Encoding.Default;
			options ??= s_options;
			await using var stream = new MemoryStream(encoding.GetBytes(value!));
			return await JsonSerializer.DeserializeAsync<T>(stream, options, token);
		}
		catch
		{
			return default;
		}
	}

	[GuaranteedNoThrow]
	public static T? FromString<T>(string? value, JsonSerializerOptions? options = default)
	{
		if (value is null || value.IsNullOrWhiteSpace())
		{
			return default;
		}
		
		try
		{
			options ??= s_options;
			return JsonSerializer.Deserialize<T>(value, options);
		}
		catch
		{
			return default;
		}
	}
	
	[GuaranteedNoThrow]
	public static T? FromFile<T>(string? file, JsonSerializerOptions? options = default, Encoding? encoding = default)
	{
		if (file.IsNullOrWhiteSpace())
		{
			return default;
		}
		
		if (!File.Exists(file))
		{
			return default;
		}
		try
		{
			encoding ??= Encoding.Default;
			options ??= s_options;
			var fileContent = File.ReadAllText(file, encoding);
			return FromString<T>(fileContent, options);
		}
		catch
		{
			return default;
		}
	}

	[GuaranteedNoThrow]
	public static async Task ToFileAsync<T>(string? path, T item, JsonSerializerOptions? options = default, Encoding? encoding = default, CancellationToken token = default)
	{
		if (path.IsNullOrWhiteSpace())
		{
			return;
		}
		
		if (item is null)
		{
			return;
		}
		
		try
		{
			encoding ??= Encoding.Default;
			options ??= s_options;
			await using var stream = new MemoryStream();
			await JsonSerializer.SerializeAsync(stream, item, options, token);
			var fileContent = encoding.GetString(stream.ToArray());
			await File.WriteAllTextAsync(path!, fileContent, encoding, token);
		}
		catch { /* ignored */ }
	}

	[GuaranteedNoThrow]
	public static void ToFile<T>(string? path, T item, JsonSerializerOptions? options = default, Encoding? encoding = default)
	{
		if (path.IsNullOrWhiteSpace())
		{
			return;
		}

		if (item is null)
		{
			return;
		}

		try
		{
			encoding ??= Encoding.Default;
			options ??= s_options;
			using var stream = new MemoryStream();
			JsonSerializer.Serialize(stream, item, options);
			var fileContent = encoding.GetString(stream.ToArray());
			File.WriteAllText(path!, fileContent, encoding);
		}
		catch { /* ignored */ }
	}
}





























