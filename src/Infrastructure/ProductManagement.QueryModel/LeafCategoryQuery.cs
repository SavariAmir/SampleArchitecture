namespace ProductManagement.QueryModel
{
    public class LeafCategoryQuery
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int SubCategoryId { get; set; }
        public int MainCategoryId { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
    }
}