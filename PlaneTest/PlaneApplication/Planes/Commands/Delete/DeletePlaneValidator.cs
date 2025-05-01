using FluentValidation;

namespace PlaneApplication.Planes.Commands.Delete;

public class DeletePlaneValidator : AbstractValidator<DeletePlaneCommand>
{
	public DeletePlaneValidator()
	{
		RuleFor(c => c.Id).NotEmpty();
	}
}
