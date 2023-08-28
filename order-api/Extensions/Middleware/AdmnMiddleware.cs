using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using order_api.Models;
using order_api.Models.Attributes;
using order_api.Models.Exceptions;

namespace order_api.Extensions.Middleware
{
    public class AdmnMiddleware : IMiddleware
    {
        private readonly PlotroomOrdersContext _db;

        public AdmnMiddleware(PlotroomOrdersContext db)
        {
            _db = db;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null) {
              
                var controllerActionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();

                if (controllerActionDescriptor != null)
                {
                    if (controllerActionDescriptor.MethodInfo.GetCustomAttributes(true).OfType<MustBeAdmin>().Any())
                    {
                        var username = context.User?.Identity?.Name;
                        bool isAdmin = await _db.OrderAdmins.AnyAsync(x => x.DomainUserName == username);
                        if (!isAdmin) throw new EntityNotFoundException("Requested path does not exist");
                    }
                }
            }
            await next(context);
        }
    }
}
