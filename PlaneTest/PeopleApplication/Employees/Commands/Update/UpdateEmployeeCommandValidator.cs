using FluentValidation;

namespace PeopleApplication.Employees.Commands.Update;

public class UpdateEmployeeCommandValidator : AbstractValidator<UpdateEmployeeCommand>
{
	public UpdateEmployeeCommandValidator()
	{
		RuleFor(c => c.Id).NotEmpty();
		RuleFor(c => c.HourWage).NotNull().GreaterThan(0);
		RuleFor(c => c.Weight).NotNull().GreaterThan(0);
		RuleFor(c => c.JobTitle).NotEmpty();
	}
}
