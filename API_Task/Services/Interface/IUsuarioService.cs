using CrossCutting.DTO;
using CrossCutting.DTO.Tarea;
using CrossCutting.DTO.Usuario;
using CrossCutting.Models;

namespace API_Task.Services.Interface
{
    public interface IUsuarioService
    {
        Task<StatusResponse> CrearUsuario(UsuarioCreateDTO request);

        Task<StatusResponse> ActualizarUsuario(UsuarioUpdateDTO request);

        Task<StatusResponse> BorrarUsuario(UsuarioFilterDTO request);

        Task<StatusResponse<IEnumerable<Usuario>>> ListaUsuarios();
    }
}
