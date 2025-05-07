using TravelDomain.TravelAggregate.Entities.Employee;

namespace TravelDomain.TravelAggregate.Entities.Planes;

public class JetFighter : TravelPlane
{
	private JetFighter(Guid id, Motor motor, double weightKg, double maxWeight, string name, double maxSpeed, double weightOfWeaponry, TravelEmployee captain)
		: base(id, motor, weightKg, maxWeight, name, maxSpeed, [captain], [])
	{
		WeightOfWeaponry = weightOfWeaponry;
	}

	public double WeightOfWeaponry { get; set; }

	public static JetFighter Create(Guid id, Motor motor, double weightKg, double maxWeight, string name, double maxSpeed, double weightOfWeaponry, TravelEmployee captain)
	{
		var plane = new JetFighter(id, motor, weightKg, maxWeight, name, maxSpeed, weightOfWeaponry, captain);
		return plane;
	}

	public override double Weight()
	{
		return base.Weight() + WeightOfWeaponry;
	}
}
