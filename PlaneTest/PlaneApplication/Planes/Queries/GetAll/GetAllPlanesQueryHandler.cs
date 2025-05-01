using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate;

namespace PlaneApplication.Planes.Queries.GetAll;

public class GetAllPlanesQueryHandler : IRequestHandler<GetAllPlanesQuery, ErrorOr<IEnumerable<Plane>>>
{
	private readonly IPlaneRepository _planeRepository;

	public GetAllPlanesQueryHandler(IPlaneRepository planeRepository)
	{
		_planeRepository = planeRepository;
	}

	public async Task<ErrorOr<IEnumerable<Plane>>> Handle(GetAllPlanesQuery request, CancellationToken cancellationToken)
	{
		var planes = await _planeRepository.GetAll();
		return planes.ToErrorOr();
	}
}
