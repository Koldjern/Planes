using Mapster;
using PeopleApi.Contracts.Employee;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApi.Mappings;

public class EmployeeMapConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{
		config.NewConfig<IEnumerable<Employee>, EmployeesResponse>()
			.Map(dest => dest.Employees, src => src);
	}
}
