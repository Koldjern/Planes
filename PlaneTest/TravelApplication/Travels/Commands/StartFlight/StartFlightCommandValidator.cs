using FluentValidation;

namespace TravelApplication.Travels.Commands.StartFlight;

public class StartFlightCommandValidator : AbstractValidator<StartFlightCommand>
{
	public StartFlightCommandValidator()
	{
		RuleFor(c => c.PlaneId).NotEmpty();
		RuleFor(c => c).Must(c => !c.From.Equals(c.To));
		RuleFor(c => c.Employees).NotEmpty();
		RuleFor(c => c.TicketCost).NotEmpty();
	}
}
