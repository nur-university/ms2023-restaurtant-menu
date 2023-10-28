using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Menu.Application.UseCases.MenuItems.CrearMenuItem;
using Restaurant.Menu.Application.UseCases.MenuItems.GetMenuItemById;
using Restaurant.Menu.WebAPI.Model;

namespace Restaurant.Menu.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemController : ControllerBase
    {
        private readonly ILogger<MenuItemController> _logger;
        private readonly IMediator _mediator;

        public MenuItemController(IMediator mediator, ILogger<MenuItemController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearMenuItemCommand command)
        {
            try
            {
                var menuItemId = await _mediator.Send(command);

                return Ok(menuItemId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear el item");
            }
            return StatusCode(500);
        }

        [Route("{itemId}")]
        [HttpGet]
        public async Task<ActionResult> Get(Guid itemId)
        {
            var item = await _mediator.Send(new GetMenuItemByIdQuery(itemId));

            return item == null ? NotFound() : Ok(item);
        }
    }
}