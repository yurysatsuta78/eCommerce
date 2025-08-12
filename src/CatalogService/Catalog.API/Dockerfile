FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY CatalogService/Catalog.API/Catalog.API.csproj CatalogService/Catalog.API/
COPY CatalogService/Catalog.BLL/Catalog.BLL.csproj CatalogService/Catalog.BLL/
COPY CatalogService/Catalog.DAL/Catalog.DAL.csproj CatalogService/Catalog.DAL/
COPY MessageBrokerAbstractionService/MessageBroker.Abstraction/MessageBroker.Abstraction.csproj MessageBrokerAbstractionService/MessageBroker.Abstraction/
COPY MessageBrokerAbstractionService/MessageBroker.RabbitMQ/MessageBroker.RabbitMQ.csproj MessageBrokerAbstractionService/MessageBroker.RabbitMQ/
COPY GrpcContracts/Grpc.Contracts/Grpc.Contracts.csproj GrpcContracts/Grpc.Contracts/

RUN dotnet restore "CatalogService/Catalog.API/Catalog.API.csproj"
COPY . .

RUN dotnet publish "CatalogService/Catalog.API/Catalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "Catalog.API.dll"]