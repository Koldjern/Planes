using PeopleDomain.EmployeeAggregate;
using PeopleDomain.PassengerAggregate;
using SubApplication;

namespace PeopleApplication.Employees;

public interface IEmployeeRepository : ICrud<Employee, Guid>
{
}
