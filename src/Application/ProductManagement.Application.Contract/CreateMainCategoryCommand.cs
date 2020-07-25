namespace ProductManagement.Application.Contract
{
    public class CreateMainCategoryCommand
    {
        public string Title { get; set; }
        public string ImageName { get; set; }
        public bool IsActive { get; set; }
    }
}