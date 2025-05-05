using SubDomain.Models;
using TravelDomain.TravelAggregate.Entities.Planes;
using TravelDomain.TravelAggregate.Events;
using TravelDomain.TravelAggregate.ValueObjects;

namespace TravelDomain.TravelAggregate;

public class Travel : AggregateRoot<Guid>
{
	private Travel(Guid id, TravelPlane plane, Coordinate from, Coordinate to, decimal ticketCost, DateTime flightBegun)
		: base(id)
	{
		Plane = plane;
		From = from;
		To = to;
		TicketCost = ticketCost;
		FlightBegun = flightBegun;
	}

	public TravelPlane Plane { get; private set; }
	public Coordinate From { get; private set; }
	public Coordinate To { get; private set; }
	public decimal TicketCost { get; private set; }
	public DateTime FlightBegun { get; private set; }
	public DateTime FlightEnds { get; private set; }

	public static Travel CreateNew(TravelPlane plane, Coordinate from, Coordinate to, decimal ticketCost)
	{
		Travel travel = new Travel(Guid.NewGuid(), plane, from, to,	ticketCost, DateTime.UtcNow);
		travel.FlightEnds = travel.FlightBegun.Add(travel.TimeLeft());
		travel.AddDomainEvent(new TravelEnded(travel));
		return travel;
	}

	public decimal TotalWages()
	{
		return Plane.Employees.Sum(e => e.HourWage);
	}

	public decimal TotalTickets()
	{
		return Plane.Passengers.Count() * TicketCost;
	}

	public TimeSpan TimeLeft()
	{
		var hours = DistanceKM() / Plane.SpeedKm();
		var flightends = FlightBegun.AddHours(hours);
		return flightends.Subtract(FlightBegun);
	}

	public bool TooHeavy()
	{
		return Plane.Weight() > Plane.MaxWeight;
	}

	public double DistanceKM()
	{
		return Coordinate.DistanceMeters(From, To) / 1000;
	}

	public double DistanceMiles()
	{
		return Coordinate.DistanceMeters(From, To) / 1609.344;
	}

	public double FuelConsumption()
	{
		if (Plane.Motor is null)
			return 0;
		return DistanceKM() / 100 * Plane.Motor.Consumption;
	}
}
