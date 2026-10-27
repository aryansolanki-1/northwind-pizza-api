using NorthwindPizza.Api.DTO.Models;
using NorthwindPizza.Api.DTO.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(CreateOrderRequest request);
    }
}
