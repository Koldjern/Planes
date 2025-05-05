using Microsoft.Extensions.Logging;
using SubInfrastructure.Api.Access;

namespace TravelInfrastructure.Api;

public class ApiAccessPeople : ApiAccess<ApiAccessPeople>
{
	public ApiAccessPeople(IHttpClientFactory httpClientFactory, ILogger<ApiAccess<ApiAccessPeople>> logger)
		: base(httpClientFactory, logger)
	{
	}

	protected override string ApiKey => "PeopleClient";
}
