using ErrorOr;
using MediatR;

namespace PeopleApplication.Employees.Commands.Delete;

public record DeleteEmployeeCommand(Guid Id)
	: IRequest<ErrorOr<Deleted>>;
