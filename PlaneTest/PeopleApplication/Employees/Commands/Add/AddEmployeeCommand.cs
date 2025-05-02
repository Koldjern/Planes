using ErrorOr;
using MediatR;

namespace PeopleApplication.Employees.Commands.Add;

public record AddEmployeeCommand(
	decimal HourWage,
	double Weight,
	string JobTitle)
	: IRequest<ErrorOr<Guid>>;