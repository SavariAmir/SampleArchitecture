using Microsoft.EntityFrameworkCore;
using ProductManagement.Interface.Facade.Contracts;
using ProductManagement.Persistence.EF;
using ProductManagement.QueryModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Query
{
    public class ProductQueryFacade : IProductQueryFacade
    {
        private readonly ProductManagementContext _context;

        public ProductQueryFacade(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<ProductQuery> GetProductById(int id)
        {
            var product = await _context.Products.Select(p => new ProductQuery
            {
                ProductId = p.Id,
                AtAGlance = p.Overview.AtAGlance,
                BrandId = p.BrandId,
                Description = p.Overview.Description,
                EnglishTitle = p.EnglishTitle,
                Title = p.Title,
                IsActive = p.IsActive
            }).FirstOrDefaultAsync(p => p.ProductId == id);

            return product;
        }
    }
}