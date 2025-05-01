using ErrorOr;

namespace PlaneDomain.PlaneAggregate.Errors;

/// <summary>
/// Partial class for Errors.
/// </summary>
public static partial class Errors
{
	public static class Plane
	{
		public static Error NotFound => Error.NotFound(
			code: "Plane.NotFound",
			description: "Couldnt find plane by id");

		public static Error CantDelete => Error.Unexpected(
			code: "Plane.CantDelete",
			description: "Couldnt Delete the Plane");

		public static Error CantUpdate => Error.Unexpected(
			code: "Plane.CantUpdate",
			description: "Couldnt Update the Plane");

		public static Error CantAdd => Error.Unexpected(
			code: "Plane.CantAdd",
			description: "Couldnt Add the Plane");
	}
}
