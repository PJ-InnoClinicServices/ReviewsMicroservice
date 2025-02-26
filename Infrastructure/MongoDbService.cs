using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

public class MongoDbService
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _database;
    private readonly IConfiguration _configuration;

    public MongoDbService(IConfiguration configuration)
    {
        
        _configuration = configuration;
        var dbConnection = _configuration.GetValue<string>("DbConnection");
        var mongoUrl = MongoUrl.Create(dbConnection);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.ApplicationName);
    }

    public IMongoDatabase Database => _database;
}