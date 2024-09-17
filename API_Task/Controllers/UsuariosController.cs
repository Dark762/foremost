using API_Task.Services.Impl;
using API_Task.Services.Interface;
using CrossCutting.DTO.Tarea;
using CrossCutting.DTO.Usuario;
using Microsoft.AspNetCore.Mvc;

namespace API_Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        public readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }


        [HttpPost("CrearUsuario")]
        public async Task<ActionResult> CrearUsuario([FromBody] UsuarioCreateDTO request)
        {

            var result = await _usuarioService.CrearUsuario(request);

            return Ok(result);
        }

        [HttpPut("ActualizarUsuario")]
        public async Task<ActionResult> ActualizarUsuario([FromBody] UsuarioUpdateDTO request)
        {

            var result = await _usuarioService.ActualizarUsuario(request);

            return Ok(result);
        }

        [HttpDelete("BorrarUsuario")]
        public async Task<ActionResult> BorrarUsuario([FromBody] UsuarioFilterDTO request)
        {

            var result = await _usuarioService.BorrarUsuario(request);

            return Ok(result);
        }

        [HttpGet("ListaUsuarios")]
        public async Task<ActionResult> ListaUsuarios()
        {

            var result = await _usuarioService.ListaUsuarios();

            return Ok(result);
        }
    }
}
