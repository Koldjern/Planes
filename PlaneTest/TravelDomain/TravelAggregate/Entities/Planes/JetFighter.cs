using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.People;

namespace TravelDomain.TravelAggregate.Entities.Planes;

public class JetFighter : TravelPlane
{
	private JetFighter(Guid id, double weightKg, double maxWeight, string name, double maxSpeed, double weightOfWeaponry, TravelEmployee captain)
		: base(id, null, weightKg, maxWeight, name, maxSpeed, [captain], [])
	{
		WeightOfWeaponry = weightOfWeaponry;
	}

	public double WeightOfWeaponry { get; set; }

	public static JetFighter Create(Guid id, double weightKg, double maxWeight, string name, double maxSpeed, double weightOfWeaponry, TravelEmployee captain)
	{
		var plane = new JetFighter(id, weightKg, maxWeight, name, maxSpeed, weightOfWeaponry, captain);
		return plane;
	}

	public override double Weight()
	{
		return base.Weight() + WeightOfWeaponry;
	}
}
