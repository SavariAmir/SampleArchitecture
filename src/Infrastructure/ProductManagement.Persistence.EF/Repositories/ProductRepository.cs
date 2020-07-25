using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Models.Products;
using System;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.EF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductManagementContext _context;

        public ProductRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Add(product);
        }

        public Task<Product> GetByIdAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }
    }
}