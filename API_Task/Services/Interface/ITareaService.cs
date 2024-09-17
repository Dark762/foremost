using CrossCutting.DTO;
using CrossCutting.DTO.Tarea;
using CrossCutting.DTO.Usuario;
using CrossCutting.Models;

namespace API_Task.Services.Interface
{
    public interface ITareaService
    {
        Task<StatusResponse<IEnumerable<Tarea>>> ListaTareaPorUsuario(TareaFilterDTO request);


        Task<StatusResponse> CrearTarea(TareaCreateDTO request);

        Task<StatusResponse> ActualizarTarea(TareaUpdateDTO request);

        Task<StatusResponse> BorrarTarea(TareaFilterDTO request);

        Task<StatusResponse<Tarea>> ObtenerTarea(TareaFilterDTO request);
    }



}
