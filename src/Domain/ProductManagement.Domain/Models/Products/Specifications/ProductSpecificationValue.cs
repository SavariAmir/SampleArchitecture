using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Products.Specifications
{
    public class ProductSpecificationValue : ValueObject
    {
        public int SpecificationItemId { get; private set; }
        public string Value { get; private set; }

        public ProductSpecificationValue(int specificationItemId, string value)
        {
            SpecificationItemId = specificationItemId;
            Value = value;
        }
    }
}