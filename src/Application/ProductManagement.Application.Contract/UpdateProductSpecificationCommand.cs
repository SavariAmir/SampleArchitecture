using System.Collections.Generic;

namespace ProductManagement.Application.Contract
{
    public class UpdateProductSpecificationCommand
    {
        public int ProductId { get; set; }
        public string Description { get; set; }
        public IEnumerable<ProductSpecificationValueCommand> SpecificationValues { set; get; }
    }

    public class ProductSpecificationValueCommand
    {
        public int SpecificationItemId { get; set; }
        public string Value { get; set; }
    }
}