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
    public class MainCategoriesController : ControllerBase
    {
        private readonly ICommandBus _bus;
        private readonly ICategoryQueryFacade _queryFacade;
        private readonly IEventListener _eventListener;

        public MainCategoriesController(ICommandBus bus, ICategoryQueryFacade queryFacade, IEventListener eventListener)
        {
            _bus = bus;
            _queryFacade = queryFacade;
            _eventListener = eventListener;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMainCategory(CreateMainCategoryCommand command)
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
        public async Task<IActionResult> GetMainCategory(int id)
        {
            var mainCategory = await _queryFacade.GetMainCategoryById(id);
            return Ok(mainCategory);
        }

        [HttpPost("{id}/category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command)
        {
            var id = 0;
            _eventListener.Subscribe(new ActionHandler<EntityCreated>(a =>
            {
                id = a.Id;
            }));

            await _bus.Dispatch(command);

            return Ok(id);
        }

        [HttpGet("categories/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var mainCategory = await _queryFacade.GetCategoryById(id);
            return Ok(mainCategory);
        }
    }
}