using CrossCutting.DTO;
using CrossCutting.DTO.Tarea;
using CrossCutting.DTO.Usuario;
using CrossCutting.Models;

namespace API_Task.DbContextTask.Interface
{
    public interface ITareaContext
    {
        Task<IEnumerable<Tarea>> ListaTareaPorUsuario(TareaFilterDTO request);


        Task<bool> CrearTarea(TareaCreateDTO request);

        Task<bool> ActualizarTarea(TareaUpdateDTO request);

        Task<bool> BorrarTarea(TareaFilterDTO request);

        Task<Tarea> ObtenerTarea(TareaFilterDTO request);
    }
}
