using MongoDB.Driver;
using ProductManagement.Domain.Models.Categories;
using ProductManagement.Domain.Models.Dimensions;
using ProductManagement.Domain.Models.Products;

namespace ProductManagement.Persistence.Mongo
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database;

        public IMongoCollection<Product> Products => GetCollection<Product>("Products");
        public IMongoCollection<MainCategory> MainCategories => GetCollection<MainCategory>("MainCategories");
        public IMongoCollection<Dimension> Dimensions => GetCollection<Dimension>("Dimensions");

        public DbContext(IProductManagementDatabaseSettings settings)
        {
            _database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>(string name)
        {
            return _database.GetCollection<TEntity>(name);
        }
    }
}