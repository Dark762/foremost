using API_Task.DbContextTask.Interface;
using CrossCutting.DTO.Tarea;
using CrossCutting.Models;
using Microsoft.EntityFrameworkCore;

namespace API_Task.DbContextTask.Impl
{
    public class PrioridadContext : IPrioridadContext
    {
        private readonly AppDbContext _context;

        public PrioridadContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Prioridad>> ListaPrioridad()
        {
            try
            {

                var query = _context.Prioridades.FromSqlRaw("SELECT * FROM Prioridad");

                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }

        }
    }
}
