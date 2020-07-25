namespace ProductManagement.Domain.Models.Products
{
    public class ProductOptions
    {
        public string ProductTitle { get; set; }

        public string ProductEnglishTitle { get; set; }
        public bool IsActive { set; get; }
        public int BrandId { get; set; }
        public string AtAGlance { get; set; }
        public string Description { get; set; }
    }
}