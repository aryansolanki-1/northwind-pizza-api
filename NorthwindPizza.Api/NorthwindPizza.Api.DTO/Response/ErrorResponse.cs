namespace NorthwindPizza.Api.DTO.Response;

public class ErrorResponse
{
    public int StatusCode { get; set; }

    public string Message { get; set; } = string.Empty;
}
