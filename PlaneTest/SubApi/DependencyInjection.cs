using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using SubApi.Exceptions;

namespace SubApi;

public static class DependencyInjection
{
	public static IServiceCollection SetupBuilder(this IServiceCollection services, Assembly assembly)
	{
		services.AddControllers();
		services.AddExceptionHandler<UnexpectedExceptionHandler>();
		services.AddProblemDetails();
		services.AddSingleton<ProblemDetailsFactory, ErrorOrDetailsFactory>();
		TypeAdapterConfig? config = TypeAdapterConfig.GlobalSettings;
		config.Scan(assembly);
		services.AddSingleton(config);
		services.AddScoped<IMapper, ServiceMapper>();
		return services;
	}

	public static WebApplication SetupApp(this WebApplication app)
	{
		app.UseHttpsRedirection();
		app.UseExceptionHandler();
		app.MapControllers();
		return app;
	}
}
