using CrossCutting.DTO;
using CrossCutting.Models;

namespace API_Task.Services.Interface
{
    public interface IPrioridadesService
    {
        Task<StatusResponse<IEnumerable<Prioridad>>> ListaPrioridad();
    }
}
