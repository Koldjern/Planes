using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Errors;

namespace PlaneApplication.Planes.Commands.Update;

public class UpdatePlaneCommandHandler : IRequestHandler<UpdatePlaneCommand, ErrorOr<Updated>>
{
	private readonly IPlaneRepository _planeRepository;

	public UpdatePlaneCommandHandler(IPlaneRepository planeRepository)
	{
		_planeRepository = planeRepository;
	}

	public async Task<ErrorOr<Updated>> Handle(UpdatePlaneCommand request, CancellationToken cancellationToken)
	{
		if (PlaneType.IsGlider(request.Type))
			return await Glider(request, cancellationToken);

		return await Motor(request, cancellationToken);
	}

	private async Task<ErrorOr<Updated>> Glider(UpdatePlaneCommand request, CancellationToken cancellationToken)
	{
		var plane = await _planeRepository.Get(request.Id);

		if (plane is null)
			return Errors.Plane.NotFound;

		plane.Name = request.Name;
		plane.WeightKg = request.WeightKg;
		plane.MaxWeight = request.MaxWeight;
		plane.MaxSpeed = request.MaxSpeed;

		var updated = await _planeRepository.Update(plane);

		if (!updated)
			return Errors.Plane.CantUpdate;
		return Result.Updated;
	}

	private async Task<ErrorOr<Updated>> Motor(UpdatePlaneCommand request, CancellationToken cancellationToken)
	{
		var plane = await _planeRepository.Get(request.Id);

		if (plane is null || plane.Motor!.Id != request.MotorId)
			return Errors.Plane.NotFound;

		plane.Name = request.Name;
		plane.UpdateMotor(request.MotorName!, request.Power!.Value, request.Consumption!.Value);
		plane.WeightKg = request.WeightKg;
		plane.MaxWeight = request.MaxWeight;
		plane.MaxSpeed = request.MaxSpeed;

		var updated = await _planeRepository.Update(plane);

		if (!updated)
			return Errors.Plane.CantUpdate;
		return Result.Updated;
	}
}
