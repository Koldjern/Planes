using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate;

namespace PlaneApplication.Planes.Queries.Get;

public record GetPlaneQuery(Guid Id)
	: IRequest<ErrorOr<Plane>>;