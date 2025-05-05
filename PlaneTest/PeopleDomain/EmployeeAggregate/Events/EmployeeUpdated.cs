using SubDomain.Events;
using SubDomain.Models;

namespace PeopleDomain.EmployeeAggregate.Events;

public record EmployeeUpdated
	: UpdateEvent<Employee>
{
	public EmployeeUpdated(Employee Before, Employee After)
		: base(Before, After)
	{
	}
}
