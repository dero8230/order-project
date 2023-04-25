using Microsoft.AspNetCore.Authentication.Negotiate;
using order_api.Models;
using order_api.Extensions;
using order_api.Extensions.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddSingleton<PlotroomOrdersContext>(new PlotroomOrdersContext());
builder.Services.AddSingleton<VisionContext>(new VisionContext());
builder.Services.AddServices();
builder.Services.AddScoppedServices();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.AddMiddleWares();
app.MapControllers();

app.Run();
