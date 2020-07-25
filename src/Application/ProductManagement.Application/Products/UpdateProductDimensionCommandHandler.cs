using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products
{
    public class UpdateProductDimensionCommandHandler : ICommandHandler<UpdateProductDimensionCommand>
    {
        private readonly IProductRepository _repository;

        public UpdateProductDimensionCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateProductDimensionCommand command)
        {
            var product = await _repository.GetByIdAsync(command.ProductId);

            product.UpdateDimension(command.ImageName, command.Description, command.DimensionValues.Select(p => new KeyValuePair<int, double>(p.DimensionItemId, p.Value)));

            _repository.Update(product);
        }
    }
}