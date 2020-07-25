using Microsoft.AspNetCore.Mvc.Testing;
using ServiceHost;
using TechTalk.SpecFlow;
using Xunit;

namespace ProductManagement.Specs
{
    public class SpecificationBaseTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        protected readonly ScenarioContext ScenarioContext;

        protected SpecificationBaseTest(ScenarioContext scenarioContext)
        {
            ScenarioContext = scenarioContext;
        }
    }
}