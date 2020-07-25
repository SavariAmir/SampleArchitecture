using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Models.Dimensions;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.EF.Repositories
{
    public class DimensionRepository : IDimensionRepository
    {
        private readonly ProductManagementContext _context;

        public DimensionRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public void Add(Dimension dimension)
        {
            _context.Add(dimension);
        }

        public void Update(Dimension dimension)
        {
            _context.Update(dimension);
        }

        public async Task<Dimension> GetByLeafCategoryId(int leafCategoryId)
        {
            return await _context.Dimensions.Include(p => p.DimensionGroups).ThenInclude(p => p.DimensionItems)
                .FirstOrDefaultAsync(p => p.LeafCategoryId == leafCategoryId);
        }
    }
}