using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Products.Dimensions;
using ProductManagement.Domain.Models.Products.Images;
using ProductManagement.Domain.Models.Products.Specifications;
using System.Collections.Generic;
using System.Linq;
using ProductManagement.Domain.Models.Products.Exceptions;

namespace ProductManagement.Domain.Models.Products
{
    public class Product : AggregateRoot<int>
    {
        public string Title { get; private set; }

        public string EnglishTitle { get; private set; }

        public ProductOverview Overview { get; private set; }

        public bool IsActive { private set; get; }
        public int BrandId { get; private set; }

        //public Shipping Shipping { get; private set; }
        public ProductDimension ProductDimension { get; private set; }

        public ProductSpecification ProductSpecification { get; private set; }
        public ProductVideo ProductVideo { get; private set; }

        public IReadOnlyCollection<ProductColorVariety> ProductColorVarieties => _productColorVarieties;
        private readonly List<ProductColorVariety> _productColorVarieties = new List<ProductColorVariety>();

        private Product()
        {
        }

        public Product(ProductOptions options)
        {
            Title = options.ProductTitle;
            EnglishTitle = options.ProductEnglishTitle;
            Overview = new ProductOverview(options.AtAGlance, options.Description);
            IsActive = options.IsActive;
            BrandId = options.BrandId;
        }

        public void AddProductColorVariety(ProductColorVariety productColorVariety)
        {
            GuardAgainstDuplicateVariety(productColorVariety.ColorType);

            _productColorVarieties.Add(productColorVariety);
        }

        public void RemoveProductColorVariety(ColorType colorType)
        {
            var productColor = ProductColorVarieties.First(p => p.ColorType == colorType);
            _productColorVarieties.Remove(productColor);
        }

        public void UpdateDimension(string imageName, string description, IEnumerable<KeyValuePair<int, double>> dimensionValues)
        {
            ProductDimension = new ProductDimension(description, imageName, dimensionValues);
        }

        public void UpdateProductSpecification(string description, IEnumerable<KeyValuePair<int, string>> specificationValues)
        {
            ProductSpecification = new ProductSpecification(description, specificationValues);
        }

        public void UpdateVideo(string videoName)
        {
            ProductVideo = videoName;
        }

        private void GuardAgainstDuplicateVariety(ColorType colorType)
        {
            if (ProductColorVarieties.Any(p => p.ColorType == colorType))
                throw new DuplicateProductColorException();
        }
    }
}