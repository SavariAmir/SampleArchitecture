namespace ProductManagement.Application.Contract
{
    public class CreateCategoryCommand
    {
        public int MainCategoryId { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
    }
}