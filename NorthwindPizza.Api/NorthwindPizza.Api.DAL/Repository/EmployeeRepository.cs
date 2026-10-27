using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

namespace NorthwindPizza.Api.DAL.Repository;

public class EmployeeRepository(NorthwindPizzaContext context) : IEmployeeRepository
{
    private readonly NorthwindPizzaContext context = context;

    public async Task<List<Employee>> GetAllEmployeesAsync()
    {
        var dbResults = await this.context.Employees.Where(g => g.IsActive == 1).ToListAsync();
        return dbResults!;
    }
}
