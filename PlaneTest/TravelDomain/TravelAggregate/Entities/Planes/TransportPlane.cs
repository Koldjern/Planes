﻿using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.People;

namespace TravelDomain.TravelAggregate.Entities.Planes;

public class TransportPlane : TravelPlane
{
	private TransportPlane(Guid id, Motor motor, double weightKg, double maxWeight, string name, double maxSpeed, IEnumerable<TravelEmployee> employees, double cargoWeight)
	: base(id, motor, weightKg, maxWeight, name, maxSpeed, employees, [])
	{
		CargoWeight = cargoWeight;
	}

	public double CargoWeight { get; set; }

	public static TransportPlane Create(Guid id, Motor motor, double weightKg, double maxWeight, string name, double maxSpeed, IEnumerable<TravelEmployee> employees, double cargoWeight)
	{
		var plane = new TransportPlane(id, motor, weightKg, maxWeight, name, maxSpeed, employees, cargoWeight);
		return plane;
	}
	public override double Weight()
	{
		return base.Weight() + CargoWeight;
	}
}
