using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Products
{
    public interface IProductRepository
    {
        void Add(Product product);

        Task<Product> GetByIdAsync(string productId);

        Task<Product> GetByIdAsync(int productId);

        void Update(Product product);
    }
}