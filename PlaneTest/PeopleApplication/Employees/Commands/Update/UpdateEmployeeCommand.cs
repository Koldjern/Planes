using ErrorOr;
using MediatR;

namespace PeopleApplication.Employees.Commands.Update;

public record UpdateEmployeeCommand(Guid Id, decimal HourWage, double Weight, string JobTitle)
	: IRequest<ErrorOr<Updated>>;