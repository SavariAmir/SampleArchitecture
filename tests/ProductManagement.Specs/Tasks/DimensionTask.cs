using ProductManagement.Application.Contract.Dimensions;
using ProductManagement.QueryModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductManagement.Specs.Tasks
{
    internal class DimensionTask
    {
        private readonly HttpClient _httpClient;

        public DimensionTask(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<int> CreateDimension(CreateDimensionCommand command)
        {
            var response = await _httpClient.Post<CreateDimensionCommand, int>("api/dimensions", command);
            return response;
        }

        internal async Task<DimensionQuery> GetDimension(int leafCategoryId)
        {
            var response = await _httpClient.GetAsync($"api/dimensions/" + leafCategoryId);
            var result = await response.Content.ReadAsJsonAsync<DimensionQuery>();
            return result;
        }
    }
}