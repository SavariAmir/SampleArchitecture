namespace ProductManagement.QueryModel
{
    public class ProductQuery
    {
        public int ProductId { get; set; }
        public string Title { get; set; }

        public string EnglishTitle { get; set; }
        public bool IsActive { set; get; }
        public int BrandId { get; set; }
        public string AtAGlance { get; set; }
        public string Description { get; set; }
    }
}