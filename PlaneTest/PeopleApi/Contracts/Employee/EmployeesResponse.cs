namespace PeopleApi.Contracts.Employee;

public record EmployeesResponse(IEnumerable<EmployeeResponse> Employees);
public record EmployeeResponse(Guid Id, decimal HourWage, double Weight, string JobTitle);