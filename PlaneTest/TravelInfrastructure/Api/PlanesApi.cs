using SubInfrastructure.Api.Access;
using TravelApplication.Travels;
using TravelApplication.Travels.Responses;

namespace TravelInfrastructure.Api;

public class PlanesApi : IPlanesApi
{
	private readonly IApiAccess<ApiAccessPlanes> _apiAccess;

	public PlanesApi(IApiAccess<ApiAccessPlanes> apiAccess)
	{
		_apiAccess = apiAccess;
	}

	public async Task<PlaneResponse?> GetPlane(Guid id)
	{
		var result = await _apiAccess.QuerySingleAsync<PlaneResponse>("/planes/" + id);
		return result;
	}
}
