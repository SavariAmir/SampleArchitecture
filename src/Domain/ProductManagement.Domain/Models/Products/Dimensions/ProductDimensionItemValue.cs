using Anshan.Framework.Domain;

namespace ProductManagement.Domain.Models.Products.Dimensions
{
    public class ProductDimensionItemValue : ValueObject
    {
        public int DimensionItemId { get; private set; }
        public double Value { get; private set; }

        public ProductDimensionItemValue(int dimensionItemId, double value)
        {
            DimensionItemId = dimensionItemId;
            Value = value;
        }
    }
}