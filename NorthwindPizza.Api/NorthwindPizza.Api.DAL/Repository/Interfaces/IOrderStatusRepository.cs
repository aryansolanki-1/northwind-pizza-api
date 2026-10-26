using NorthwindPizza.Api.DAL.Models;

namespace NorthwindPizza.Api.DAL.Repository.Interfaces;

public interface IOrderStatusRepository
{
    Task<List<OrderStatus>> GetOrderStatusesAsync();

    Task<OrderStatus> GetOrderStatusAsync(int id);

    Task<OrderStatus> GetOrderStatusAsync(string name);

    Task<OrderStatus> AddOrderStatusAsync(OrderStatus orderStatus);

    Task<OrderStatus> UpdateOrderStatusAsync(OrderStatus orderStatus);

    Task<bool> DeleteOrderStatusAsync(int id);
}
