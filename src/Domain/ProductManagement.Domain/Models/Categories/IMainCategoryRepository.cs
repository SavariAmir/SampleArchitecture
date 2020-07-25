using System.Threading.Tasks;

namespace ProductManagement.Domain.Models.Categories
{
    public interface IMainCategoryRepository
    {
        void Add(MainCategory mainCategory);

        Task<MainCategory> GetByIdAsync(int mainCategoryId);

        void Update(MainCategory mainCategory);
    }
}