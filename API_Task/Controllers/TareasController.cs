using API_Task.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using CrossCutting.DTO.Tarea;

namespace API_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareasController : ControllerBase
    {

        public readonly ITareaService _tareaService;


        public TareasController(ITareaService tareaService) {
            _tareaService = tareaService;
        }

        [HttpGet("ListaTareaPorUsuario")]
        public async Task<ActionResult> ListaTareaPorUsuario([FromQuery] TareaFilterDTO request) {

            var result = await _tareaService.ListaTareaPorUsuario(request);

            return Ok(result);
        }

        [HttpGet("ObtenerTarea")]
        public async Task<ActionResult> ObtenerTarea([FromQuery] TareaFilterDTO request)
        {

            var result = await _tareaService.ObtenerTarea(request);

            return Ok(result);
        }

        [HttpPost("CrearTarea")]
        public async Task<ActionResult> CrearTarea([FromBody] TareaCreateDTO request)
        {

            var result = await _tareaService.CrearTarea(request);

            return Ok(result);
        }

        [HttpPut("ActualizarTarea")]
        public async Task<ActionResult> ActualizarTarea([FromBody] TareaUpdateDTO request)
        {

            var result = await _tareaService.ActualizarTarea(request);

            return Ok(result);
        }

        [HttpDelete("BorrarTarea")]
        public async Task<ActionResult> BorrarTarea([FromBody] TareaFilterDTO request)
        {

            var result = await _tareaService.BorrarTarea(request);

            return Ok(result);
        }

    }
}
