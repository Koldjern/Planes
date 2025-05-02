using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Commands.Add;

public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, ErrorOr<Guid>>
{
	private readonly IEmployeeRepository _repository;

	public AddEmployeeCommandHandler(IEmployeeRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Guid>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
	{
		var employee = Employee.CreateNew(request.Weight, request.HourWage, request.JobTitle);
		var added = await _repository.Add(employee);

		if (!added)
			return Errors.Employee.CantAdd;

		return employee.Id;
	}
}
