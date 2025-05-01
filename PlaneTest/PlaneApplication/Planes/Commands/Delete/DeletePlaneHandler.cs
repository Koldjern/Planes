using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate.Errors;

namespace PlaneApplication.Planes.Commands.Delete;

public class DeletePlaneHandler : IRequestHandler<DeletePlaneCommand, ErrorOr<Deleted>>
{
	private readonly IPlaneRepository _planeRepository;

	public DeletePlaneHandler(IPlaneRepository planeRepository)
	{
		_planeRepository = planeRepository;
	}

	public async Task<ErrorOr<Deleted>> Handle(DeletePlaneCommand request, CancellationToken cancellationToken)
	{
		var plane = await _planeRepository.Get(request.Id);
		if (plane is null)
			return Errors.Plane.NotFound;

		var deleted = await _planeRepository.Delete(request.Id);

		if (!deleted)
			return Errors.Plane.CantDelete;

		return Result.Deleted;
	}
}
