using MongoDB.Driver;
using ProductManagement.Domain.Models.Products;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.Mongo
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;

        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(string productId)
        {
            return await _context.Products.Find(product => product.Id.ToString() == productId).FirstOrDefaultAsync();
        }

        public Task<Product> GetByIdAsync(int productId)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product product)
        {
            _context.Products.ReplaceOne(p => p.Id == product.Id, product);
        }
    }
}