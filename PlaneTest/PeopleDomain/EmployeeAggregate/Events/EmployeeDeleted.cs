using SubDomain.Events;

namespace PeopleDomain.EmployeeAggregate.Events;

public record EmployeeDeleted : DeleteEvent<Employee>
{
	public EmployeeDeleted(Employee Deleted)
		: base(Deleted)
	{
	}
}
