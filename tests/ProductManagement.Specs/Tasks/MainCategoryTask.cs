using ProductManagement.Application.Contract;
using ProductManagement.QueryModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProductManagement.Specs.Tasks
{
    internal class MainCategoryTask
    {
        private readonly HttpClient _httpClient;

        public MainCategoryTask(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        internal async Task<int> CreateMainCategory(CreateMainCategoryCommand command)
        {
            var response = await _httpClient.Post<CreateMainCategoryCommand, int>("api/MainCategories", command);
            return response;
        }

        internal async Task<MainCategoryQuery> GetMainCategory(int mainCategoryId)
        {
            var response = await _httpClient.GetAsync($"api/MainCategories/" + mainCategoryId);
            var result = await response.Content.ReadAsJsonAsync<MainCategoryQuery>();
            return result;
        }

        public async Task<int> CreateCategory(CreateCategoryCommand command)
        {
            var response = await _httpClient.Post<CreateCategoryCommand, int>($"api/MainCategories/{command.MainCategoryId}/category", command);
            return response;
        }

        public async Task<CategoryQuery> GetCategory(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/MainCategories/categories/" + categoryId);
            var result = await response.Content.ReadAsJsonAsync<CategoryQuery>();
            return result;
        }
    }
}