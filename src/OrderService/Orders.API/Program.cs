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

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
