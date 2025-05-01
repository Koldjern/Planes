using Microsoft.Extensions.DependencyInjection;
using PlaneApplication.Planes;
using PlaneInfrastructure.Planes;
using SubInfrastructure;

namespace PlaneInfrastructureM;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.SubInfrastructure();
		services.AddScoped<IPlaneRepository, MemoryPlaneRepository>();
		return services;
	}
}
