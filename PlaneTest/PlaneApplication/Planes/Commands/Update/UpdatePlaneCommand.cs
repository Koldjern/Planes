using ErrorOr;
using MediatR;

namespace PlaneApplication.Planes.Commands.Update;

public record UpdatePlaneCommand(
	Guid Id,
	Guid? MotorId,
	string? MotorName,
	double? Power,
	double? Consumption,
	string Type,
	double WeightKg,
	double MaxWeight,
	string Name,
	double MaxSpeed)
	: IRequest<ErrorOr<Updated>>;
