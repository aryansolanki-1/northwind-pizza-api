namespace NorthwindPizza.Api.DAL.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int IsActive { get; set; }
}
