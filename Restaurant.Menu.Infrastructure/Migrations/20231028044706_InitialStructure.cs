using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Menu.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoriaMenu",
                columns: table => new
                {
                    categoriaMenuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    activa = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoriaMenu", x => x.categoriaMenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "menuItem",
                columns: table => new
                {
                    menuItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    tipo = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    categoriaMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_menuItem", x => x.menuItemId);
                    table.ForeignKey(
                        name: "FK_menuItem_categoriaMenu_categoriaMenuId",
                        column: x => x.categoriaMenuId,
                        principalTable: "categoriaMenu",
                        principalColumn: "categoriaMenuItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_menuItem_categoriaMenuId",
                table: "menuItem",
                column: "categoriaMenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "menuItem");

            migrationBuilder.DropTable(
                name: "categoriaMenu");
        }
    }
}
