using ProductManagement.Domain.Models.Products.Images;
using System.Collections.Generic;

namespace ProductManagement.Domain.Models.Products
{
    public class ProductColorVarietyOptions
    {
        public ColorType ColorType { set; get; }
        public string ColorImageName { set; get; }
        public IEnumerable<string> Images { set; get; }
        public ProductImageType ProductImageType { set; get; }
        public decimal ProductAmount { get; set; }
        public int ProductDiscountPercent { get; set; }
    }
}