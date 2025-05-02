using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Commands.Delete;

public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, ErrorOr<Deleted>>
{
	private readonly IEmployeeRepository _repository;

	public DeleteEmployeeCommandHandler(IEmployeeRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Deleted>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
	{
		var find = await _repository.Get(request.Id);
		if (find is null)
			return Errors.Employee.NotFound;

		var deleted = await _repository.Delete(request.Id);

		if (!deleted)
			return Errors.Employee.CantDelete;

		return Result.Deleted;
	}
}
