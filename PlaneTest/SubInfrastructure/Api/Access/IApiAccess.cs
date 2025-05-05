namespace SubInfrastructure.Api.Access;

public interface IApiAccess<T>
{
	Task<IEnumerable<TReturn>> QueryMultipleAsync<TReturn>(string url);
	Task<TReturn?> QuerySingleAsync<TReturn>(string url);
	Task<TReturn?> PostAsync<TReturn, TParam>(string url, TParam parameter);
	Task<TReturn?> UpdateAsync<TReturn, TParam>(string url, TParam parameter);
	Task<TReturn?> DeleteAsync<TReturn>(string url);
}
