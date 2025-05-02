using PeopleApplication.Employees;
using PeopleDomain.EmployeeAggregate;
using SubInfrastructure;

namespace PeopleInfrastructure.Employees;

public class MemoryEmployeeRepository : CrudMemory<Employee, Guid>, IEmployeeRepository
{
	public MemoryEmployeeRepository(DomainEventPublishingMemory publisher)
		: base(publisher)
	{
	}
}
