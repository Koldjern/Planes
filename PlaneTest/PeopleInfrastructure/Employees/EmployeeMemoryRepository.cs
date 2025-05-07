using System.Reflection;
using PeopleApplication.Employees;
using PeopleDomain.EmployeeAggregate;
using PeopleDomain.EmployeeAggregate.Events;
using SubInfrastructure;

namespace PeopleInfrastructure.Employees;

public class EmployeeMemoryRepository : CrudMemory<Employee, Guid>, IEmployeeRepository
{
	public EmployeeMemoryRepository(DomainEventPublishingMemory publisher)
		: base(
			publisher,
			(employee) =>
			{
				var newEmployee = Employee.CreateNew(employee.Weight, employee.HourWage, employee.JobTitle);

				IdSetter(newEmployee, employee.Id);

				newEmployee.ClearDomainEvents();

				return newEmployee;
			},
			(employee) => new EmployeeDeleted(employee),
			(before, after) => new EmployeeUpdated(before, after))
	{
		if (_entities is null)
		{
			List<Guid> ids = new List<Guid>([Guid.Parse("5535ae79-426f-49ec-96b7-b4212373474e"), Guid.Parse("8410afe4-0364-4958-911d-a2d07b195818"), Guid.Parse("24ef6897-895a-4969-b45c-f480e66a9aca")]);
			_entities = new List<Employee>([Employee.CreateNew(80, 700, "Plane Tester"), Employee.CreateNew(50, 700, "Plane Something"), Employee.CreateNew(100, 1000, "Captain")]);
			_entities.ForEach(p => IdSetter(p, ids[_entities.IndexOf(p)]));
		}
	}
}
