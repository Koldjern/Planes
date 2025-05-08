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
		_plane = plane;
		From = from;
		To = to;
		TicketCost = ticketCost;
		FlightBegun = flightBegun;
	}

	private TravelPlane _plane;
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
	public virtual double SpeedKm() => _plane.SpeedKm();

	public virtual double SpeedMiles() => _plane.SpeedMiles();

	public decimal TotalWages()
	{
		return _plane.Employees.Sum(e => e.HourWage) * (decimal)TimeLeft().TotalHours;
	}

	public decimal TotalTickets()
	{
		return _plane.Passengers.Count() * TicketCost;
	}

	public TimeSpan TimeLeft()
	{
		var hours = DistanceKM() / _plane.SpeedKm();
		var flightends = FlightBegun.AddHours(hours);
		return flightends.Subtract(DateTime.UtcNow);
	}

	public bool TooHeavy()
	{
		return _plane.Weight() > _plane.MaxWeight;
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
		if (_plane.Motor is null)
			return 0;
		return DistanceKM() / 100 * _plane.Motor.Consumption;
	}
#pragma warning disable CS8618, SA1201
	private Travel()
	{
	}
#pragma warning restore CS8618, SA1201
}
