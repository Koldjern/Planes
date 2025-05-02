using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Queries.GetAll;

public record GetAllEmployeesQuery()
	: IRequest<ErrorOr<IEnumerable<Employee>>>;