using SubDomain.Models;

namespace TravelDomain.TravelAggregate.Entities.Employee;

public class TravelEmployee : Entity<Guid>
{
	private TravelEmployee(Guid id, string jobTitle, double weight, decimal hourWage)
		: base(id)
	{
		JobTitle = jobTitle;
		Weight = weight;
		HourWage = hourWage;
	}

	public string JobTitle { get; set; }
	public double Weight { get; set; }
	public decimal HourWage { get; set; }

	public static TravelEmployee Create(Guid id, string jobTitle, double weight, decimal hourWage)
	{
		return new TravelEmployee(id, jobTitle, weight, hourWage);
	}
}
