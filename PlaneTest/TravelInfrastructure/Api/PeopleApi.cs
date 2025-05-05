using SubInfrastructure.Api.Access;
using TravelApplication.Travels;
using TravelApplication.Travels.Responses;

namespace TravelInfrastructure.Api;

public class PeopleApi : IPeopleApi
{
	private readonly IApiAccess<ApiAccessPeople> _apiAccess;

	public PeopleApi(IApiAccess<ApiAccessPeople> apiAccess)
	{
		_apiAccess = apiAccess;
	}

	public async Task<EmployeeResponse?> GetEmployee(Guid id)
	{
		return await _apiAccess.QuerySingleAsync<EmployeeResponse>("/employees/" + id);
	}

	public async Task<PassengerRespone?> GetPassenger(Guid id)
	{
		return await _apiAccess.QuerySingleAsync<PassengerRespone>("/passengers/" + id);
	}
}
