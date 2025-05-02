using PeopleDomain.EmployeeAggregate;
using PeopleDomain.PassengerAggregate;
using SubApplication;

namespace PeopleApplication.Passengers;

public interface IPassengerRepository : ICrud<Passenger, Guid>
{
}
