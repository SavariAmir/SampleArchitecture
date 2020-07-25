using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract.Products;
using ProductManagement.Domain.Models.Products;
using ProductManagement.Domain.Models.Products.Images;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products
{
    public class CreateProductVarietyCommandHandler : ICommandHandler<CreateProductVarietyCommand>
    {
        private readonly IProductRepository _repository;

        public CreateProductVarietyCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateProductVarietyCommand command)
        {
            var product = await _repository.GetByIdAsync(command.ProductId);

            var options = new ProductColorVarietyOptions()
            {
                ColorImageName = command.ColorImageName,
                ColorType = (ColorType)command.ColorType,
                Images = command.Images,
                ProductAmount = command.ProductAmount,
                ProductDiscountPercent = command.ProductDiscountPercent,
                ProductImageType = (ProductImageType)command.ProductImageType
            };
            var productVariety = new ProductColorVariety(options);

            product.AddProductColorVariety(productVariety);

            _repository.Update(product);
        }
    }
}