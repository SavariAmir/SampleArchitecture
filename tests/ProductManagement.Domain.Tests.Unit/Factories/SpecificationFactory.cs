using ProductManagement.Domain.Models.Specifications;
using System.Linq;

namespace ProductManagement.Domain.Tests.Unit.Factories
{
    internal class SpecificationFactory
    {
        public static Specification CreateSpecification()
        {
            return new Specification(1);
        }

        public static Specification CreateSpecificationWithAGroup()
        {
            var specification = CreateSpecification();
            specification.AddSpecificationGroup("Features");
            specification.SpecificationGroups.First().SetId(1);

            return specification;
        }
    }
}