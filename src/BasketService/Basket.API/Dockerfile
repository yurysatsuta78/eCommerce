FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY BasketService/Basket.API/Basket.API.csproj BasketService/Basket.API/
COPY BasketService/Basket.BLL/Basket.BLL.csproj BasketService/Basket.BLL/
COPY BasketService/Basket.DAL/Basket.DAL.csproj BasketService/Basket.DAL/
COPY MessageBrokerAbstractionService/MessageBroker.Abstraction/MessageBroker.Abstraction.csproj MessageBrokerAbstractionService/MessageBroker.Abstraction/
COPY MessageBrokerAbstractionService/MessageBroker.RabbitMQ/MessageBroker.RabbitMQ.csproj MessageBrokerAbstractionService/MessageBroker.RabbitMQ/

RUN dotnet restore "BasketService/Basket.API/Basket.API.csproj"
COPY . .

RUN dotnet publish "BasketService/Basket.API/Basket.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Basket.API.dll"]