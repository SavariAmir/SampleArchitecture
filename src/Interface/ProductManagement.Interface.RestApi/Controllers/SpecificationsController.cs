using Anshan.Framework.Application.Command;
using Anshan.Framework.Core.Events;
using Anshan.Framework.EF;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.Contract.Specifications;
using ProductManagement.Interface.Facade.Contracts;
using System.Threading.Tasks;

namespace ProductManagement.Interface.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        private readonly ICommandBus _bus;
        private readonly IEventListener _eventListener;
        private readonly ISpecificationQueryFacade _queryFacade;

        public SpecificationsController(ICommandBus bus, IEventListener eventListener, ISpecificationQueryFacade queryFacade)
        {
            _bus = bus;
            _eventListener = eventListener;
            _queryFacade = queryFacade;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSpecificationCommand command)
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
            var specification = await _queryFacade.GetSpecificationByLeafCategoryId(leafCategoryId);
            return Ok(specification);
        }
    }
}