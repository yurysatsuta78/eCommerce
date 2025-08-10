FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY OrderService/Orders.API/Orders.API.csproj OrderService/Orders.API/
COPY OrderService/Orders.Infrastructure/Orders.Infrastructure.csproj OrderService/Orders.Infrastructure/
COPY OrderService/Orders.Application/Orders.Application.csproj OrderService/Orders.Application/
COPY OrderService/Orders.Domain/Orders.Domain.csproj OrderService/Orders.Domain/
COPY MessageBrokerAbstractionService/MessageBroker.Abstraction/MessageBroker.Abstraction.csproj MessageBrokerAbstractionService/MessageBroker.Abstraction/
COPY MessageBrokerAbstractionService/MessageBroker.RabbitMQ/MessageBroker.RabbitMQ.csproj MessageBrokerAbstractionService/MessageBroker.RabbitMQ/

RUN dotnet restore "OrderService/Orders.API/Orders.API.csproj"
COPY . .

RUN dotnet publish "OrderService/Orders.API/Orders.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Orders.API.dll"]