using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract.Specifications;
using ProductManagement.Domain.Models.Specifications;
using System;
using System.Threading.Tasks;

namespace ProductManagement.Application.Specifications
{
    public class CreateSpecificationCommandHandler : ICommandHandler<CreateSpecificationCommand>
    {
        private readonly ISpecificationRepository _specificationRepository;

        public CreateSpecificationCommandHandler(ISpecificationRepository specificationRepository)
        {
            _specificationRepository = specificationRepository;
        }

        public async Task Handle(CreateSpecificationCommand command)
        {
            if (await _specificationRepository.GetByLeafCategoryId(command.LeafCategoryId) != null)
                throw new Exception();

            var dimension = SpecificationFactory.CreateSpecificationFrom(command);
            _specificationRepository.Add(dimension);
        }
    }
}