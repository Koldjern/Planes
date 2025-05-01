using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace SubInfrastructure;

public static class DependencyInjection
{
	public static IServiceCollection SubInfrastructure(this IServiceCollection services)
	{
		services.AddScoped<DomainEventPublishingMemory>();
		return services;
	}
}
