using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Task.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_UpdateTarea', 'P') IS NOT NULL DROP PROCEDURE SP_UpdateTarea;");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_UpdateTarea
                                @Id INT,
                              
                                @Titulo NVARCHAR(255),
                                @Descripcion NVARCHAR(MAX),
                                @FechaVencimiento DATETIME,
                                @Finalizado BIT,
                                @Eliminado BIT,
                                @Tags NVARCHAR(MAX),
                                @IdPrioridad INT,
                                @Updated_At DATETIME
                            AS
                            BEGIN
                                UPDATE Tarea
                                SET 
                                    Titulo = @Titulo,
                                    Descripcion = @Descripcion,
                                    FechaVencimiento = @FechaVencimiento,
                                    Finalizado = @Finalizado,
                                    Eliminado = @Eliminado,
                                    Tags = @Tags,
                                    IdPrioridad = @IdPrioridad,
                                    Updated_At = @Updated_At
                                WHERE Id = @Id;
                            END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_UpdateTarea', 'P') IS NOT NULL DROP PROCEDURE SP_UpdateTarea;");
        }
    }
}
