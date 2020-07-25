using System.Collections.Generic;

namespace ProductManagement.Application.Contract
{
    public class UpdateProductDimensionCommand
    {
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductDimensionItemCommand> DimensionValues { set; get; }
    }

    public class ProductDimensionItemCommand
    {
        public int DimensionItemId { get; set; }
        public double Value { get; set; }
    }
}