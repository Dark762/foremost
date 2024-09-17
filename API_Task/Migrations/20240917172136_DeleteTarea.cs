using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Task.Migrations
{
    /// <inheritdoc />
    public partial class DeleteTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_DeleteTarea', 'P') IS NOT NULL DROP PROCEDURE SP_DeleteTarea;");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_DeleteTarea
                                @Id INT
                            AS
                            BEGIN
                                DELETE FROM Tarea
                                WHERE Id = @Id;
                            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_DeleteTarea', 'P') IS NOT NULL DROP PROCEDURE SP_DeleteTarea;");
        }
    }
}
