using MediatR;
using Microsoft.Extensions.Logging;
using PeopleDomain.PassengerAggregate.Events;

namespace PeopleApplication.Passengers.Events;

public class PassengerAddedHandler : INotificationHandler<PassengerAdded>
{
	private readonly ILogger<PassengerAddedHandler> _logger;

	public PassengerAddedHandler(ILogger<PassengerAddedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(PassengerAdded notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Passenger created at Date: {DateTime.UtcNow}, \nPassenger id: {notification.Passenger.Id} {notification.Passenger}");
		return Task.CompletedTask;
	}
}
