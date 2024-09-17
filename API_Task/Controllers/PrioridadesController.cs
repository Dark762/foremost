using API_Task.Services.Interface;
using CrossCutting.DTO.Tarea;
using Microsoft.AspNetCore.Mvc;

namespace API_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioridadesController : ControllerBase
    {
        public readonly IPrioridadesService _prioridadService;

        public PrioridadesController(IPrioridadesService prioridadService) {
            _prioridadService = prioridadService;
        }

        [HttpGet("ListaPrioridad")]
        public async Task<ActionResult> ListaPrioridad()
        {

            var result = await _prioridadService.ListaPrioridad();

            return Ok(result);
        }
    }
}
