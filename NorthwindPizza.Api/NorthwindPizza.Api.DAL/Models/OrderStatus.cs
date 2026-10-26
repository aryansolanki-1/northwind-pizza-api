namespace NorthwindPizza.Api.DAL.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int DisplayOrder { get; set; }

    public int IsActive { get; set; }
}

public static class OrderStatusExtensions
{
    public static DTO.Models.OrderStatus ToDto(this OrderStatus value)
    {
        return new DTO.Models.OrderStatus
        {
            Id = value.OrderStatusId,
            Name = value.Name,
            Description = value.Description,
            DisplayOrder = value.DisplayOrder,
            IsActive = value.IsActive == 1
        };
    }
}
