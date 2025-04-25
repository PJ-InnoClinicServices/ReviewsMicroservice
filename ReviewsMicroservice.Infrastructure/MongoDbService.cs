using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Infrastructure;

public class MongoDbService
{
    public MongoDbService(IConfiguration configuration)
    {
        
        var environment = configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT");

        string dbConnection;
        dbConnection = environment == "Container" ? Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION") : configuration.GetValue<string>("DbConnection");
        var mongoUrl = MongoUrl.Create(dbConnection);
        var mongoClient = new MongoClient(mongoUrl);
        Database = mongoClient.GetDatabase(mongoUrl.ApplicationName);
    }

    public IMongoDatabase Database { get; }
}