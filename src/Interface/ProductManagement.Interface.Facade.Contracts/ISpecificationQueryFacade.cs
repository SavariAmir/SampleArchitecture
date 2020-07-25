using ProductManagement.QueryModel;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Contracts
{
    public interface ISpecificationQueryFacade
    {
        Task<SpecificationQuery> GetSpecificationByLeafCategoryId(int leafCategoryId);
    }
}