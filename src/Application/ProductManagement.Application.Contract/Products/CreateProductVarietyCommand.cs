using System.Collections.Generic;

namespace ProductManagement.Application.Contract.Products
{
    public class CreateProductVarietyCommand
    {
        public int ProductId { get; set; }
        public int ColorType { set; get; }
        public string ColorImageName { set; get; }
        public IEnumerable<string> Images { set; get; }
        public int ProductImageType { set; get; }
        public decimal ProductAmount { get; set; }
        public int ProductDiscountPercent { get; set; }
    }
}