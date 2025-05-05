using System.Reflection;
using PeopleApplication.Employees;
using PeopleDomain.EmployeeAggregate;
using PeopleDomain.EmployeeAggregate.Events;
using SubInfrastructure;

namespace PeopleInfrastructure.Employees;

public class MemoryEmployeeRepository : CrudMemory<Employee, Guid>, IEmployeeRepository
{
	public MemoryEmployeeRepository(DomainEventPublishingMemory publisher)
		: base(
			publisher,
			(employee) =>
			{
				var newPassenger = Employee.CreateNew(employee.Weight, employee.HourWage, employee.JobTitle);

				var idProp = typeof(Employee).GetProperty("Id", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				if (idProp != null && idProp.CanWrite)
				{
					idProp.SetValue(newPassenger, employee.Id);
				}

				newPassenger.ClearDomainEvents();

				return newPassenger;
			},
			(employee) => new EmployeeDeleted(employee),
			(before, after) => new EmployeeUpdated(before, after))
	{
	}
}
