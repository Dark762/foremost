using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Task.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_DeleteUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_DeleteUsuario;");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_DeleteUsuario
                        @Id INT
                    AS
                    BEGIN
                        DELETE FROM Usuario
                        WHERE Id = @Id;
                    END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_DeleteUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_DeleteUsuario;");
        }
    }
}
