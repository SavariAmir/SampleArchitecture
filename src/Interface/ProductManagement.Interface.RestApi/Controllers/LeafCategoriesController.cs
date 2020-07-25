using Anshan.Framework.Application.Command;
using Anshan.Framework.Core.Events;
using Anshan.Framework.EF;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Contract;
using ProductManagement.Interface.Facade.Contracts;
using System.Threading.Tasks;

namespace ProductManagement.Interface.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeafCategoriesController : ControllerBase
    {
        private readonly ICommandBus _bus;
        private readonly IEventListener _eventListener;
        private readonly ICategoryQueryFacade _queryFacade;

        public LeafCategoriesController(ICommandBus bus, IEventListener eventListener, ICategoryQueryFacade queryFacade)
        {
            _bus = bus;
            _eventListener = eventListener;
            _queryFacade = queryFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLeafCategoryCommand command)
        {
            var id = 0;
            _eventListener.Subscribe(new ActionHandler<EntityCreated>(a => { id = a.Id; }));

            await _bus.Dispatch(command);

            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var leaf = await _queryFacade.GetLeafCategoryById(id);

            return Ok(leaf);
        }
    }
}