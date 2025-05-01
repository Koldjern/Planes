using FluentValidation;

namespace PlaneApplication.Planes.Queries.Get;

public class GetPlaneQueryValidator : AbstractValidator<GetPlaneQuery>
{
	public GetPlaneQueryValidator()
	{
		RuleFor(q => q.Id).NotEmpty();
	}
}
