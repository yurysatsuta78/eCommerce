using Microsoft.EntityFrameworkCore;
using Orders.API.Middleware;
using Orders.Application.DI;
using Orders.Infrastructure.Data;
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

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<OrdersDbContext>();
    db.Database.Migrate();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
