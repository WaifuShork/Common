using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace WaifuShork.Common.Extensions
{
	public static class HttpClientExtensions
	{
		public static async Task<(T?, HttpStatusCode)> GetAsync<T>(this HttpClient client, string endpoint, 
			HttpStatusCode expectedStatus = HttpStatusCode.OK, 
			CancellationToken token = default, 
			JsonSerializerOptions? options = default)
		{
			if (!Uri.IsWellFormedUriString(endpoint, UriKind.RelativeOrAbsolute))
			{
				return (default, HttpStatusCode.BadRequest);
			}

			var response = await client.GetAsync(endpoint, token);
			if (response.StatusCode != expectedStatus)
			{
				return (default, response.StatusCode);
			}

			options ??= new JsonSerializerOptions { WriteIndented = true, AllowTrailingCommas = true };
			return (await response.DeserializeAsync<T>(token, options), response.StatusCode);
		}

		public static async Task<T?> PostAsync<T>()
		{
			return default;
		}

		public static async Task<T?> PutAsync<T>()
		{
			return default;
		}

		public static async Task<T?> DeleteAsync<T>()
		{
			return default;
		}
	}
}