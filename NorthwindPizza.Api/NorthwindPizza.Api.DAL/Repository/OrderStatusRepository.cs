using Microsoft.EntityFrameworkCore;
using NorthwindPizza.Api.DAL.Context;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;

namespace NorthwindPizza.Api.DAL.Repository;

public class OrderStatusRepository(NorthwindPizzaContext pizzaContext) : IOrderStatusRepository
{
    private readonly NorthwindPizzaContext context = pizzaContext;

    public async Task<OrderStatus> AddOrderStatusAsync(OrderStatus orderStatus)
    {
        this.context.OrderStatuses.Add(orderStatus);
        var result = await this.context.SaveChangesAsync();
        return result > 0 ? orderStatus : null!;
    }

    public async Task<bool> DeleteOrderStatusAsync(int id)
    {
        this.context.ChangeTracker.Clear();
        var orderStatusToDelete = await this.context.OrderStatuses.FirstOrDefaultAsync(os => os.OrderStatusId == id);
        this.context.OrderStatuses.Remove(orderStatusToDelete!);
        var result = await this.context.SaveChangesAsync();
        return result > 0;
    }

    public async Task<OrderStatus> GetOrderStatusAsync(int id)
    {
        var result = await this.context.OrderStatuses.FirstOrDefaultAsync(g => g.OrderStatusId == id);
        return result!;
    }

    public async Task<OrderStatus> GetOrderStatusAsync(string name)
    {
        var result = await this.context.OrderStatuses.FirstOrDefaultAsync(g => g.Name == name);
        return result!;
    }

    public async Task<List<OrderStatus>> GetOrderStatusesAsync()
    {
        var results = await this.context.OrderStatuses.Where(os => os.IsActive == 1).ToListAsync();
        return results;
    }

    public async Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus)
    {
        this.context.ChangeTracker.Clear();
        this.context.OrderStatuses.Update(orderStatus);
        var result = await this.context.SaveChangesAsync();
        return result > 0 ? orderStatus : null!;
    }
}
