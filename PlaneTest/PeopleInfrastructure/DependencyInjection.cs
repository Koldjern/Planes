using Microsoft.Extensions.DependencyInjection;
using SubInfrastructure;

namespace PeopleInfrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.SubInfrastructure();
		return services;
	}
}
