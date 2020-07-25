using Anshan.Framework.Application.Command;
using Anshan.Framework.Core.Events;
using Anshan.Framework.EF;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Contract;
using ProductManagement.Application.Contract.Products;
using ProductManagement.Interface.Facade.Contracts;
using System.Threading.Tasks;

namespace ProductManagement.Interface.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ICommandBus _bus;
        private readonly IEventListener _eventListener;
        private readonly IProductQueryFacade _queryFacade;

        public ProductsController(ICommandBus bus, IEventListener eventListener, IProductQueryFacade queryFacade)
        {
            _bus = bus;
            _eventListener = eventListener;
            _queryFacade = queryFacade;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var id = 0;
            _eventListener.Subscribe(new ActionHandler<EntityCreated>(a =>
            {
                id = a.Id;
            }));

            await _bus.Dispatch(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var mainCategory = await _queryFacade.GetProductById(id);
            return Ok(mainCategory);
        }

        [HttpPost("create-product-variety")]
        public async Task<IActionResult> CreateProductVariety(CreateProductVarietyCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }

        [HttpPost("dimension")]
        public async Task<IActionResult> UpdateDimension(UpdateProductDimensionCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }

        [HttpPost("specification")]
        public async Task<IActionResult> UpdateSpecification(UpdateProductSpecificationCommand command)
        {
            await _bus.Dispatch(command);
            return Ok();
        }
    }
}