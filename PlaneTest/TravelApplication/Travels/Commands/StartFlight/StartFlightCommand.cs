using ErrorOr;
using MediatR;
using TravelApplication.Travels.Responses;
using TravelDomain.TravelAggregate.ValueObjects;

namespace TravelApplication.Travels.Commands.StartFlight;

public record StartFlightCommand(Guid PlaneId, Coordinate From, Coordinate To, IEnumerable<Guid> Employees, IEnumerable<Guid> Passengers, decimal? TicketCost = null, double? LaunchSpeed = null, double? WeightOfWeaponry = null, double? CargoWeight = null, string? KmOrMiles = null)
	: IRequest<ErrorOr<TravelResponse>>;
