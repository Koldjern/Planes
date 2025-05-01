using ErrorOr;
using MediatR;

namespace PlaneApplication.Planes.Commands.Delete;

public record DeletePlaneCommand(
	Guid Id)
	: IRequest<ErrorOr<Deleted>>;
