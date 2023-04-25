using System.Net;

namespace order_api.Models.Exceptions
{
    public class EntityNotFoundException : CustomException
    {
        public EntityNotFoundException(string message, List<string>? errors = null, HttpStatusCode statusCode = HttpStatusCode.NotFound) : base(message, errors, statusCode)
        {
        }
    }

    public class EntityAlreadyExitsException : CustomException
    {
        public EntityAlreadyExitsException(string message, List<string>? errors = null, HttpStatusCode statusCode = HttpStatusCode.Conflict) : base(message, errors, statusCode)
        {
        }
    }
}
