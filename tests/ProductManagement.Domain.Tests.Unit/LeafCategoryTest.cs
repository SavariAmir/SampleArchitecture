using FluentAssertions;
using ProductManagement.Domain.Models.LeafCategories;
using System;
using Xunit;

namespace ProductManagement.Domain.Tests.Unit
{
    public class LeafCategoryTest
    {
        [Fact]
        public void Should_create_a_leaf_category_correctly()
        {
            const string title = "TV Stand Fireplaces";
            const int mainCategoryId = MainCategoryValue.LivingRoomFurniture;
            const int subCategoryId = SubCategoryValue.BedroomFurniture;
            var imageId = Guid.NewGuid().ToString();

            var leafCategory = new LeafCategory(title, mainCategoryId, subCategoryId, true, imageId);

            leafCategory.Title.Should().Be(title);
            leafCategory.Image.Name.Should().Be(imageId);
            leafCategory.IsActive.Should().BeTrue();
            leafCategory.MainCategoryId.Should().Be(mainCategoryId);
            leafCategory.SubCategoryId.Should().Be(subCategoryId);
        }
    }
}