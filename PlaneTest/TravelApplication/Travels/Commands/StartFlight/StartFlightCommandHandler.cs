using ErrorOr;
using MediatR;
using TravelApplication.Travels.Responses;
using TravelDomain.TravelAggregate;
using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.People;
using TravelDomain.TravelAggregate.Entities.Planes;
using TravelDomain.TravelAggregate.Errors;

namespace TravelApplication.Travels.Commands.StartFlight;

public class StartFlightCommandHandler : IRequestHandler<StartFlightCommand, ErrorOr<TravelResponse>>
{
	private readonly IPlanesApi _planesApi;
	private readonly IPeopleApi _peopleApi;
	private readonly ITravelRepository _travelRepository;

	public StartFlightCommandHandler(IPlanesApi planesApi, IPeopleApi peopleApi, ITravelRepository travelRepository)
	{
		_planesApi = planesApi;
		_peopleApi = peopleApi;
		_travelRepository = travelRepository;
	}

	public async Task<ErrorOr<TravelResponse>> Handle(StartFlightCommand request, CancellationToken cancellationToken)
	{
		var planeResponse = await _planesApi.GetPlane(request.PlaneId);
		if (planeResponse is null)
			return Errors.Travel.PlaneNotFound;

		var employeeResponses = await Task.WhenAll(request.Employees.Select(_peopleApi.GetEmployee));
		if (employeeResponses.Any(r => r is null))
			return Errors.Travel.EmployeeNotFound;
		var employees = employeeResponses.Select(res => TravelEmployee.Create(res!.Id, res.JobTitle, res.Weight, res.HourWage));

		var passengerResponses = await Task.WhenAll(request.Passengers.Select(_peopleApi.GetPassenger));
		if (passengerResponses.Any(r => r is null))
			return Errors.Travel.PassengerNotFound;
		var passengers = passengerResponses.Select(res => TravelPassenger.Create(res!.Id, res.Weight));

		var plane = MakePlane(planeResponse, employees, passengers, request.LaunchSpeed, request.WeightOfWeaponry, request.CargoWeight);

		if (plane.IsError)
			return plane.Errors;

		if (plane.Value is null)
			return Errors.Travel.ErrorHandlingPlane;

		var travel = Travel.CreateNew(plane.Value, request.From, request.To, request.TicketCost);

		if (travel.TooHeavy())
			return Errors.Travel.PlaneTooHeavy(plane.Value.MaxWeight, plane.Value.Weight());

		await _travelRepository.Add(travel);

		return new TravelResponse(
			travel.Id,
			travel.TotalWages(),
			travel.TotalTickets(),
			travel.FuelConsumption(),
			travel.TimeLeft(),
			travel.DistanceKM(),
			travel.FlightEnds);
	}

	private ErrorOr<TravelPlane?> MakePlane(PlaneResponse response, IEnumerable<TravelEmployee> employees, IEnumerable<TravelPassenger> passengers, double? launchSpeed, double? weightOfWeaponry, double? cargoWeight)
	{
		switch (response.Type)
		{
			case "Glider":
				{
					if (launchSpeed is null)
						return Error.Validation("Glider.LaunchSpeed.Missing", "Launch speed is required for gliders.");

					if (passengers.Count() > 1)
						return Error.Validation("Glider.Too.Many", "Only 1 passenger allowed, for gliders.");

					var pilot = employees.First();
					var passenger = passengers.FirstOrDefault();

					return GliderPlane.Create(
						response.Id,
						response.WeightKg,
						response.MaxWeight,
						response.Name,
						response.MaxSpeed,
						launchSpeed.Value,
						pilot,
						passenger);
				}
			case "PrivatePlane":
				{
					return PrivatePlane.Create(
						response.Id,
						response.WeightKg,
						response.MaxWeight,
						response.Name,
						response.MaxSpeed,
						employees,
						passengers);
				}

			case "PassengerPlane":
				{
					if (passengers.Count() == 0)
						return Error.Validation("PassengerPlane.No.Passengers", "No Passengers on a passenger plane Not allowed");

					return PassengerPlane.Create(
						response.Id,
						response.WeightKg,
						response.MaxWeight,
						response.Name,
						response.MaxSpeed,
						employees,
						passengers);
				}
			case "TransportPlane":
				{
					if (cargoWeight == null)
						return Error.Validation("TransportPlane.No.Cargo", "No Cargo on a transport plane Not allowed");

					return TransportPlane.Create(
						response.Id,
						response.WeightKg,
						response.MaxWeight,
						response.Name,
						response.MaxSpeed,
						employees,
						cargoWeight.Value);
				}
			case "JetFighter":
				{
					if (weightOfWeaponry is null)
						return Error.Validation("JetFighter.WeightOfWeaponry.Missing", "weight Of Weaponry is required for JetFighters.");

					if (passengers.Count() > 1)
						return Error.Validation("JetFighter.Passengers", "No passengers allowed, for JetFighters.");

					var pilot = employees.First();

					return JetFighter.Create(
						response.Id,
						response.WeightKg,
						response.MaxWeight,
						response.Name,
						response.MaxSpeed,
						weightOfWeaponry.Value,
						pilot);
				}
			default:
				return Error.Validation("Plane.Type.Unknown", $"Plane type '{response.Type}' is not supported.");
		}
	}
}
