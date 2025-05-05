using Microsoft.Extensions.Logging;

namespace TravelInfrastructure.Api;

public class ApiAccessPlanes : ApiAccess<ApiAccessPlanes>
{
	public ApiAccessPlanes(IHttpClientFactory httpClientFactory, ILogger<ApiAccess<ApiAccessPlanes>> logger)
		: base(httpClientFactory, logger)
	{
	}

	protected override string ApiKey => "PlaneClient";
}
