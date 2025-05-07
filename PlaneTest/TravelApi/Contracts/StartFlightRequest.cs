using TravelDomain.TravelAggregate.ValueObjects;

namespace TravelApi.Contracts;

public record StartFlightRequest(
	Guid PlaneId,
	Coordinate From,
	Coordinate To,
	IEnumerable<Guid> Employees,
	IEnumerable<Guid> Passengers,
	decimal TicketCost,
	double? LaunchSpeed,
	double? WeightOfWeaponry,
	double? CargoWeight,
	string? KmOrMiles);