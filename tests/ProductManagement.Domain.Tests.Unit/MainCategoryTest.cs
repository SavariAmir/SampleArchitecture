using AutoFixture;
using FluentAssertions;
using ProductManagement.Domain.Models.Categories;
using System;
using Xunit;

namespace ProductManagement.Domain.Tests.Unit
{
    public class MainCategoryTest
    {
        [Fact]
        public void Should_create_a_main_category_correctly()
        {
            const string title = "Living Room Furniture";
            var imageId = Guid.NewGuid().ToString();

            var mainCategory = new MainCategory(title, imageId, true);

            mainCategory.Title.Should().Be(title);
            mainCategory.Image.Name.Should().Be(imageId);
            mainCategory.IsActive.Should().BeTrue();
        }

        [Fact]
        public void Update_should_update_a_main_category_correctly()
        {
            var mainCategory = new Fixture().Create<MainCategory>();
            var title = "Living Room Furniture";
            var imageId = Guid.NewGuid().ToString();

            mainCategory.Update(title, imageId, false);

            mainCategory.Title.Should().Be(title);
            mainCategory.Image.Name.Should().Be(imageId);
            mainCategory.IsActive.Should().BeFalse();
        }

        [Fact]
        public void AddFirstLevelOfSubCategory_should_add_a_category_to_a_main_category()
        {
            var mainCategory = new Fixture().Create<MainCategory>();
            var subcategory = new Category("TV Stands", true, Guid.NewGuid().ToString());

            mainCategory.AddFirstLevelOfCategory(subcategory);

            mainCategory.SubCategories.Should().HaveCount(1).And.Contain(subcategory);
        }

        [Fact]
        public void AddSubCategory_should_add_a_category_to_a_main_category_with_a_parent_category()
        {
            var mainCategory = new Fixture().Create<MainCategory>();
            var subcategory = new Category("TV Stands", true, Guid.NewGuid().ToString(), 1);

            mainCategory.AddCategory(subcategory);

            mainCategory.SubCategories.Should().HaveCount(1).And.Contain(subcategory);
        }

        [Fact]
        public void UpdateFirstLevelOfSubCategory_should_update_a_category()
        {
            var mainCategory = new Fixture().Create<MainCategory>();
            var subcategory = new Category("TV Stands", true, Guid.NewGuid().ToString());
            mainCategory.AddFirstLevelOfCategory(subcategory);

            var newTitle = "Fireplace TV Stands";
            var newImageId = Guid.NewGuid().ToString();

            mainCategory.UpdateFirstLevelOfCategory(0, newTitle, newImageId, false);

            mainCategory.SubCategories.Should().HaveCount(1);

            mainCategory.SubCategories.Should().SatisfyRespectively(first =>
            {
                first.Title.Should().Be(newTitle);
                first.Image.Name.Should().Be(newImageId);
                first.IsActive.Should().BeFalse();
            });
        }

        [Fact]
        public void UpdateSubCategory_should_update_a_category_with_a_parent_category()
        {
            var mainCategory = new Fixture().Create<MainCategory>();
            var subcategory = new Category("TV Stands", true, Guid.NewGuid().ToString(), 1);
            mainCategory.AddCategory(subcategory);

            var newParentId = 2;
            var newTitle = new Fixture().Create<string>();
            var newImageId = Guid.NewGuid().ToString();

            mainCategory.UpdateCategory(0, newTitle, newImageId, false, newParentId);

            mainCategory.SubCategories.Should().HaveCount(1);

            mainCategory.SubCategories.Should().SatisfyRespectively(first =>
            {
                first.Title.Should().Be(newTitle);
                first.Image.Name.Should().Be(newImageId);
                first.IsActive.Should().BeFalse();
                first.ParentId.Should().Be(newParentId);
            });
        }
    }
}