using Newtonsoft.Json;

namespace NorthwindPizza.Api.DTO.Models;

public class Pizza
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("description")]
    public string? Description { get; set; }

    [JsonProperty("basePrice")]
    public decimal BasePrice { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; } = string.Empty;

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}
