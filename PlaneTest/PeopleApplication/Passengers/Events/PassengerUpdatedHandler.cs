using MediatR;
using Microsoft.Extensions.Logging;
using PeopleDomain.PassengerAggregate.Events;

namespace PeopleApplication.Passengers.Events;

public class PassengerUpdatedHandler : INotificationHandler<PassengerUpdated>
{
	private readonly ILogger<PassengerUpdatedHandler> _logger;

	public PassengerUpdatedHandler(ILogger<PassengerUpdatedHandler> logger)
	{
		_logger = logger;
	}

	public Task Handle(PassengerUpdated notification, CancellationToken cancellationToken)
	{
		_logger.LogInformation($"Passenger updated at Date: {DateTime.UtcNow}, Passenger id: {notification.After.Id}, \nPassenger Before: ({notification.Before})\nPassenger After: ({notification.After})");
		return Task.CompletedTask;
	}
}
