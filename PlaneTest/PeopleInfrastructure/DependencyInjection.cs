using Microsoft.Extensions.DependencyInjection;
using PeopleApplication.Employees;
using PeopleApplication.Passengers;
using PeopleInfrastructure.Employees;
using PeopleInfrastructure.Passengers;
using SubInfrastructure;

namespace PeopleInfrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.SubInfrastructure();
		services.AddScoped<IPassengerRepository, MemoryPassengerRepository>();
		services.AddScoped<IEmployeeRepository, EmployeeMemoryRepository>();
		return services;
	}
}
