namespace PeopleApi.Contracts.Passenger;

public record PassengersResponse(IEnumerable<PassengerResponse> Passengers);
public record PassengerResponse(Guid Id, double Weight);