using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Menu.Application.Dto;
using Restaurant.Menu.Application.UseCases.Categorias.CrearCategoriaMenu;
using Restaurant.Menu.Application.UseCases.Categorias.GetCategoriasMenu;
using Restaurant.Menu.WebAPI.Model;

namespace Restaurant.Menu.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private readonly IMediator _mediator;

        public CategoriaController(IMediator mediator, ILogger<CategoriaController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CrearCategoriaMenuCommand command)
        {

            try
            {
                var categoriaId  = await _mediator.Send(command);

                return Ok(categoriaId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear la categoria");
            }
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<CategoriaDto>>> Get()
        {
            try
            {
                var categorias = await _mediator.Send(new GetCategoriasMenuQuery());

                return Ok(categorias);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener las categorias");
            }
            return StatusCode(500);
        }

        //[Route("{itemId}")]
        //[HttpGet]
        //public ActionResult<MenuItem> Get(Guid itemId)
        //{
        //    Model.MenuItem item = _menu.GetItem(itemId.ToString().ToUpper());

        //    return item == null ? NotFound() : Ok(item);
        //}
    }
}