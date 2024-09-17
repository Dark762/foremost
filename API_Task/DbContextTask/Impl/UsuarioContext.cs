using API_Task.DbContextTask.Interface;
using Azure.Core;
using CrossCutting.DTO.Usuario;
using CrossCutting.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace API_Task.DbContextTask.Impl
{
    public class UsuarioContext : IUsuarioContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        private readonly AppDbContext _context;

        public UsuarioContext(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ActualizarUsuario(UsuarioUpdateDTO request)
        {

            try
            {
                var parameters = new[]
       {
                    new SqlParameter("@Id", request.Id),
                    new SqlParameter("@Nombre", request.Nombre),
                    new SqlParameter("@Apellido", request.Apellido),
                    new SqlParameter("@Correo", request.Correo),
                    new SqlParameter("@Telefono", request.Telefono),
                    new SqlParameter("@Updated_At",DateTime.Now)
                };

                var result = await _context.Database.ExecuteSqlRawAsync(
                          "EXEC SP_UpdateUsuario @Id, @Nombre, @Apellido, @Correo, @Telefono, @Updated_At",
                          parameters
                      );

                return result > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> BorrarUsuario(UsuarioFilterDTO request)
        {
            try
            {

                var parameters = new[]
                {
                    new SqlParameter("@Id", request.Id),
                };

                var result = await _context.Database.ExecuteSqlRawAsync(
                   "EXEC SP_DeleteUsuario @Id",
                   parameters
               );

                return result > 0;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CrearUsuario(UsuarioCreateDTO request)
        {
            try
            {

                var parameters = new[]
                   {
                    new SqlParameter("@Nombre", request.Nombre),
                    new SqlParameter("@Apellido", request.Apellido),
                    new SqlParameter("@Correo", request.Correo),
                    new SqlParameter("@Telefono", request.Telefono),
                    new SqlParameter("@Created_At",DateTime.Now),
                    new SqlParameter("@Updated_At", (object)DBNull.Value)
                };

                var result = await _context.Database.ExecuteSqlRawAsync(
                    "EXEC SP_InsertUsuario @Nombre, @Apellido, @Correo, @Telefono, @Created_At, @Updated_At",
                    parameters
                );

                return result > 0;
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<Usuario>> ListaUsuarios()
        {
            try
            {
                var result = await _context.Usuarios.FromSqlRaw("SELECT * FROM Usuario").ToListAsync(); ;

                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
