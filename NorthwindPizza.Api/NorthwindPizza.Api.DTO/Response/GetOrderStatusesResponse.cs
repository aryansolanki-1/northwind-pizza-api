using NorthwindPizza.Api.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DTO.Response
{
    public class GetOrderStatusesResponse
    {
        public List<OrderStatus> OrderStatuses { get; set; } = null!;
    }
}
