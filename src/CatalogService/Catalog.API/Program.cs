using Catalog.API.Extensions;
using Catalog.API.Middleware;
using Catalog.BLL.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5224, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });

    options.ListenLocalhost(5225, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });
});

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddHostedService<MessageBrokerSubscriptionService>();

services
    .AddDatabase(builder.Configuration)
    .AddBLLServices()
    .AddMapper()
    .AddRepositories()
    .AddValidators()
    .AddRabbitMq()
    .AddGrpc();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapGrpcServices();
app.MapControllers();

app.Run();
