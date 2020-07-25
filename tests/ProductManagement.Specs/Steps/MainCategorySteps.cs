using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductManagement.Application.Contract;
using ProductManagement.Specs.Tasks;
using ServiceHost;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace ProductManagement.Specs.Steps
{
    [Binding]
    public class MainCategorySteps : SpecificationBaseTest
    {
        private readonly MainCategoryTask _mainCategoryTask;

        protected MainCategorySteps(WebApplicationFactory<Startup> factory, ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _mainCategoryTask = new MainCategoryTask(factory.CreateClient());
        }

        [Given(@"I have a main category called '(.*)'")]
        public void GivenIHaveAMainCategoryCalled(string p0)
        {
        }

        [Given(@"'(.*)' as main category has the following properties")]
        public void GivenAsMainCategoryHasTheFollowingProperties(string p0, Table table)
        {
            var command = table.CreateInstance<CreateMainCategoryCommand>();
            command.Title = p0;
            ScenarioContext.Add("main-category", command);
        }

        [When(@"I register the '(.*)' as a main category")]
        public async Task WhenIRegisterTheAsAMainCategory(string p0)
        {
            var command = ScenarioContext.Get<CreateMainCategoryCommand>("main-category");
            var mainCategoryId = await _mainCategoryTask.CreateMainCategory(command);
            ScenarioContext.Add("main-category-Id", mainCategoryId);
        }

        [Then(@"It should be appear in the list of main category")]
        public async Task ThenItShouldBeAppearInTheListOfMainCategory()
        {
            var mainCategoryId = ScenarioContext.Get<int>("main-category-Id");
            var mainCategory = await _mainCategoryTask.GetMainCategory(mainCategoryId);
            var command = ScenarioContext.Get<CreateMainCategoryCommand>("main-category");

            mainCategory.Title.Should().Be(command.Title);
            mainCategory.IsActive.Should().Be(command.IsActive);
            mainCategory.ImageUrl.Should().Be(command.ImageName);
        }

        [When(@"I have a category called '(.*)' with parent '(.*)'")]
        public void WhenIHaveACategoryCalledWithParent(string p0, string p1)
        {
        }

        [When(@"'(.*)' as category has the following properties")]
        public void WhenAsCategoryHasTheFollowingProperties(string p0, Table table)
        {
            var command = table.CreateInstance<CreateCategoryCommand>();
            command.Title = p0;
            command.MainCategoryId = ScenarioContext.Get<int>("main-category-Id");

            ScenarioContext.Add("category", command);
        }

        [When(@"I register the '(.*)' as a category")]
        public async Task WhenIRegisterTheAsACategory(string p0)
        {
            var command = ScenarioContext.Get<CreateCategoryCommand>("category");
            var categoryId = await _mainCategoryTask.CreateCategory(command);
            ScenarioContext.Add("category-Id", categoryId);
        }

        [Then(@"It should be appear in the list of categories")]
        public async Task ThenItShouldBeAppearInTheListOfCategories()
        {
            var categoryId = ScenarioContext.Get<int>("category-Id");
            var category = await _mainCategoryTask.GetCategory(categoryId);
            var command = ScenarioContext.Get<CreateCategoryCommand>("category");

            category.Title.Should().Be(command.Title);
            category.IsActive.Should().Be(command.IsActive);
            category.ImageUrl.Should().Be(command.ImageName);
        }
    }
}