using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductManagement.Application.Contract.Specifications;
using ProductManagement.Specs.Tasks;
using ServiceHost;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ProductManagement.Specs.Steps
{
    [Binding]
    public class SpecificationSteps : SpecificationBaseTest
    {
        private readonly SpecificationTask _specificationTask;

        protected SpecificationSteps(WebApplicationFactory<Startup> factory, ScenarioContext scenarioContext) : base(scenarioContext)
        {
            _specificationTask = new SpecificationTask(factory.CreateClient());
        }

        [Given(@"A Specification should add to '(.*)'")]
        public void GivenASpecificationShouldAddTo(string p0)
        {
        }

        [Given(@"'(.*)' has the following specification groups")]
        public void GivenHasTheFollowingSpecificationGroups(string p0, Table table)
        {
        }

        [Given(@"'(.*)' group specification has the following items")]
        public void GivenGroupSpecificationHasTheFollowingItems(string p0, Table table)
        {
        }

        [When(@"I submit the specification")]
        public async Task WhenISubmitTheSpecification()
        {
            var leafCategoryId = ScenarioContext.Get<int>("leaf-category-Id");
            var command = new CreateSpecificationCommand
            {
                LeafCategoryId = leafCategoryId,
                Groups = new List<SpecificationGroupCommand>
                {
                    new SpecificationGroupCommand()
                    {
                        Title = "Features",
                        Items = new List<SpecificationItemCommand>
                        {
                            new SpecificationItemCommand
                            {
                                Title = "Frame Material",
                                SpecificationItemValueType = 5,
                                Options = new List<string>
                                {
                                    "Metal","Solid Wood","Manufactured Wood"
                                }
                            },
                            new SpecificationItemCommand
                            {
                                Title = "Weight Capacity (Queen Size)",
                                SpecificationItemValueType = 3,
                                Options = new List<string>()
                            },
                            new SpecificationItemCommand
                            {
                                Title = "Mattress Included",
                                SpecificationItemValueType = 2,
                                Options = new List<string>()
                            },
                        }
                    },
                    new SpecificationGroupCommand()
                    {
                        Title = "Assembly",
                        Items = new List<SpecificationItemCommand>
                        {
                            new SpecificationItemCommand
                            {
                                Title = "Level of Assembly",
                                SpecificationItemValueType = 1,
                                Options = new List<string>()
                            },
                            new SpecificationItemCommand
                            {
                                Title = "Adult Assembly Required",
                                SpecificationItemValueType = 2,
                                Options = new List<string>()
                            },
                        }
                    }
                }
            };
            ScenarioContext.Add("specification", command);

            await _specificationTask.CreateSpecification(command);
        }

        [Then(@"'(.*)' now should have the specification")]
        public async Task ThenNowShouldHaveTheSpecification(string p0)
        {
            var leafCategoryId = ScenarioContext.Get<int>("leaf-category-Id");
            var command = ScenarioContext.Get<CreateSpecificationCommand>("specification");

            var specification = await _specificationTask.GetSpecification(leafCategoryId);

            specification.LeafCategoryId.Should().Be(command.LeafCategoryId);

            specification.Groups.Should().Equal(command.Groups, (a, e) => a.Title == e.Title);

            specification.Groups.Should().SatisfyRespectively(
                firstGroup =>
                {
                    firstGroup.Items.Should()
                        .Equal(command.Groups.First().Items, (a, e) => a.Title == e.Title);

                    firstGroup.Items.Should()
                        .Equal(command.Groups.First().Items, (a, e) => a.SpecificationItemValueType == e.SpecificationItemValueType);

                    firstGroup.Items.First().Options.Should().Equal(command.Groups.First().Items.First().Options,
                        (a, e) => a.Value == e);
                },
                second =>
                {
                    second.Items.Should()
                        .Equal(command.Groups.Last().Items, (a, e) => a.Title == e.Title);

                    second.Items.Should()
                        .Equal(command.Groups.Last().Items, (a, e) => a.SpecificationItemValueType == e.SpecificationItemValueType);
                }
                );
        }
    }
}