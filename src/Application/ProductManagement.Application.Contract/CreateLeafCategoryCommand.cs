namespace ProductManagement.Application.Contract
{
    public class CreateLeafCategoryCommand
    {
        public string Title { get; set; }
        public int SubCategoryId { get; set; }
        public int MainCategoryId { get; set; }
        public bool IsActive { get; set; }
        public string ImageName { get; set; }
    }
}