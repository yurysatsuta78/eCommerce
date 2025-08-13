using Catalog.API.Extensions;
using Catalog.API.Middleware;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services
    .AddDatabase(builder.Configuration)
    .AddRepositories()
    .AddBLLServices()
    .AddAutomapperProfiles()
    .AddValidators();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();

app.UseAuthorization();
app.MapControllers();

app.Run();
