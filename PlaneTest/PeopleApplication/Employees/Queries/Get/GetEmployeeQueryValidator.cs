using FluentValidation;
using PeopleApplication.Employees.Queries.GetAll;

namespace PeopleApplication.Employees.Queries.Get;

public class GetEmployeeQueryValidator : AbstractValidator<GetEmployeeQuery>
{
	public GetEmployeeQueryValidator()
	{
		RuleFor(q => q.Id).NotEmpty();
	}
}
