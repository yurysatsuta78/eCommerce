using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Payment.DAL.Options;
using Payment.DAL.Repositories.Implementations;
using Payment.DAL.Repositories.Interfaces;

namespace Payment.API.Extensions
{
    public static class MongoDbExtension
    {
        public static IServiceCollection AddMongoDb(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration["PAYMENT_CONNECTION"]
                ?? throw new InvalidOperationException($"Payment service connection string not found in configuration.");

            var databaseName = configuration["PAYMENT_DATABASE_NAME"]
                ?? throw new InvalidOperationException($"Payment service database name not found in configuration.");

            var mongoOptions = new MongoOptions
            {
                ConnectionString = connectionString,
                DatabaseName = databaseName,
                ReceiptsCollectionName = "Receipts"
            };

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            services.AddSingleton(mongoOptions);
            services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoOptions.ConnectionString));
            services.AddSingleton(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase(mongoOptions.DatabaseName);
            });

            services.AddScoped<IReceiptRepository, ReceiptRepository>();

            return services;
        }
    }
}
