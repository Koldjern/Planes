namespace TravelApplication.Travels.Responses;

public record PlaneResponse(Guid Id, string Type, MotorResponse? Motor, double WeightKg, double MaxWeight, string Name, double MaxSpeed);
public record MotorResponse(double Power, double Consumption);