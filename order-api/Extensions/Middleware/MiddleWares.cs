namespace order_api.Extensions.Middleware
{
    public static class MiddleWares
    {
        public static IApplicationBuilder AddMiddleWares(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleWare>();
            return app;
        }
    }
}
