using ProductManagement.Application.Contract.Specifications;
using ProductManagement.Domain.Models.Specifications;
using System.Linq;

namespace ProductManagement.Application.Specifications
{
    public class SpecificationFactory
    {
        public static Specification CreateSpecificationFrom(CreateSpecificationCommand command)
        {
            var groups = command.Groups.Select(CreateSpecificationGroupFrom);

            var dimension = new Specification(command.LeafCategoryId, groups);

            return dimension;
        }

        private static SpecificationGroup CreateSpecificationGroupFrom(SpecificationGroupCommand command)
        {
            var group = new SpecificationGroup(command.Title);
            group.AddSpecificationItem(command.Items.Select(p => new SpecificationItem(p.Title, (SpecificationItemValueType)p.SpecificationItemValueType, p.Options)));

            return group;
        }
    }
}