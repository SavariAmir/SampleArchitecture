using ProductManagement.QueryModel;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Contracts
{
    public interface IProductQueryFacade
    {
        Task<ProductQuery> GetProductById(int id);
    }
}