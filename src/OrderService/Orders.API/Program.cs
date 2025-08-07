using Orders.API.Middleware;
using Orders.Application.DI;
using Orders.Infrastructure.DI;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddDatabase(builder.Configuration)
    .AddMediatR()
    .AddAutoMapper()
    .AddRepositories()
    .AddValidators();

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
