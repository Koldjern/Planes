using ErrorOr;
using MediatR;
using PlaneDomain.PlaneAggregate;

namespace PlaneApplication.Planes.Queries.GetAll;

public record GetAllPlanesQuery()
	: IRequest<ErrorOr<IEnumerable<Plane>>>;