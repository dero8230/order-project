using System.Net;

namespace order_api.Models.Exceptions
{
    public class CustomException : Exception
    {
        public List<string> ErrorMessages { get; } = new();

        public HttpStatusCode StatusCode { get; }

        public CustomException(string message, List<string>? errors = default, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
            : base(message)
        {
            ErrorMessages = errors ?? new List<string>();
            StatusCode = statusCode;
        }
    }

    public class ErrorResult
    {
        public string? Source { get; set; }
        public bool Success { get; set; } = false;
        public string? Exception { get; set; }
        public object? Data { get; set; } = null;
        public string? ErrorId { get; set; }
        public string? SupportMessage { get; set; }
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; } = new();
    }
}
