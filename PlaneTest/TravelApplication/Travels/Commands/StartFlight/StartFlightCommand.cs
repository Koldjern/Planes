using ErrorOr;
using MediatR;
using TravelApplication.Travels.Responses;
using TravelDomain.TravelAggregate.ValueObjects;

namespace TravelApplication.Travels.Commands.StartFlight;

public record StartFlightCommand(Guid PlaneId, Coordinate From, Coordinate To, IEnumerable<Guid> Employees, IEnumerable<Guid> Passengers, decimal TicketCost, double? LaunchSpeed, double? WeightOfWeaponry)
	: IRequest<ErrorOr<TravelResponse>>;
