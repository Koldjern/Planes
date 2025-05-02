using FluentValidation;

namespace PeopleApplication.Passengers.Queries.Get;

public class GetPassengerQueryValidator : AbstractValidator<GetPassengerQuery>
{
	public GetPassengerQueryValidator()
	{
		RuleFor(q => q.Id).NotEmpty();
	}
}
