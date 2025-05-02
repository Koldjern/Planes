using ErrorOr;

namespace PeopleDomain.EmployeeAggregate;

/// <summary>
/// Partial class for Errors.
/// </summary>
public static partial class Errors
{
	public static class Employee
	{
		public static Error NotFound => Error.NotFound(
			code: "Employee.NotFound",
			description: "Couldnt find Employee by id");

		public static Error CantDelete => Error.Unexpected(
			code: "Employee.CantDelete",
			description: "Couldnt Delete the Employee");

		public static Error CantUpdate => Error.Unexpected(
			code: "Employee.CantUpdate",
			description: "Couldnt Update the Employee");

		public static Error CantAdd => Error.Unexpected(
			code: "Employee.CantAdd",
			description: "Couldnt Add the Employee");
	}
}
