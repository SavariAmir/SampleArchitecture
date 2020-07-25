using ProductManagement.Application.Contract;
using ProductManagement.Application.Contract.Products;
using ProductManagement.QueryModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductManagement.Specs.Tasks
{
    internal class ProductTask
    {
        private readonly HttpClient _httpClient;

        public ProductTask(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<int> CreateProduct(CreateProductCommand command)
        {
            var response = await _httpClient.Post<CreateProductCommand, int>("api/products", command);
            return response;
        }

        internal async Task<ProductQuery> GetProduct(int leafCategoryId)
        {
            var response = await _httpClient.GetAsync($"api/products/" + leafCategoryId);
            var result = await response.Content.ReadAsJsonAsync<ProductQuery>();
            return result;
        }

        public async Task CreateProductVariety(CreateProductVarietyCommand command)
        {
            await _httpClient.Post("api/products/create-product-variety", command);
        }

        public async Task UpdateProductDimension(UpdateProductDimensionCommand command)
        {
            await _httpClient.Post("api/products/dimension", command);
        }

        public async Task UpdateProductSpecification(UpdateProductSpecificationCommand command)
        {
            await _httpClient.Post("api/products/specification", command);
        }
    }
}