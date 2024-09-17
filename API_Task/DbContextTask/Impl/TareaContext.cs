using API_Task.DbContextTask.Interface;
using Azure.Core;
using CrossCutting.DTO;
using CrossCutting.DTO.Tarea;
using CrossCutting.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Threading;

namespace API_Task.DbContextTask.Impl
{
    public class TareaContext : ITareaContext
    {
        private readonly AppDbContext _context;

        public TareaContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarTarea(TareaUpdateDTO request)
        {
            try
            {

                var parameters = new[]
                  {
                    new SqlParameter("@Id", request.Id),

                    new SqlParameter("@Titulo", request.Titulo),
                    new SqlParameter("@Descripcion", request.Descripcion),
                    new SqlParameter("@FechaVencimiento", request.FechaVencimiento),
                    new SqlParameter("@Finalizado", request.Finalizado),
                    new SqlParameter("@Eliminado", request.Eliminado),
                    new SqlParameter("@Tags", request.Tags),
                    new SqlParameter("@IdPrioridad", request.IdPrioridad),
                    new SqlParameter("@Updated_At", DateTime.Now)
                };

                var result = await _context.Database.ExecuteSqlRawAsync(
                             "EXEC SP_UpdateTarea @Id, @Titulo, @Descripcion, @FechaVencimiento, @Finalizado, @Eliminado, @Tags, @IdPrioridad, @Updated_At",
                             parameters
                         );

                return result > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> BorrarTarea(TareaFilterDTO request)
        {
            try
            {

                var parameters = new[]
                {
                    new SqlParameter("@Id", request.Id),
                };

                var result = await _context.Database.ExecuteSqlRawAsync(
                   "EXEC SP_DeleteTarea @Id",
                   parameters
               );

                return result > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CrearTarea(TareaCreateDTO request)
        {
            try
            {
                var parameters = new[]
                   {
                    new SqlParameter("@IdUsuario", request.IdUsuario),
                    new SqlParameter("@Titulo", request.Titulo),
                    new SqlParameter("@Descripcion", request.Descripcion),
                    new SqlParameter("@FechaVencimiento", request.FechaVencimiento),
                    new SqlParameter("@Finalizado", request.Finalizado),
                    new SqlParameter("@Eliminado", request.Eliminado),
                    new SqlParameter("@Tags", request.Tags),
                    new SqlParameter("@IdPrioridad", request.IdPrioridad),
                    new SqlParameter("@Created_At",DateTime.Now),
                    new SqlParameter("@Updated_At", (object)DBNull.Value)
                };

                var result = await _context.Database.ExecuteSqlRawAsync(
                            "EXEC SP_InsertTarea @IdUsuario, @Titulo, @Descripcion, @FechaVencimiento, @Finalizado, @Eliminado, @Tags, @IdPrioridad, @Created_At, @Updated_At",
                          parameters
                    );

                return result > 0;
            }
            catch
            {
                throw;
            }
        }



        public async Task<IEnumerable<Tarea>> ListaTareaPorUsuario(TareaFilterDTO request)
        {
            try
            {

                var tareas = await _context.Tareas
                    .Where(t => t.IdUsuario == request.IdUsuario)
                    .Include(t => t.Prioridad) // Assuming Prioridad is a navigation property in Tarea
                    .ToListAsync();

                return tareas;
            }
            catch
            {
                throw;
            }

        }

        public async Task<Tarea> ObtenerTarea(TareaFilterDTO request)
        {
            try
            {

                var query = await _context.Tareas.FromSqlRaw("SELECT * FROM TAREA WHERE Id = {0}", request.Id).ToListAsync();

                return query.FirstOrDefault();
            }
            catch
            {
                throw;
            }

        }
    }
}
