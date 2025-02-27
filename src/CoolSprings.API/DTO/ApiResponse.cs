using System.Net;

namespace CoolSprings.API.DTO
{
    public class ApiResponse

    {

        public ApiResponse(HttpStatusCode code, bool state, object apiData, string message )
        {

        }
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
