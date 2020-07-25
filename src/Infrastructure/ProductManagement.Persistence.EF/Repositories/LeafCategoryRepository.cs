using ProductManagement.Domain.Models.LeafCategories;

namespace ProductManagement.Persistence.EF.Repositories
{
    public class LeafCategoryRepository : ILeafCategoryRepository
    {
        private readonly ProductManagementContext _context;

        public LeafCategoryRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public void Add(LeafCategory leafCategory)
        {
            _context.Add(leafCategory);
        }
    }
}