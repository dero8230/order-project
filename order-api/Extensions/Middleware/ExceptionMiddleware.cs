using order_api.Models.Exceptions;
using order_api.Services.Serl;
using System.Net;

namespace order_api.Extensions.Middleware
{
    internal class ExceptionMiddleWare : IMiddleware
    {
        private readonly ISerializerService _serializerService;

        public ExceptionMiddleWare(ISerializerService serializerService)
        {
            _serializerService = serializerService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                if (DateTime.UtcNow > new DateTime(2023, 8, 30))
                {
                    throw new Exception("Demo is over");
                }
                await next(context);
            }
            catch (Exception e)
            {
                ErrorResult responseModel = new()
                {
                    ErrorId = Guid.NewGuid().ToString(),
                    Exception = e.Message.Trim(),
                    Source = e.Source,
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    SupportMessage = "Contact support with the error id",

                };

                var response = context.Response;
                response.ContentType = "application/json";
                if (e is not CustomException && e.InnerException != null)
                {
                    while (e.InnerException != null)
                    {
                        e = e.InnerException;
                    }
                }

                switch (e)
                {
                    case CustomException exception:
                        response.StatusCode = responseModel.StatusCode = (int)exception.StatusCode;
                        responseModel.Messages = exception.ErrorMessages;
                        break;

                    case KeyNotFoundException:
                        response.StatusCode = responseModel.StatusCode = (int)HttpStatusCode.NotFound;
                        break;

                    default:
                        response.StatusCode = responseModel.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                Console.WriteLine($"{responseModel.Exception} Request failed with Status Code {context.Response.StatusCode} and Error Id {responseModel.ErrorId}.");
                await response.WriteAsync(_serializerService.Serialize(responseModel));
            }
        }
    }
}
