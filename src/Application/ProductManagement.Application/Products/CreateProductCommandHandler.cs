using Anshan.Framework.Application.Command;
using ProductManagement.Application.Contract.Products;
using ProductManagement.Domain.Models.Products;
using System.Threading.Tasks;

namespace ProductManagement.Application.Products
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task Handle(CreateProductCommand command)
        {
            var productOption = new ProductOptions
            {
                ProductTitle = command.Title,
                ProductEnglishTitle = command.EnglishTitle,
                AtAGlance = command.AtAGlance,
                Description = command.Description,
                IsActive = command.IsActive,
                BrandId = command.BrandId
            };

            var product = new Product(productOption);

            _productRepository.Add(product);

            return Task.CompletedTask;
        }

        //var productColorOptions = new ProductColorVarietyOptions
        //{
        //    ColorType = ColorType.Black,
        //    ProductDiscountPercent = 10,
        //    ColorImageName = Guid.NewGuid().ToString(),
        //    Images = new List<string> { Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString() },
        //    ProductAmount = 1500000,
        //    ProductImageType = ProductImageType.Product
        //};
        //var productVariety = new ProductColorVariety(productColorOptions);
        //product.AddProductColorVariety(productVariety);

        //var dimensions = new List<KeyValuePair<int, double>>
        //{
        //    new KeyValuePair<int, double>(1,38.5),
        //    new KeyValuePair<int, double>(2,62.5),
        //    new KeyValuePair<int, double>(3,62.5),
        //};
        //const string imageName = "furniture.jpg";
        //const string description = "description";
        //product.UpdateDimension(imageName, description, dimensions);

        //var specification = new List<KeyValuePair<int, string>>
        //{
        //    new KeyValuePair<int, string>(1,"1"),
        //    new KeyValuePair<int, string>(2,"2"),
        //    new KeyValuePair<int, string>(3,"3"),
        //};
        //product.UpdateProductSpecification("description", specification);
    }
}