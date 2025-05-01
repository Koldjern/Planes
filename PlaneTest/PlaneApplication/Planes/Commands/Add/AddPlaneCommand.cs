using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate.Entities;

namespace PlaneApplication.Planes.Commands.Add;

public record AddPlaneCommand(
	string Type,
	string? MotorName,
	double? Power,
	double? Consumption,
	double WeightKg,
	double MaxWeight,
	string Name,
	double MaxSpeed)
	: IRequest<ErrorOr<Guid>>;
