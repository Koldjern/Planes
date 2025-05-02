using ErrorOr;
using MediatR;
using PeopleDomain.EmployeeAggregate;

namespace PeopleApplication.Employees.Queries.GetAll;

public class GetAllEmployeesQueryHandler
	: IRequestHandler<GetAllEmployeesQuery, ErrorOr<IEnumerable<Employee>>>
{
	private readonly IEmployeeRepository _repository;

	public GetAllEmployeesQueryHandler(IEmployeeRepository repository)
	{
		_repository = repository;
	}

	public async Task<ErrorOr<IEnumerable<Employee>>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
	{
		var planes = await _repository.GetAll();
		return planes.ToErrorOr();
	}
}
