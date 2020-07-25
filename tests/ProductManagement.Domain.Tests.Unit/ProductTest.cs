using FluentAssertions;
using ProductManagement.Domain.Models.Products;
using ProductManagement.Domain.Models.Products.Images;
using ProductManagement.Domain.Tests.Unit.Builders;
using System;
using System.Collections.Generic;
using ProductManagement.Domain.Models.Products.Exceptions;
using Xunit;

namespace ProductManagement.Domain.Tests.Unit
{
    public class ProductTest
    {
        private readonly ProductBuilder _productBuilder;

        public ProductTest()
        {
            _productBuilder = new ProductBuilder();
        }

        [Fact]
        public void should_create_a_product_properly()
        {
            var product = _productBuilder.Build();

            product.Title.Should().Be(_productBuilder.ProductOptions.ProductTitle);
            product.EnglishTitle.Should().Be(_productBuilder.ProductOptions.ProductEnglishTitle);
            product.Overview.AtAGlance.Should().Be(_productBuilder.ProductOptions.AtAGlance);
            product.Overview.Description.Should().Be(_productBuilder.ProductOptions.Description);
            product.IsActive.Should().Be(_productBuilder.ProductOptions.IsActive);
            product.BrandId.Should().Be(_productBuilder.ProductOptions.BrandId);
        }

        [Fact]
        public void should_add_a_variety_to_a_color_with_its_images_and_price()
        {
            var product = _productBuilder.Build();
            var productColorOptions = new ProductColorVarietyOptions
            {
                ColorType = ColorType.Black,
                ProductDiscountPercent = 10,
                ColorImageName = Guid.NewGuid().ToString(),
                Images = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                ProductAmount = 1500000,
                ProductImageType = ProductImageType.Product
            };
            var productVariety = new ProductColorVariety(productColorOptions);

            product.AddProductColorVariety(productVariety);

            product.ProductColorVarieties.Should().HaveCount(1);
            product.ProductColorVarieties.Should().SatisfyRespectively(first =>
            {
                first.ProductImageType.Should().Be(productColorOptions.ProductImageType);
                first.Images.Should().Equal(productColorOptions.Images, (actual, expected) => actual.Name == expected);
                first.ColorImage.Name.Should().Be(productColorOptions.ColorImageName);
                first.ColorType.Should().Be(productColorOptions.ColorType);
                first.ProductPrice.Amount.Value.Should().Be(productColorOptions.ProductAmount);
                first.ProductPrice.DiscountAmount.Value.Should().Be(150000);
                first.ProductPrice.DiscountPercent.Should().Be(productColorOptions.ProductDiscountPercent);
                first.ProductPrice.DueAmount.Value.Should().Be(1350000);
            });
        }

        [Fact]
        public void should_throw_when_a_color_already_existed()
        {
            var productColorOptions = new ProductColorVarietyOptions
            {
                ColorType = ColorType.Black,
                ProductDiscountPercent = 10,
                ColorImageName = Guid.NewGuid().ToString(),
                Images = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                ProductAmount = 1500000,
                ProductImageType = ProductImageType.Product
            };

            var product = _productBuilder.Build();
            var productVariety = new ProductColorVariety(productColorOptions);
            product.AddProductColorVariety(productVariety);

            Action addProductColor = () => product.AddProductColorVariety(productVariety);

            addProductColor.Should().Throw<DuplicateProductColorException>();
        }

        [Theory]
        [InlineData(-15000000, 10)]
        [InlineData(-10, 10)]
        public void should_throw_when_a_product_amount_is_negative(decimal productAmount, int productDiscountPercent)
        {
            var productColorOptions = new ProductColorVarietyOptions
            {
                ColorType = ColorType.Black,
                ProductDiscountPercent = productDiscountPercent,
                ColorImageName = Guid.NewGuid().ToString(),
                Images = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                ProductAmount = productAmount,
                ProductImageType = ProductImageType.Product
            };

            Action addProductColor = () => new ProductColorVariety(productColorOptions);

            addProductColor.Should().Throw<MoneyCannotBeANegativeValueException>();
        }

        [Theory]
        [InlineData(-15000000)]
        [InlineData(-1)]
        [InlineData(101)]
        [InlineData(1000)]
        public void should_throw_when_a_product_discount_percent_is_not_valid(int productDiscountPercent)
        {
            var productColorOptions = new ProductColorVarietyOptions
            {
                ColorType = ColorType.Black,
                ProductDiscountPercent = productDiscountPercent,
                ColorImageName = Guid.NewGuid().ToString(),
                Images = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                ProductAmount = 1500,
                ProductImageType = ProductImageType.Product
            };

            Action addProductColor = () => _productBuilder.BuildWithAProductVariety(productColorOptions);

            addProductColor.Should().Throw<DiscountPercentInvalidException>();
        }

        [Fact]
        public void should_remove_a_product_variety_through_the_its_color()
        {
            var productColorOptions = new ProductColorVarietyOptions
            {
                ColorType = ColorType.Black,
                ProductDiscountPercent = 10,
                ColorImageName = Guid.NewGuid().ToString(),
                Images = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
                ProductAmount = 10,
                ProductImageType = ProductImageType.Product
            };
            var product = _productBuilder.BuildWithAProductVariety(productColorOptions);

            product.RemoveProductColorVariety(productColorOptions.ColorType);

            product.ProductColorVarieties.Count.Should().Be(0);
        }

        [Fact]
        public void should_update_product_dimension()
        {
            var product = _productBuilder.Build();

            var dimensions = new List<KeyValuePair<int, double>>
            {
                new KeyValuePair<int, double>(DimensionValue.OverallWidth,38.5),
                new KeyValuePair<int, double>(DimensionValue.OverallHeight,62.5),
                new KeyValuePair<int, double>(DimensionValue.OverallDepth,62.5),
            };
            const string imageName = "furniture.jpg";
            const string description = "description";

            product.UpdateDimension(imageName, description, dimensions);

            product.ProductDimension.Description.Should().Be(description);
            product.ProductDimension.Image.Name.Should().Be(imageName);
            product.ProductDimension.ProductDimensionItemValues.Should()
                .Equal(dimensions, (actual, expected) => actual.Value == expected.Value && actual.DimensionItemId == expected.Key);
        }

        [Fact]
        public void should_update_product_specification()
        {
            var product = _productBuilder.Build();
            var specification = new List<KeyValuePair<int, string>>
            {
                new KeyValuePair<int, string>(SpecificationValue.ProductType,SpecificationSofaType.Loveseat),
                new KeyValuePair<int, string>(SpecificationValue.Design,SpecificationSofaDesign.Standard),
                new KeyValuePair<int, string>(SpecificationValue.SeatingCapacity,"2"),
            };
            const string description = "description";
            product.UpdateProductSpecification(description, specification);

            product.ProductSpecification.Description.Should().Be(description);
            product.ProductSpecification.ProductSpecificationValues.Should()
                .Equal(specification, (actual, expected) => actual.Value == expected.Value && actual.SpecificationItemId == expected.Key);
        }

        [Fact]
        public void should_update_product_video()
        {
            var product = _productBuilder.Build();
            var videoName = "video.mp4";

            product.UpdateVideo(videoName);

            product.ProductVideo.ProductVideoLink.Should().Be(videoName);
        }
    }
}