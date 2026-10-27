using NorthwindPizza.Api.DTO.Models;

namespace NorthwindPizza.Api.DTO.Response;

public class GetPizzaResponse
{
    public Pizza Pizza { get; set; } = null!;
}
