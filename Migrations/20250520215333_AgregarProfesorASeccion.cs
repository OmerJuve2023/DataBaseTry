using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseTry.Migrations
{
    /// <inheritdoc />
    public partial class AgregarProfesorASeccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfesorId",
                table: "Secciones",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Secciones_ProfesorId",
                table: "Secciones",
                column: "ProfesorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Secciones_Usuarios_ProfesorId",
                table: "Secciones",
                column: "ProfesorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Secciones_Usuarios_ProfesorId",
                table: "Secciones");

            migrationBuilder.DropIndex(
                name: "IX_Secciones_ProfesorId",
                table: "Secciones");

            migrationBuilder.DropColumn(
                name: "ProfesorId",
                table: "Secciones");
        }
    }
}
