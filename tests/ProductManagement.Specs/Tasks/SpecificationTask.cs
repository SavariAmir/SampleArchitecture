using ProductManagement.Application.Contract.Specifications;
using ProductManagement.QueryModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductManagement.Specs.Tasks
{
    internal class SpecificationTask
    {
        private readonly HttpClient _httpClient;

        public SpecificationTask(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<int> CreateSpecification(CreateSpecificationCommand command)
        {
            var response = await _httpClient.Post<CreateSpecificationCommand, int>("api/specifications", command);
            return response;
        }

        internal async Task<SpecificationQuery> GetSpecification(int leafCategoryId)
        {
            var response = await _httpClient.GetAsync($"api/specifications/" + leafCategoryId);
            var result = await response.Content.ReadAsJsonAsync<SpecificationQuery>();
            return result;
        }
    }
}