using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.Models.LeafCategories;
using System.Threading.Tasks;

namespace ProductManagement.Application.Categories
{
    public class CreateLeafCategoryCommandHandler : ICommandHandler<CreateLeafCategoryCommand>
    {
        private readonly ILeafCategoryRepository _repository;

        public CreateLeafCategoryCommandHandler(ILeafCategoryRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateLeafCategoryCommand command)
        {
            var leafCategory = new LeafCategory(command.Title, command.MainCategoryId, command.SubCategoryId, command.IsActive, command.ImageName);

            _repository.Add(leafCategory);

            return Task.CompletedTask;
        }
    }
}