using ProductManagement.QueryModel;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Contracts
{
    public interface ICategoryQueryFacade
    {
        Task<MainCategoryQuery> GetMainCategoryById(int id);

        Task<CategoryQuery> GetCategoryById(int id);

        Task<LeafCategoryQuery> GetLeafCategoryById(int id);
    }
}