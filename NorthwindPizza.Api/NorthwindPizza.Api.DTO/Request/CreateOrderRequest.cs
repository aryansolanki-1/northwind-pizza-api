using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DTO.Request
{
    public class CreateOrderRequest
    {
        public int CustomerId { get; set; }

        public List<CreateOrderItemRequest> Items { get; set; } = null!;
    }
}
