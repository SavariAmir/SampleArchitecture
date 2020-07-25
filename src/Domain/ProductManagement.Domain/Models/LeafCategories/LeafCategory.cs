using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;

namespace ProductManagement.Domain.Models.LeafCategories
{
    public class LeafCategory : AggregateRoot<int>
    {
        public string Title { get; private set; }
        public int SubCategoryId { get; private set; }
        public int MainCategoryId { get; private set; }
        public bool IsActive { get; private set; }
        public Image Image { get; private set; }

        private LeafCategory()
        {
        }

        public LeafCategory(string title, int mainCategoryId, int subCategoryId, bool isActive, string imageId)
        {
            Title = title;
            MainCategoryId = mainCategoryId;
            IsActive = isActive;
            SubCategoryId = subCategoryId;
            Image = imageId;
        }
    }
}