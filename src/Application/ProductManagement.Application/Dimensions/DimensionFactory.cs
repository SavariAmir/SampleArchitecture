using ProductManagement.Application.Contract.Dimensions;
using ProductManagement.Domain.Models.Dimensions;
using System.Linq;

namespace ProductManagement.Application.Dimensions
{
    public class DimensionFactory
    {
        public static Dimension CreateDimensionFrom(CreateDimensionCommand command)
        {
            var groups = command.Groups.Select(CreateDimensionGroupFrom);

            var dimension = new Dimension(command.LeafCategoryId, groups);

            return dimension;
        }

        private static DimensionGroup CreateDimensionGroupFrom(DimensionGroupCommand command)
        {
            var group = new DimensionGroup(command.Title);
            group.AddDimensionItem(command.Items.Select(p => new DimensionItem(p.Title, (UnitOfMeasurementType)p.UnitOfMeasurementType)));

            return group;
        }
    }
}