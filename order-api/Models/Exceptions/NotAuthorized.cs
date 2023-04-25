using System.Net;

namespace order_api.Models.Exceptions
{
    public class NotAuthorized : CustomException
    {
        public NotAuthorized(string message, List<string>? errors = null, HttpStatusCode statusCode = HttpStatusCode.Unauthorized) : base(message, errors, statusCode)
        {
        }
    }
}
