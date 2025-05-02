using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Queries.Get;

public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, ErrorOr<Employee>>
{
	private readonly IEmployeeRepository _repository;

	public GetEmployeeQueryHandler(IEmployeeRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<Employee>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
	{
		var find = await _repository.Get(request.Id);
		if (find is null)
			return Errors.Employee.NotFound;
		return find;
	}
}
