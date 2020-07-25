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
    public class LeafCategorySteps : SpecificationBaseTest
    {
        private readonly LeafCategoryTask _dimensionTask;

        protected LeafCategorySteps(WebApplicationFactory<Startup> factory, ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _dimensionTask = new LeafCategoryTask(factory.CreateClient());
        }

        [Given(@"I have a leaf category called '(.*)'")]
        public void GivenIHaveALeafCategoryCalled(string p0)
        {
        }

        [Given(@"'(.*)' as leaf category has the following properties")]
        public void GivenAsLeafCategoryHasTheFollowingProperties(string p0, Table table)
        {
            var command = table.CreateInstance<CreateLeafCategoryCommand>();
            command.Title = p0;
            ScenarioContext.Add("leaf-category", command);
        }

        [When(@"I register the '(.*)'")]
        public async Task WhenIRegisterThe(string p0)
        {
            var command = ScenarioContext.Get<CreateLeafCategoryCommand>("leaf-category");
            var leafCategoryId = await _dimensionTask.CreateLeafCategory(command);
            ScenarioContext.Add("leaf-category-Id", leafCategoryId);
        }

        [Then(@"It should be appear in the list of leaf categories")]
        public async Task ThenItShouldBeAppearInTheListOfLeafCategories()
        {
            var leafCategoryId = ScenarioContext.Get<int>("leaf-category-Id");
            var command = ScenarioContext.Get<CreateLeafCategoryCommand>("leaf-category");
            var leafCategory = await _dimensionTask.GetLeafCategory(leafCategoryId);

            leafCategory.ImageUrl.Should().Be(command.ImageName);
            leafCategory.IsActive.Should().Be(command.IsActive);
            leafCategory.SubCategoryId.Should().Be(command.SubCategoryId);
            leafCategory.MainCategoryId.Should().Be(command.MainCategoryId);
        }
    }
}