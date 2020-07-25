using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Dimensions
{
    public interface IDimensionRepository
    {
        void Add(Dimension dimension);

        void Update(Dimension dimension);

        Task<Dimension> GetByLeafCategoryId(int leafCategoryId);
    }
}