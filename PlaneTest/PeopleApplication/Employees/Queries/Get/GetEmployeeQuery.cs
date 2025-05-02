using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Queries.Get;

public record GetEmployeeQuery(Guid Id)
	: IRequest<ErrorOr<Employee>>;