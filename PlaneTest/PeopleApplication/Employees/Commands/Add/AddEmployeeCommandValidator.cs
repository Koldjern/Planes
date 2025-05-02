using FluentValidation;

namespace PeopleApplication.Employees.Commands.Add;

public class AddEmployeeCommandValidator : AbstractValidator<AddEmployeeCommand>
{
	public AddEmployeeCommandValidator()
	{
		RuleFor(c => c.HourWage).NotNull().GreaterThan(0);
		RuleFor(c => c.Weight).NotNull().GreaterThan(0);
		RuleFor(c => c.JobTitle).NotEmpty();
	}
}
