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
		return new Employee(Guid.NewGuid(), weight, hourWage, jobTitle);
	}
}
