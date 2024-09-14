

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

public class MongoDbConfig
    {
        public  string ConnectionString { get; set; }
        public  string DatabaseName { get; set; }

        private readonly IMongoDatabase _database;

        public MongoDbConfig(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;

              // Configure the serializer for Guid to use UUID representation
            BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(GuidRepresentation.Standard));
            var client = new MongoClient(ConnectionString);
            _database = client.GetDatabase(DatabaseName);
        }

        public IMongoCollection<User> GetUsersCollection()
        {
            return _database.GetCollection<User>("users");
        }
    }


