namespace CoolSprings.DTO.Res;

public class ApiResponse
{
    public ApiResponse(HttpStatusCode statusCode, bool success = false, object data = null, string message = "")
    {
        StatusCode = statusCode;
        Success = success;
        Data = data;
        Message = message;
    }

    public HttpStatusCode StatusCode { get; set; }
    public bool Success { get; set; }
    public object Data { get; set; }
    public string Message { get; set; }
}