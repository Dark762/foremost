using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Task.Migrations
{
    /// <inheritdoc />
    public partial class AddTarea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_InsertTarea', 'P') IS NOT NULL DROP PROCEDURE SP_InsertTarea;");

            migrationBuilder.Sql(@"
            CREATE PROCEDURE SP_InsertTarea
                        @IdUsuario INT,
                        @Titulo NVARCHAR(255),
                        @Descripcion NVARCHAR(MAX),
                        @FechaVencimiento DATETIME,
                        @Finalizado BIT,
                        @Eliminado BIT,
                        @Tags NVARCHAR(MAX),
                        @IdPrioridad INT,
                        @Created_At DATETIME,
                        @Updated_At DATETIME
                    AS
                    BEGIN
                        INSERT INTO Tarea (IdUsuario, Titulo, Descripcion, FechaVencimiento, Finalizado, Eliminado, Tags, IdPrioridad, Created_At, Updated_At)
                        VALUES (@IdUsuario, @Titulo, @Descripcion, @FechaVencimiento, @Finalizado, @Eliminado, @Tags, @IdPrioridad, @Created_At, @Updated_At);
                    END
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("IF OBJECT_ID('SP_InsertTarea', 'P') IS NOT NULL DROP PROCEDURE SP_InsertTarea;");
        }
    }
}
