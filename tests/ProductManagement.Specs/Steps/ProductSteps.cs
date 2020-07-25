using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductManagement.Application.Contract;
using ProductManagement.Application.Contract.Products;
using ProductManagement.Specs.Tasks;
using ServiceHost;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProductManagement.Specs.Steps
{
    [Binding]
    public class ProductSteps : SpecificationBaseTest
    {
        private readonly ProductTask _productTask;

        protected ProductSteps(WebApplicationFactory<Startup> factory, ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _productTask = new ProductTask(factory.CreateClient());
        }

        [Given(@"I have a product called '(.*)'")]
        public void GivenIHaveAProductCalled(string p0)
        {
        }

        [Given(@"'(.*)' as a product has the following properties")]
        public void GivenAsAProductHasTheFollowingProperties(string p0, Table table)
        {
            var command = table.CreateInstance<CreateProductCommand>();
            command.Title = p0;
            ScenarioContext.Add("product", command);
        }

        [When(@"I register the '(.*)' as a product")]
        public async Task WhenIRegisterTheAsAProduct(string p0)
        {
            var command = ScenarioContext.Get<CreateProductCommand>("product");
            var productId = await _productTask.CreateProduct(command);
            ScenarioContext.Add("product-Id", productId);
        }

        [Then(@"It should be appear in the list of products")]
        public async Task ThenItShouldBeAppearInTheListOfProducts()
        {
            var productId = ScenarioContext.Get<int>("product-Id");
            var command = ScenarioContext.Get<CreateProductCommand>("product");

            var product = await _productTask.GetProduct(productId);

            product.Title.Should().Be(command.Title);
            product.EnglishTitle.Should().Be(command.EnglishTitle);
            product.BrandId.Should().Be(command.BrandId);
            product.Description.Should().Be(command.Description);
            product.AtAGlance.Should().Be(command.AtAGlance);
            product.IsActive.Should().Be(command.IsActive);
        }

        [Given(@"A product variety should add to '(.*)'  which has the following properties")]
        public void GivenAProductVarietyShouldAddToWhichHasTheFollowingProperties(string p0, Table table)
        {
        }

        [Given(@"Each product variety has the some images")]
        public void GivenEachProductVarietyHasTheSomeImages(Table table)
        {
        }

        [When(@"I submit the product variety")]
        public async Task WhenISubmitTheProductVariety()
        {
            var productId = ScenarioContext.Get<int>("product-Id");
            var command = new CreateProductVarietyCommand
            {
                ProductId = productId,
                ProductImageType = 1,
                ProductDiscountPercent = 10,
                ProductAmount = 32000,
                ColorImageName = "image.png",
                ColorType = 1,
                Images = new List<string>
                {
                    "image1.png",
                    "image2.png",
                    "image3.png",
                    "image4.png",
                }
            };

            ScenarioContext.Add("product-variety", command);

            await _productTask.CreateProductVariety(command);
        }

        [Then(@"It should be appear in the list of '(.*)'")]
        public void ThenItShouldBeAppearInTheListOf(string p0)
        {
        }

        [When(@"I submit to update product dimension")]
        public async Task WhenISubmitToUpdateProductDimension()
        {
            var productId = ScenarioContext.Get<int>("product-Id");
            var command = new UpdateProductDimensionCommand
            {
                ProductId = productId,
                Description = "description",
                ImageName = "image1.png",
                DimensionValues = new List<ProductDimensionItemCommand>
               {
                   new ProductDimensionItemCommand
                   {
                       DimensionItemId=1,
                       Value=23.5
                   },
                   new ProductDimensionItemCommand
                   {
                       DimensionItemId=2,
                       Value=75
                   },
                   new ProductDimensionItemCommand
                   {
                       DimensionItemId=3,
                       Value=85
                   },
               }
            };

            ScenarioContext.Add("product-dimension", command);

            await _productTask.UpdateProductDimension(command);
        }

        [Then(@"'(.*)' dimension should be updated")]
        public void ThenDimensionShouldBeUpdated(string p0)
        {
        }

        [When(@"I submit to update product specification")]
        public async Task WhenISubmitToUpdateProductSpecification()
        {
            var productId = ScenarioContext.Get<int>("product-Id");
            var command = new UpdateProductSpecificationCommand
            {
                ProductId = productId,
                Description = "description",
                SpecificationValues = new List<ProductSpecificationValueCommand>
                {
                    new ProductSpecificationValueCommand
                    {
                        SpecificationItemId= 1,
                        Value="1"
                    },
                    new ProductSpecificationValueCommand
                    {
                        SpecificationItemId=2,
                        Value="2"
                    },
                    new ProductSpecificationValueCommand
                    {
                        SpecificationItemId=3,
                        Value="3"
                    },
                }
            };

            ScenarioContext.Add("product-dimension", command);

            await _productTask.UpdateProductSpecification(command);
        }

        [Then(@"'(.*)' specification should be updated")]
        public void ThenSpecificationShouldBeUpdated(string p0)
        {
        }
    }
}