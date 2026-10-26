using NorthwindPizza.Api.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DTO.Response
{
    public class GetOrderStatusResponse
    {
        public OrderStatus OrderStatus { get; set; } = null!;
    }
}
