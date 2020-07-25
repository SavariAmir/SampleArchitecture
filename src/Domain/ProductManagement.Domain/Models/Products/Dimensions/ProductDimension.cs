using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Domain.Models.Products.Dimensions
{
    public class ProductDimension : ValueObject
    {
        public Image Image { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyCollection<ProductDimensionItemValue> ProductDimensionItemValues => _productDimensionItemValues;
        private readonly List<ProductDimensionItemValue> _productDimensionItemValues = new List<ProductDimensionItemValue>();

        private ProductDimension()
        {
        }

        public ProductDimension(string description, string imageName, IEnumerable<KeyValuePair<int, double>> dimensionValues)
        {
            Description = description;
            Image = imageName;
            _productDimensionItemValues.Update(dimensionValues.Select(p => new ProductDimensionItemValue(p.Key, p.Value)).ToList());
        }
    }
}