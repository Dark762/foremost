using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddCrearUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_InsertUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_InsertUsuario;");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_InsertUsuario
                    @Nombre NVARCHAR(100),
                    @Apellido NVARCHAR(100),
                    @Correo NVARCHAR(100),
                    @Telefono NVARCHAR(50),
                    @Created_At DATETIME,
                    @Updated_At DATETIME
                AS
                BEGIN
                    -- Insert a new record into the Usuarios table
                    INSERT INTO Usuario (Nombre, Apellido, Correo, Telefono, Created_At, Updated_At)
                    VALUES (@Nombre, @Apellido, @Correo, @Telefono, @Created_At, @Updated_At);

                    -- Optionally, return the ID of the newly inserted record
                    SELECT SCOPE_IDENTITY() AS NewId;
                END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_InsertUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_InsertUsuario;");
        }
    }
}
