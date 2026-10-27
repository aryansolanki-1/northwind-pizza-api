using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetOrdersResponse
{
    public List<Order> Orders { get; set; } = null!;
}