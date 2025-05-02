using FluentValidation;

namespace PeopleApplication.Passengers.Commands.Add;

public class AddPassengerCommandValidator : AbstractValidator<AddPassengerCommand>
{
	public AddPassengerCommandValidator()
	{
		RuleFor(c => c.Weight).NotNull().GreaterThan(0);
	}
}
