namespace TravelApplication.Travels.Responses;

public record TravelResponse(
	Guid Id,
	decimal WageCost,
	decimal TicketsPrice,
	double FuelSpentLiters,
	TimeSpan Duration,
	DistanceResponse TravelDistance,
	DateTime FlightEndsAt);