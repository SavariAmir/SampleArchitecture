using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;

namespace ProductManagement.Domain.Models.Categories
{
    public class Category : Entity<int>
    {
        public string Title { get; private set; }
        public bool IsActive { get; private set; }
        public int ParentId { get; private set; }
        public Image Image { get; private set; }

        private Category()
        {
        }

        public Category(string title, bool isActive, string imageId)
        {
            Title = title;
            IsActive = isActive;
            Image = imageId;
        }

        public Category(string title, bool isActive, string imageId, int parentId)
        {
            Title = title;
            IsActive = isActive;
            Image = imageId;
            ParentId = parentId;
        }

        public void UpdateFirstLevel(string title, string imageId, bool isActive)
        {
            Title = title;
            Image = imageId;
            IsActive = isActive;
        }

        public void Update(string title, string imageId, bool isActive, int parentId)
        {
            Title = title;
            Image = imageId;
            IsActive = isActive;
            ParentId = parentId;
        }
    }
}