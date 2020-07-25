using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Specifications
{
    public interface ISpecificationRepository
    {
        Task<Specification> GetByLeafCategoryId(int leafCategoryId);

        void Add(Specification specification);
    }
}