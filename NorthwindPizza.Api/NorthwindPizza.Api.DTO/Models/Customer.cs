using Newtonsoft.Json;

namespace NorthwindPizza.Api.DTO.Models;

public class Customer
{
    [JsonProperty("customerId")]
    public int CustomerId { get; set; }

    [JsonProperty("firstName")]
    public string FirstName { get; set; } = string.Empty;

    [JsonProperty("lastName")]
    public string LastName { get; set; } = string.Empty;

    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    [JsonProperty("phone")]
    public string? Phone { get; set; }
}
