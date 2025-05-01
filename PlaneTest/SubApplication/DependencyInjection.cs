using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace SubApplication;

public static class DependencyInjection
{
	public static IServiceCollection AddSubApplication(this IServiceCollection services, Assembly assembly)
	{
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
		services.AddValidatorsFromAssembly(assembly);
		return services;
	}
}
