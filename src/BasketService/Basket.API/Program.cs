using Basket.API.Extensions;
using Basket.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddRedisCache(builder.Configuration)
    .AddRepositories()
    .AddBLLServices()
    .AddMapper();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseAuthorization();
app.MapControllers();

app.Run();
