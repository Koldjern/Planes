using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Commands.Update;

public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, ErrorOr<Updated>>
{
	private readonly IEmployeeRepository _repository;

	public UpdateEmployeeCommandHandler(IEmployeeRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Updated>> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
	{
		var employee = await _repository.Get(request.Id);

		if (employee is null)
			return Errors.Employee.NotFound;

		employee.Weight = request.Weight;
		employee.HourWage = request.HourWage;
		employee.JobTitle = request.JobTitle;

		var updated = await _repository.Update(employee);

		if (!updated)
			return Errors.Employee.CantUpdate;
		return Result.Updated;
	}
}
