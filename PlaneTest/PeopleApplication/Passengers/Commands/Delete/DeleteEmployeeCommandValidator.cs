using FluentValidation;

namespace PeopleApplication.Passengers.Commands.Delete;

public class DeletePassengerCommandValidator : AbstractValidator<DeletePassengerCommand>
{
	public DeletePassengerCommandValidator()
	{
		RuleFor(c => c.Id).NotEmpty();
	}
}
