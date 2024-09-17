using CrossCutting.Models;

namespace API_Task.DbContextTask.Interface
{
    public interface IPrioridadContext
    {

        Task<IEnumerable<Prioridad>> ListaPrioridad();
    }
}
