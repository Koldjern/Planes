using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using SubApplication;

namespace PeopleApplication;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddSubApplication(Assembly.GetExecutingAssembly());
		return services;
	}
}
