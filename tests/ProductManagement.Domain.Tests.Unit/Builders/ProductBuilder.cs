using ProductManagement.Domain.Models.Products;
using ProductManagement.Domain.Models.Products.Images;

namespace ProductManagement.Domain.Tests.Unit.Builders
{
    public class ProductBuilder
    {
        public readonly ProductOptions ProductOptions = new ProductOptions();

        public ProductBuilder()
        {
            ProductOptions.ProductTitle = "Chinn 6 Drawer Double Dresser";
            ProductOptions.ProductEnglishTitle = "Chinn 6 Drawer Double Dresser";
            ProductOptions.AtAGlance = "Solid Wood";
            ProductOptions.Description =
                "This collection features simplistic cases with linear detail allowing the architectural lines to create interest.";
            ProductOptions.IsActive = true;
            ProductOptions.BrandId = Brands.NilperId;
        }

        public Product BuildWithAProductVariety(ProductColorVarietyOptions productColorVarietyOptions)
        {
            var product = new Product(ProductOptions);
            var productVariety = new ProductColorVariety(productColorVarietyOptions);
            product.AddProductColorVariety(productVariety);

            return product;
        }

        public Product Build()
        {
            return new Product(ProductOptions);
        }
    }
}