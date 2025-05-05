namespace TravelApplication.Travels.Responses;

public record TravelResponse(
	Guid Id,
	decimal WageCost,
	decimal TicketsPrice,
	double FuelSpent,
	TimeSpan Duration,
	double TravelDistance,
	DateTime FlightEndsAt);