using Moq;
using PlaneApplication.Planes;
using PlaneApplication.Planes.Commands.Add;
using PlaneApplication.Planes.Commands.Update;
using PlaneDomain.PlaneAggregate;
using PlaneDomain.PlaneAggregate.Entities;

namespace PlaneTests;

public class PlaneCommandsTests
{
	[Fact]
	public async Task HandleAddPlane_WhenRequestValid_ShouldReturnId()
	{
		var command = new AddPlaneCommand(
			Type: PlaneType.PrivatePlane,
			MotorName: "TestMotor",
			Power: 100,
			Consumption: 50,
			WeightKg: 500,
			MaxWeight: 1000,
			Name: "TestPlane",
			MaxSpeed: 750);

		var repo = new Mock<IPlaneRepository>();
		repo.Setup(x => x.Add(It.IsAny<Plane>())).ReturnsAsync(true);

		var handler = new AddPlaneCommandHandler(repo.Object);

		var result = await handler.Handle(command, CancellationToken.None);

		Assert.False(result.IsError);
		Assert.True(result.Value != Guid.Empty);
	}

	[Fact]
	public async Task HandleUpdatePlane_WhenRequestValid_ShouldReturn()
	{
		var motor = Motor.CreateNew(
			name: "TestMotor",
			power: 100,
			consumption: 50);

		var plane = Plane.CreateNew(
			motor: motor,
			type: PlaneType.PrivatePlane,
			weightKg: 500,
			maxWeight: 1000,
			name: "TestPlane",
			maxSpeed: 750);

		var command = new UpdatePlaneCommand(
			Id: plane.Id,
			MotorId: motor.Id,
			MotorName: "TestMotor",
			Power: 100,
			Consumption: 50,
			Type: PlaneType.PrivatePlane,
			WeightKg: 500,
			MaxWeight: 1000,
			Name: "TestPlane",
			MaxSpeed: 750);

		var repo = new Mock<IPlaneRepository>();
		repo.Setup(x => x.Update(It.IsAny<Plane>())).ReturnsAsync(true);
		repo.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(plane);

		var handler = new UpdatePlaneCommandHandler(repo.Object);

		var result = await handler.Handle(command, CancellationToken.None);

		Assert.False(result.IsError);
	}
}
