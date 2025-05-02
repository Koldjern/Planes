using FluentValidation;

namespace PeopleApplication.Employees.Commands.Delete;

public class DeleteEmployeeCommandValidator : AbstractValidator<DeleteEmployeeCommand>
{
	public DeleteEmployeeCommandValidator()
	{
		RuleFor(c => c.Id).NotEmpty();
	}
}
