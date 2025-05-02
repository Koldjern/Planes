namespace PeopleApi.Contracts.Employee;

public record UpdateEmployeeRequest(Guid? Id, decimal HourWage, double Weight, string JobTitle);