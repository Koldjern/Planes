using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using SubInfrastructure.Api.Access;

public abstract class ApiAccess<T> : IApiAccess<T>
{
	protected abstract string ApiKey { get; }
	private readonly JsonSerializerOptions _jsonOptions = new () { PropertyNameCaseInsensitive = true };
	private readonly IHttpClientFactory _httpClientFactory;
	private readonly ILogger<ApiAccess<T>> _logger;

	public ApiAccess(IHttpClientFactory httpClientFactory, ILogger<ApiAccess<T>> logger)
	{
		_httpClientFactory = httpClientFactory;
		_logger = logger;
	}

	public async Task<TReturn?> PostAsync<TReturn, TParam>(string url, TParam parameter) =>
		await TryFunction(() => Post<TReturn, TParam>(url, parameter));

	public async Task<TReturn?> UpdateAsync<TReturn, TParam>(string url, TParam parameter) =>
		await TryFunction(() => Update<TReturn, TParam>(url, parameter));

	public async Task<TReturn?> DeleteAsync<TReturn>(string url) =>
		await TryFunction(() => Delete<TReturn>(url));

	public async Task<TReturn?> QuerySingleAsync<TReturn>(string url) =>
		await TryFunction(() => QuerySingle<TReturn>(url));

	public async Task<IEnumerable<TReturn>> QueryMultipleAsync<TReturn>(string url)
	{
		var result = await TryFunction(() => QueryMultiple<TReturn>(url));
		return result ?? Enumerable.Empty<TReturn>();
	}

	private async Task<TReturn?> QuerySingle<TReturn>(string url)
	{
		var client = _httpClientFactory.CreateClient(ApiKey);
		using var response = await client.GetAsync(url);
		var data = await response.Content.ReadAsStringAsync();
		return !string.IsNullOrWhiteSpace(data)
			? JsonSerializer.Deserialize<TReturn>(data, _jsonOptions)
			: default;
	}

	private async Task<IEnumerable<TReturn>?> QueryMultiple<TReturn>(string url)
	{
		var client = _httpClientFactory.CreateClient(ApiKey);
		using var response = await client.GetAsync(url);
		var data = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<IEnumerable<TReturn>>(data, _jsonOptions);
	}

	private async Task<TReturn?> Delete<TReturn>(string url)
	{
		var client = _httpClientFactory.CreateClient(ApiKey);
		using var response = await client.DeleteAsync(url);
		var data = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<TReturn>(data, _jsonOptions);
	}

	private async Task<TReturn?> Post<TReturn, TParam>(string url, TParam parameter)
	{
		var client = _httpClientFactory.CreateClient(ApiKey);
		var data = JsonSerializer.Serialize(parameter);
		using var content = new StringContent(data, Encoding.UTF8, "application/json");
		using var response = await client.PostAsync(url, content);

		if (!response.IsSuccessStatusCode) return default;

		var result = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<TReturn>(result, _jsonOptions);
	}

	private async Task<TReturn?> Update<TReturn, TParam>(string url, TParam parameter)
	{
		var client = _httpClientFactory.CreateClient(ApiKey);
		var data = JsonSerializer.Serialize(parameter);
		using var content = new StringContent(data, Encoding.UTF8, "application/json");
		using var response = await client.PutAsync(url, content);
		var result = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<TReturn>(result, _jsonOptions);
	}

	private async Task<TReturn?> TryFunction<TReturn>(Func<Task<TReturn?>> func)
	{
		try
		{
			return await func();
		}
		catch (Exception ex)
		{
			_logger.LogError(ex, $"API call failed in {typeof(ApiAccess<T>).Name}");
			return default;
		}
	}
}
