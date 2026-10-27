using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

public interface IEmployeeRepository
{
    Task<List<Employee>> GetAllEmployeesAsync();
}
