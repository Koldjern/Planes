using FluentValidation;
using TravelApplication.Travels.Commands.StartFlight;

namespace TravelApplication.Travels.Queries.CheckTravel;

public class CheckTravelQueryValidator : AbstractValidator<CheckTravelQuery>
{
	public CheckTravelQueryValidator()
	{
		RuleFor(q => q.Id).NotEmpty();
	}
}
