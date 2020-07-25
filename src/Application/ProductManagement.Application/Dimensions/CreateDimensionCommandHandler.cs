using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract.Dimensions;
using ProductManagement.Domain.Models.Dimensions;
using System;
using System.Threading.Tasks;

namespace ProductManagement.Application.Dimensions
{
    public class CreateDimensionCommandHandler : ICommandHandler<CreateDimensionCommand>
    {
        private readonly IDimensionRepository _dimensionRepository;

        public CreateDimensionCommandHandler(IDimensionRepository dimensionRepository)
        {
            _dimensionRepository = dimensionRepository;
        }

        public async Task Handle(CreateDimensionCommand command)
        {
            if (await _dimensionRepository.GetByLeafCategoryId(command.LeafCategoryId) != null)
                throw new Exception();

            var dimension = DimensionFactory.CreateDimensionFrom(command);
            _dimensionRepository.Add(dimension);
        }
    }
}