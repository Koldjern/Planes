using PeopleDomain.EmployeeAggregate.Events;
using SubDomain.Models;

namespace PeopleDomain.EmployeeAggregate;

public class Employee : AggregateRoot<Guid>
{
	public Employee(Guid id, double weight, decimal hourWage, string jobTitle)
		: base(id)
	{
		Weight = weight;
		HourWage = hourWage;
		JobTitle = jobTitle;
	}
	public string JobTitle { get; set; }
	public double Weight { get; set; }
	public decimal HourWage { get; set; }
	public static Employee CreateNew(double weight, decimal hourWage, string jobTitle)
	{
		Employee employee = new Employee(Guid.NewGuid(), weight, hourWage, jobTitle);
		employee.AddDomainEvent(new EmployeeAdded(employee));

		return employee;
	}
	public override string ToString()
	{
		return $"Weight: {Weight}, Hourly Wage: {HourWage}, Job Title: {JobTitle}";
	}
#pragma warning disable CS8618, SA1201
	private Employee()
	{
	}
#pragma warning restore CS8618, SA1201
}
