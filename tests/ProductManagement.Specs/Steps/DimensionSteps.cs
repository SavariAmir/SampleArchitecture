using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductManagement.Application.Contract.Dimensions;
using ProductManagement.Specs.Tasks;
using ServiceHost;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProductManagement.Specs.Steps
{
    [Binding]
    public class DimensionSteps : SpecificationBaseTest
    {
        private readonly DimensionTask _dimensionTask;

        protected DimensionSteps(WebApplicationFactory<Startup> factory, ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _dimensionTask = new DimensionTask(factory.CreateClient());
        }

        [Given(@"Dimension should add to '(.*)'")]
        public void GivenDimensionShouldAddTo(string p0)
        {
        }

        [Given(@"'(.*)' has the following groups")]
        public void GivenHasTheFollowingGroups(string p0, Table table)
        {
        }

        [Given(@"'(.*)' has the following items")]
        public void GivenHasTheFollowingItems(string p0, Table table)
        {
        }

        [When(@"I submit the dimension")]
        public async Task WhenISubmitTheDimension()
        {
            var leafCategoryId = ScenarioContext.Get<int>("leaf-category-Id");
            var command = new CreateDimensionCommand
            {
                LeafCategoryId = leafCategoryId,
                Groups = new List<DimensionGroupCommand>
                {
                    new DimensionGroupCommand()
                    {
                        Title = "Twin Size",
                        Items = new List<DimensionItemCommand>
                        {
                            new DimensionItemCommand
                            {
                                Title = "Overall Product Weight",
                                UnitOfMeasurementType = 1
                            },
                            new DimensionItemCommand
                            {
                                Title = "Overall Product Height",
                                UnitOfMeasurementType = 2
                            },
                        }
                    },
                    new DimensionGroupCommand()
                    {
                        Title = "Full Size",
                        Items = new List<DimensionItemCommand>
                        {
                            new DimensionItemCommand
                            {
                                Title = "Overall Product Weight",
                                UnitOfMeasurementType = 1
                            },
                            new DimensionItemCommand
                            {
                                Title = "Overall Product Height",
                                UnitOfMeasurementType = 2
                            },
                        }
                    },
                }
            };
            ScenarioContext.Add("dimension", command);

            var id = await _dimensionTask.CreateDimension(command);
            ScenarioContext.Add("dimension-Id", id);
        }

        [Then(@"'(.*)' now should have the dimension")]
        public async Task ThenNowShouldHaveTheDimension(string p0)
        {
            var leafCategoryId = ScenarioContext.Get<int>("leaf-category-Id");
            var command = ScenarioContext.Get<CreateDimensionCommand>("dimension");

            var dimension = await _dimensionTask.GetDimension(leafCategoryId);

            dimension.LeafCategoryId.Should().Be(command.LeafCategoryId);
            dimension.Groups.Should().BeEquivalentTo(command.Groups);
        }
    }
}