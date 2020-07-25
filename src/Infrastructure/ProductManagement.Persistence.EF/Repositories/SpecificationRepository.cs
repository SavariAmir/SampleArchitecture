using Microsoft.EntityFrameworkCore;
using ProductManagement.Domain.Models.Specifications;
using System.Threading.Tasks;

namespace ProductManagement.Persistence.EF.Repositories
{
    public class SpecificationRepository : ISpecificationRepository
    {
        private readonly ProductManagementContext _context;

        public SpecificationRepository(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<Specification> GetByLeafCategoryId(int leafCategoryId)
        {
            return await _context.Specifications
                .Include(p => p.SpecificationGroups)
                    .ThenInclude(p => p.SpecificationItems)
                         .ThenInclude(p => p.SpecificationItemOptions)
                             .FirstOrDefaultAsync(p => p.LeafCategoryId == leafCategoryId);
        }

        public void Add(Specification specification)
        {
            _context.Add(specification);
        }
    }
}