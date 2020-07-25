using Microsoft.EntityFrameworkCore;
using ProductManagement.Interface.Facade.Contracts;
using ProductManagement.Persistence.EF;
using ProductManagement.QueryModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Query
{
    public class SpecificationQueryFacade : ISpecificationQueryFacade
    {
        private readonly ProductManagementContext _context;

        public SpecificationQueryFacade(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<SpecificationQuery> GetSpecificationByLeafCategoryId(int leafCategoryId)
        {
            var specification = await _context.Specifications.Select(s => new SpecificationQuery
            {
                LeafCategoryId = s.LeafCategoryId,
                Groups = s.SpecificationGroups.Select(group => new SpecificationGroupQuery
                {
                    Title = group.Title,
                    Items = group.SpecificationItems.Select(item => new SpecificationItemQuery
                    {
                        Title = item.Title,
                        SpecificationItemValueType = (int)item.SpecificationItemValueType,
                        Options = item.SpecificationItemOptions.Select(p => new SpecificationItemOptionQuery
                        {
                            Id = p.Id,
                            Value = p.Value
                        })
                    })
                })
            }).FirstOrDefaultAsync(p => p.LeafCategoryId == leafCategoryId);

            return specification;
        }
    }
}