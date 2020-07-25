using Anshan.Framework.Domain;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Domain.Models.Products.Specifications
{
    public class ProductSpecification : ValueObject
    {
        public string Description { get; private set; }

        private ProductSpecification()
        {
        }

        public IReadOnlyCollection<ProductSpecificationValue> ProductSpecificationValues => _productSpecificationValues;
        private readonly List<ProductSpecificationValue> _productSpecificationValues = new List<ProductSpecificationValue>();

        public ProductSpecification(string description, IEnumerable<KeyValuePair<int, string>> specificationValues)
        {
            Description = description;
            _productSpecificationValues.Update(specificationValues.Select(p => new ProductSpecificationValue(p.Key, p.Value)).ToList());
        }
    }
}