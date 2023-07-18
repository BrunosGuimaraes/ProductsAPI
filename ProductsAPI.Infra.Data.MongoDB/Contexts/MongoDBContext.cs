using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProductsAPI.Application.Models.Queries;
using ProductsAPI.Infra.Data.MongoDB.Settings;
using System.Security.Authentication;

namespace ProductsAPI.Infra.Data.MongoDB.Contexts
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings? _mongoDBSettings;
        private IMongoDatabase? _mongoDatabase;
        public MongoDBContext(IOptions<MongoDBSettings>? mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings?.Value;

            var client = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings?.Host));
            if(_mongoDBSettings.IsSSL)
            {
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = SslProtocols.Tls12
                };
            }
            _mongoDatabase = new MongoClient(client).GetDatabase(_mongoDBSettings.Name);
        }

        public IMongoCollection<ProductsDTO> Products => _mongoDatabase?.GetCollection<ProductsDTO>("Products");
    }
}
