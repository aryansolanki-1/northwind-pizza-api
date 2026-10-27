using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DTO.Request
{
    public class CreateOrderItemRequest
    {
        public int PizzaId { get; set; }

        public int Quantity { get; set; }
    }
}
