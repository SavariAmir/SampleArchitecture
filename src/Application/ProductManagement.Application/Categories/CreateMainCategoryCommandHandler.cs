using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.Models.Categories;
using System.Threading.Tasks;

namespace ProductManagement.Application.Categories
{
    public class CreateMainCategoryCommandHandler : ICommandHandler<CreateMainCategoryCommand>
    {
        private readonly IMainCategoryRepository _mainCategoryRepository;

        public CreateMainCategoryCommandHandler(IMainCategoryRepository mainCategoryRepository)
        {
            _mainCategoryRepository = mainCategoryRepository;
        }

        public Task Handle(CreateMainCategoryCommand command)
        {
            var mainCategory = new MainCategory(command.Title, command.ImageName, command.IsActive);

            _mainCategoryRepository.Add(mainCategory);

            return Task.CompletedTask;
        }
    }
}