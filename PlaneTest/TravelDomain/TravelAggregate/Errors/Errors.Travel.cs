using ErrorOr;

namespace TravelDomain.TravelAggregate.Errors;

/// <summary>
/// Partial class for Errors.
/// </summary>
public static partial class Errors
{
	public static class Travel
	{
		public static Error TravelNotFound => Error.NotFound(
			code: "Travel.NotFound",
			description: "Couldnt find Travel by id");
		public static Error PlaneNotFound => Error.NotFound(
			code: "Plane.NotFound",
			description: "Couldnt find plane by id");

		public static Error EmployeeNotFound => Error.Unexpected(
			code: "Employee.NotFound",
			description: "Couldnt find Employee by id");

		public static Error PassengerNotFound => Error.Unexpected(
			code: "Passenger.NotFound",
			description: "Couldnt find Passenger by id");

		public static Error ErrorHandlingPlane => Error.Unexpected(
			code: "Plane.Error",
			description: "Error");

		public static Error PlaneTooHeavy(double max, double at) => Error.Unexpected(
			code: "Plane.TooHeavy",
			description: $"Too much weight on this plane Max: {max}, Weight At: {at}");
	}
}
