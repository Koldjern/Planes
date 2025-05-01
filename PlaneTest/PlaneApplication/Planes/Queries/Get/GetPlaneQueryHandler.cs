using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Errors;

namespace PlaneApplication.Planes.Queries.Get;

public class GetPlaneQueryHandler : IRequestHandler<GetPlaneQuery, ErrorOr<Plane>>
{
	private readonly IPlaneRepository _planeRepository;

	public GetPlaneQueryHandler(IPlaneRepository planeRepository)
	{
		_planeRepository = planeRepository;
	}

	public async Task<ErrorOr<Plane>> Handle(GetPlaneQuery request, CancellationToken cancellationToken)
	{
		var find = await _planeRepository.Get(request.Id);
		if (find is null)
			return Errors.Plane.NotFound;
		return find;
	}
}
