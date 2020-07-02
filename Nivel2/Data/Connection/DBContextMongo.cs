using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Nivel2.Domain.Models;

namespace Nivel2.Data.Connection
{
    public class DBContextMongo
    {
        private readonly string _connectionString;
        private readonly string _databaseName;
        private IMongoClient _client;
        private IMongoDatabase _dataBase;

        public DBContextMongo(IConfiguration configuration)
        {
            _connectionString = configuration["MongoDB:connection"];
            _databaseName = configuration["MongoDB:name"];

            Connection();
        }

        public void Connection()
        {
            _client = new MongoClient(_connectionString);
            _dataBase = _client.GetDatabase(_databaseName);
        }

        public IMongoCollection<Cart> Carts
        {
            get
            {
                return _dataBase.GetCollection<Cart>("Carts");
            }
        }
    }
}