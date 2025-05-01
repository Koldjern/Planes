namespace PlaneApi.Contracts;

public record PlanesResponse(IEnumerable<PlaneResponse> Planes);
public record PlaneResponse(Guid Id, MotorResponse? Motor, string Type, string Name, double weightKg, double maxWeight, double maxSpeed);
public record MotorResponse(Guid Id, string Name, double Power, double Consumption);