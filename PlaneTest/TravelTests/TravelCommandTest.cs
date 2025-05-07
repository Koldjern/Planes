using Moq;
using TravelApplication.Travels;
using TravelApplication.Travels.Commands.StartFlight;
using TravelApplication.Travels.Responses;
using TravelDomain.TravelAggregate;
using TravelDomain.TravelAggregate.Entities.Employee;
using TravelDomain.TravelAggregate.Entities.Planes;
using TravelDomain.TravelAggregate.ValueObjects;

namespace TravelTests;

public class TravelCommandTest
{
	[Fact]
	public async Task HandleStartFlightGlider_WhenValid_Return()
	{
		var employee = new EmployeeResponse(Guid.NewGuid(), 100, 100, "Tester");
		var from = new Coordinate(1.001, 1.001);
		var to = new Coordinate(1.002, 1.002);
		var planeId = Guid.NewGuid();
		var command = new StartFlightCommand(planeId, from, to, [employee.Id], [], LaunchSpeed: 200, TicketCost: 200);
		var plane = new PlaneResponse(planeId, "Glider", null, 500, 700, "TesterGLider", 300);

		var planeApi = new Mock<IPlanesApi>();
		planeApi.Setup(x => x.GetPlane(It.IsAny<Guid>())).ReturnsAsync(plane);

		var peopleApi = new Mock<IPeopleApi>();
		peopleApi.Setup(x => x.GetEmployee(employee.Id)).ReturnsAsync(employee);

		var travelRepo = new Mock<ITravelRepository>();
		travelRepo.Setup(x => x.Add(It.IsAny<Travel>())).ReturnsAsync(true);

		var validator = new StartFlightCommandValidator();

		var handler = new StartFlightCommandHandler(planeApi.Object, peopleApi.Object, travelRepo.Object);

		var validation = await validator.ValidateAsync(command);

		var result = await handler.Handle(command, CancellationToken.None);

		Assert.True(validation.IsValid);
		Assert.False(result.IsError);
	}
}
