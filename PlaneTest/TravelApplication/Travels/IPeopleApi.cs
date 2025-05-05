using TravelApplication.Travels.Responses;

namespace TravelApplication.Travels;

public interface IPeopleApi
{
	Task<EmployeeResponse?> GetEmployee(Guid id);
	Task<PassengerRespone?> GetPassenger(Guid id);
}
