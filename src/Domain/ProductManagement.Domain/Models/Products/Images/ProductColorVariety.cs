using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Domain.Models.Products.Images
{
    public class ProductColorVariety : ValueObject
    {
        public ColorType ColorType { get; private set; }
        public Image ColorImage { get; private set; }
        public IReadOnlyCollection<Image> Images => _images;
        private readonly List<Image> _images = new List<Image>();
        public ProductPrice ProductPrice { get; private set; }
        public ProductImageType ProductImageType { get; private set; }

        private ProductColorVariety()
        {
        }

        public ProductColorVariety(ProductColorVarietyOptions options)
        {
            ColorType = options.ColorType;
            ColorImage = options.ColorImageName;
            _images = options.Images.Select(p => new Image(p)).ToList();
            ProductImageType = options.ProductImageType;
            ProductPrice = new ProductPrice(options.ProductAmount, options.ProductDiscountPercent);
        }
    }
}