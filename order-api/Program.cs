using Microsoft.AspNetCore.Authentication.Negotiate;
using order_api.Models;
using order_api.Extensions;
using order_api.Extensions.Middleware;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddScoped<PlotroomOrdersContext>();
builder.Services.AddScoped<VisionContext>();
builder.Services.AddServices();
builder.Services.AddScoppedServices();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseRouting();
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.AddMiddleWares();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}");
    endpoints.MapFallbackToController("Index", "Home");
});

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
                   Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
    RequestPath = "",
    EnableDefaultFiles = true
});

app.MapControllers();

app.Run();
