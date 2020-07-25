using Microsoft.AspNetCore.Mvc.Testing;
using ServiceHost;
using Xunit;

namespace ProductManagement.DataBase.Tests.Integration
{
    public class ProductRepositoryTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ProductRepositoryTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Test1()
        {
        }
    }
}