using CrossCutting.DTO.Usuario;
using CrossCutting.Models;

namespace API_Task.DbContextTask.Interface
{
    public interface IUsuarioContext
    {
        Task<IEnumerable<Usuario>> ListaUsuarios();

        Task<bool> CrearUsuario(UsuarioCreateDTO request);

        Task<bool> ActualizarUsuario(UsuarioUpdateDTO request);

        Task<bool> BorrarUsuario(UsuarioFilterDTO request);
    }
}
