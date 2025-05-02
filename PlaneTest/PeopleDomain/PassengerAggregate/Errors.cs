using ErrorOr;

namespace PeopleDomain.PassengerAggregate;

/// <summary>
/// Partial class for Errors.
/// </summary>
public static partial class Errors
{
	public static class Passenger
	{
		public static Error NotFound => Error.NotFound(
			code: "Passenger.NotFound",
			description: "Couldnt find Passenger by id");

		public static Error CantDelete => Error.Unexpected(
			code: "Passenger.CantDelete",
			description: "Couldnt Delete the Passenger");

		public static Error CantUpdate => Error.Unexpected(
			code: "Passenger.CantUpdate",
			description: "Couldnt Update the Passenger");

		public static Error CantAdd => Error.Unexpected(
			code: "Passenger.CantAdd",
			description: "Couldnt Add the Passenger");
	}
}
