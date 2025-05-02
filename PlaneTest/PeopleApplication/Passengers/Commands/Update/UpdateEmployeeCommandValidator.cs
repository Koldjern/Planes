using FluentValidation;

namespace PeopleApplication.Passengers.Commands.Update;

public class UpdatePassengerCommandValidator : AbstractValidator<UpdatePassengerCommand>
{
	public UpdatePassengerCommandValidator()
	{
		RuleFor(c => c.Id).NotEmpty();
		RuleFor(c => c.Weight).NotNull().GreaterThan(0);
	}
}
