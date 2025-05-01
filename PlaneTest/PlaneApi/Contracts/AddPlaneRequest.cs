namespace PlaneApi.Contracts;

public record AddPlaneRequest(
	string? MotorName,
	double? Power,
	double? Consumption,
	string Type,
	double WeightKg,
	double MaxWeight,
	string Name,
	double MaxSpeed);
