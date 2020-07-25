using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Models.Categories;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.EF.Repositories
{
    public class MainCategoryRepository : IMainCategoryRepository
    {
        private readonly ProductManagementContext _context;

        public MainCategoryRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public void Add(MainCategory mainCategory)
        {
            _context.Add(mainCategory);
        }

        public async Task<MainCategory> GetByIdAsync(int mainCategoryId)
        {
            var mainCategory = await _context.MainCategories
                                          .Include(p => p.SubCategories)
                                                .FirstOrDefaultAsync(p => p.Id == mainCategoryId);
            return mainCategory;
        }

        public void Update(MainCategory mainCategory)
        {
            _context.Update(mainCategory);
        }
    }
}