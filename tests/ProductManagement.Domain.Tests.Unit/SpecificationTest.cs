using FluentAssertions;
using ProductManagement.Domain.Models.Specifications;
using ProductManagement.Domain.Tests.Unit.Factories;
using Xunit;

namespace ProductManagement.Domain.Tests.Unit
{
    public class SpecificationTest
    {
        [Fact]
        public void Should_create_a_specification_correctly()
        {
            var specification = new Specification(LeafCategoryValue.Sofas);

            specification.LeafCategoryId.Should().Be(LeafCategoryValue.Sofas);
        }

        [Fact]
        public void AddSpecificationGroup_should_add_a_group_to_a_specification_correctly()
        {
            var specification = SpecificationFactory.CreateSpecification();
            var title = "Features";
            specification.AddSpecificationGroup(title);

            specification.SpecificationGroups.Should().HaveCount(1).And.ContainSingle(p => p.Title == title);
        }
    }
}