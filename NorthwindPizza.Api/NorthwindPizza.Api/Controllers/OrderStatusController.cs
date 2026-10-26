using Microsoft.AspNetCore.Mvc;
using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Response;

namespace NorthwindPizza.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderStatusController(IOrderStatusRepository orderStatusRepo, ILogger<OrderStatusController> logger) 
    : ControllerBase
{
    private readonly ILogger<OrderStatusController> logger = logger;

    private readonly IOrderStatusRepository orderStatusRepo = orderStatusRepo;

    [HttpGet("GetOrderStatuses")]
    public async Task<ActionResult<GetOrderStatusesResponse>> GetAllOrderStatusesAsync()
    {
        this.logger.LogInformation("Getting the order statuses from the database.");

        var dbOrderStatuses = await this.orderStatusRepo.GetOrderStatusesAsync();

        if (dbOrderStatuses is null)
        {
            return this.NotFound("The order statuses cannot be found!");
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetOrderStatusesResponse
        {
            OrderStatuses = dbOrderStatuses.Select(x => x.ToDto()).ToList()
        });
    }

    [HttpGet("GetOrderStatus/{id}")]
    public async Task<ActionResult<GetOrderStatusResponse>> GetOrderStatusByIdAsync([FromRoute] int id)
    {
        this.logger.LogInformation("Getting the order status by the ID");

        var dbOrderStatus = await this.orderStatusRepo.GetOrderStatusAsync(id);

        if (dbOrderStatus is null)
        {
            return this.NotFound("The order status cannot be found!");
        }

        return this.StatusCode(StatusCodes.Status200OK, new GetOrderStatusResponse
        {
            OrderStatus = dbOrderStatus.ToDto()
        });
    }
}
