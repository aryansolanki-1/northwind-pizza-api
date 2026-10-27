using NorthwindPizza.Api.DAL.Models;
using NorthwindPizza.Api.DAL.Repository.Interfaces;
using NorthwindPizza.Api.DTO.Request;
using NorthwindPizza.Api.Services.Interfaces;

namespace NorthwindPizza.Api.Services
{
    public class OrderService(
        IOrderRepository orderRepo,
        ICustomerRepository customerRepo,
        IPizzaRepository pizzaRepo) : IOrderService
    {
        private readonly IOrderRepository orderRepo = orderRepo;

        private readonly ICustomerRepository customerRepo = customerRepo;

        private readonly IPizzaRepository pizzaRepo = pizzaRepo;
        
        public async Task<DTO.Models.Order?> CreateOrderAsync(CreateOrderRequest request)
        {
            if (request.CustomerId <= 0 ||
           request.Items is null ||
           request.Items.Count == 0 ||
           request.Items.Any(i => i.PizzaId <= 0 || i.Quantity <= 0) ||
           request.Items.GroupBy(i => i.PizzaId)
               .Any(g => g.Count() > 1))
            {
                throw new ArgumentException("The order request is invalid.");
            }

            // Verify the customer exists.
            var customer = await customerRepo.GetCustomerAsync(request.CustomerId);

            if (customer is null)
            {
                throw new KeyNotFoundException("Customer not found.");
            }

            var orderItems = new List<OrderItem>();
            decimal totalAmount = 0;

            foreach (var requestedItem in request.Items)
            {
                var pizza = await pizzaRepo.GetPizzaAsync(requestedItem.PizzaId);

                if (pizza is null)
                {
                    throw new KeyNotFoundException(
                        $"Pizza {requestedItem.PizzaId} not found.");
                }

                if (!pizza.ToDto().IsActive)
                {
                    throw new ArgumentException(
                        $"Pizza {requestedItem.PizzaId} is inactive.");
                }

                var unitPrice = pizza.BasePrice;
                var lineTotal = unitPrice * requestedItem.Quantity;

                orderItems.Add(new OrderItem
                {
                    PizzaId = pizza.PizzaId,
                    Quantity = requestedItem.Quantity,
                    UnitPrice = unitPrice,
                    LineTotal = lineTotal
                });

                totalAmount += lineTotal;
            }

            var order = new DAL.Models.Order
            {
                CustomerId = request.CustomerId,
                OrderStatusId = 1, // Assumes 1 = Pending
                TotalAmount = totalAmount
            };

            var dbOrder = await this.orderRepo.CreateOrderAsync(order, orderItems);

            return dbOrder.ToDto();
        }
    }
}
