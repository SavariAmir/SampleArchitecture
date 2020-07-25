using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.Models.Categories;
using System.Threading.Tasks;

namespace ProductManagement.Application.Categories
{
    public class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public CreateCategoryCommandHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public async Task Handle(CreateCategoryCommand command)
        {
            var mainCategory = await _mainCategoryRepository.GetByIdAsync(command.MainCategoryId);

            var category = new Category(command.Title, command.IsActive, command.ImageName);
            mainCategory.AddFirstLevelOfCategory(category);

            _mainCategoryRepository.Update(mainCategory);
        }
    }
}