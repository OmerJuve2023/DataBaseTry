﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataBaseTry.Migrations
{
    /// <inheritdoc />
    public partial class AddInstitucionToUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Institucion",
                table: "Usuarios",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Institucion",
                table: "Usuarios");
        }
    }
}
