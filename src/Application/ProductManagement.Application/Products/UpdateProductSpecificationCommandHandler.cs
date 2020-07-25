using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract;
using ProductManagement.Domain.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products
{
    public class UpdateProductSpecificationCommandHandler : ICommandHandler<UpdateProductSpecificationCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductSpecificationCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductSpecificationCommand command)
        {
            var product = await _productRepository.GetByIdAsync(command.ProductId);

            product.UpdateProductSpecification(command.Description, command.SpecificationValues.Select(p => new KeyValuePair<int, string>(p.SpecificationItemId, p.Value)));

            _productRepository.Update(product);
        }
    }
}