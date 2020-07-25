using System.Net.Http;
using System.Threading.Tasks;
using ProductManagement.Application.Contract;
using ProductManagement.QueryModel;

namespace ProductManagement.Specs.Tasks
{
    internal class LeafCategoryTask
    {
        private readonly HttpClient _httpClient;

        public LeafCategoryTask(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<int> CreateLeafCategory(CreateLeafCategoryCommand command)
        {
            var response = await _httpClient.Post<CreateLeafCategoryCommand, int>("api/LeafCategories", command);
            return response;
        }

        internal async Task<LeafCategoryQuery> GetLeafCategory(int id)
        {
            var response = await _httpClient.GetAsync($"api/LeafCategories/" + id);
            var result = await response.Content.ReadAsJsonAsync<LeafCategoryQuery>();
            return result;
        }
    }
}