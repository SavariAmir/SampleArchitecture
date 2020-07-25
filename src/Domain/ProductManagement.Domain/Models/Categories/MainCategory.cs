using Anshan.Framework.Domain;
using ProductManagement.Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManagement.Domain.Models.Categories
{
    public class MainCategory : AggregateRoot<int>
    {
        public string Title { get; private set; }
        public bool IsActive { get; private set; }
        public Image Image { get; private set; }

        public IReadOnlyCollection<Category> SubCategories => _subCategories;
        private readonly List<Category> _subCategories = new List<Category>();

        private MainCategory()
        {
        }

        public MainCategory(string title, string imageId, bool isActive)
        {
            Title = title;
            Image = imageId;
            IsActive = isActive;
        }

        public void Update(string title, string imageId, bool isActive)
        {
            Title = title;
            Image = imageId;
            IsActive = isActive;
        }

        public void AddFirstLevelOfCategory(Category category)
        {
            _subCategories.Add(category);
        }

        public void AddCategory(Category category)
        {
            _subCategories.Add(category);
        }

        public void UpdateFirstLevelOfCategory(int categoryId, string title, string imageId, bool isActive)
        {
            var category = _subCategories.First(p => p.Id == categoryId);
            if (category is null)
                throw new Exception("");

            category.UpdateFirstLevel(title, imageId, isActive);
        }

        public void UpdateCategory(int categoryId, string title, string imageId, bool isActive, int parentId)
        {
            var category = _subCategories.First(p => p.Id == categoryId);
            if (category is null)
                throw new Exception("");

            category.Update(title, imageId, isActive, parentId);
        }
    }
}