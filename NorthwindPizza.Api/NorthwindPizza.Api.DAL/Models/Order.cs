namespace NorthwindPizza.Api.DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int OrderStatusId { get; set; }

    public string OrderDate { get; set; } = string.Empty;

    public decimal TotalAmount { get; set; }
}
