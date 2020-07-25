using MongoDB.Driver;
using ProductManagement.Domain.Models.Categories;
using ProductManagement.Domain.Models.Dimensions;
using ProductManagement.Domain.Models.Products;

namespace ProductManagement.Persistence.Mongo
{
    public interface IDbContext
    {
        public IMongoCollection<Dimension> Dimensions { get; }
        IMongoCollection<Product> Products { get; }
        IMongoCollection<MainCategory> MainCategories { get; }
    }
}