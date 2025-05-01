using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Entities;
using PlaneDomain.PlaneAggregate.Errors;

namespace PlaneApplication.Planes.Commands.Add;

public class AddPlaneCommandHandler : IRequestHandler<AddPlaneCommand, ErrorOr<Guid>>
{
	private readonly IPlaneRepository _planeRepository;

	public AddPlaneCommandHandler(IPlaneRepository planeRepository)
	{
		_planeRepository = planeRepository;
	}

	public async Task<ErrorOr<Guid>> Handle(AddPlaneCommand request, CancellationToken cancellationToken)
	{
		Plane? plane = MakePlane(request);

		if (plane is null)
			return Errors.Plane.CantAdd;

		var added = await _planeRepository.Add(plane);
		if (!added)
			return Errors.Plane.CantAdd;
		return plane.Id;
	}

	private Plane? MakePlane(AddPlaneCommand request)
	{
		if (request.Type == PlaneType.Glider)
			return Plane.CreateNew(request.Type, null, request.WeightKg, request.MaxWeight, request.Name, request.MaxSpeed);

		if (string.IsNullOrEmpty(request.MotorName) || request.Power == null || request.Power <= 0 || request.Consumption == null || request.Consumption <= 0)
			return null;

		Motor motor = Motor.CreateNew(request.MotorName, request.Power!.Value, request.Consumption!.Value);
		return Plane.CreateNew(request.Type, motor, request.WeightKg, request.MaxWeight, request.Name, request.MaxSpeed);
	}
}
