using ProductManagement.QueryModel;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Contracts
{
    public interface IDimensionQueryFacade
    {
        Task<DimensionQuery> GetDimensionByLeafCategoryId(int leafCategoryId);
    }
}