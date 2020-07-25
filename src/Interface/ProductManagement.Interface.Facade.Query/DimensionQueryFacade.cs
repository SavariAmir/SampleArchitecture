using Microsoft.EntityFrameworkCore;
using ProductManagement.Interface.Facade.Contracts;
using ProductManagement.Persistence.EF;
using ProductManagement.QueryModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Query
{
    public class DimensionQueryFacade : IDimensionQueryFacade
    {
        private readonly ProductManagementContext _context;

        public DimensionQueryFacade(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<DimensionQuery> GetDimensionByLeafCategoryId(int leafCategoryId)
        {
            var dimension = await _context.Dimensions
                .Select(d => new DimensionQuery
                {
                    LeafCategoryId = d.LeafCategoryId,
                    Groups = d.DimensionGroups.Select(group => new DimensionGroupQuery
                    {
                        Title = group.Title,
                        Items = group.DimensionItems.Select(item => new DimensionItemQuery
                        {
                            Title = item.Title,
                            UnitOfMeasurementType = (int)item.UnitOfMeasurementType
                        })
                    })
                }).FirstOrDefaultAsync(p => p.LeafCategoryId == leafCategoryId);

            return dimension;
        }
    }
}