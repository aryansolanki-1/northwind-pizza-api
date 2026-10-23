namespace NorthwindPizza.Api.DAL.Models;

public partial class Pizza
{
    public int PizzaId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int IsActive { get; set; }
}
