using Microsoft.EntityFrameworkCore;
using ProductManagement.Interface.Facade.Contracts;
using ProductManagement.Persistence.EF;
using ProductManagement.QueryModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Interface.Facade.Query
{
    public class CategoryQueryFacade : ICategoryQueryFacade
    {
        private readonly ProductManagementContext _context;

        public CategoryQueryFacade(ProductManagementContext context)
        {
            _context = context;
        }

        public async Task<MainCategoryQuery> GetMainCategoryById(int id)
        {
            var mainCategory = await _context.MainCategories.Select(p => new MainCategoryQuery
            {
                Id = p.Id,
                ImageUrl = p.Image.Name,
                IsActive = p.IsActive,
                Title = p.Title
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (mainCategory is null) throw new Exception("Not Found");

            return mainCategory;
        }

        public async Task<CategoryQuery> GetCategoryById(int id)
        {
            var category = await _context.Categories.Select(p => new CategoryQuery
            {
                Id = p.Id,
                ImageUrl = p.Image.Name,
                IsActive = p.IsActive,
                Title = p.Title
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (category is null) throw new Exception("Not Found");

            return category;
        }

        public async Task<LeafCategoryQuery> GetLeafCategoryById(int id)
        {
            var category = await _context.LeafCategories.Select(p => new LeafCategoryQuery
            {
                Id = p.Id,
                ImageUrl = p.Image.Name,
                IsActive = p.IsActive,
                Title = p.Title,
                SubCategoryId = p.SubCategoryId,
                MainCategoryId = p.MainCategoryId
            }).FirstOrDefaultAsync(p => p.Id == id);

            if (category is null) throw new Exception("Not Found");

            return category;
        }
    }
}