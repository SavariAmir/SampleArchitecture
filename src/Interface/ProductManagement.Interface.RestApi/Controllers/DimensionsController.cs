using Anshan.Framework.Application.Command;
using Anshan.Framework.Core.Events;
using Anshan.Framework.EF;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Contract.Dimensions;
using ProductManagement.Interface.Facade.Contracts;
using System.Threading.Tasks;

namespace ProductManagement.Interface.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DimensionsController : ControllerBase
    {
        private readonly ICommandBus _bus;
        private readonly IEventListener _eventListener;
        private readonly IDimensionQueryFacade _queryFacade;

        public DimensionsController(ICommandBus bus, IEventListener eventListener, IDimensionQueryFacade queryFacade)
        {
            _bus = bus;
            _eventListener = eventListener;
            _queryFacade = queryFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDimensionCommand command)
        {
            var id = 0;
            _eventListener.Subscribe(new ActionHandler<EntityCreated>(a =>
            {
                id = a.Id;
            }));

            await _bus.Dispatch(command);

            return Ok(id);
        }

        [HttpGet("{leafCategoryId}")]
        public async Task<IActionResult> GetCategory(int leafCategoryId)
        {
            var dimension = await _queryFacade.GetDimensionByLeafCategoryId(leafCategoryId);
            return Ok(dimension);
        }
    }
}