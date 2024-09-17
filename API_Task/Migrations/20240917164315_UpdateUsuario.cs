using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Task.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_UpdateUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_UpdateUsuario;");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_UpdateUsuario
                     @Id INT,
                    @Nombre NVARCHAR(100),
                    @Apellido NVARCHAR(100),
                    @Correo NVARCHAR(100),
                    @Telefono NVARCHAR(20),
                    @Updated_At DATETIME
                AS
                BEGIN
                    UPDATE Usuario
                    SET Nombre = @Nombre,
                        Apellido = @Apellido,
                        Correo = @Correo,
                        Telefono = @Telefono,
                        Updated_At = @Updated_At
                    WHERE Id = @Id;
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_UpdateUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_UpdateUsuario;");
        }
    }
}
