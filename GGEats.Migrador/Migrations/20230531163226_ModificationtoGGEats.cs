using Microsoft.EntityFrameworkCore.Migrations;

namespace GGEats.Migrador.Migrations
{
    public partial class ModificationtoGGEats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Productos_ProductoId",
                table: "Detalles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Detalles_ProductoId",
                table: "Detalles");

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Detalles");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Detalles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Detalles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Detalles");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Detalles");

            migrationBuilder.AddColumn<string>(
                name: "ProductoId",
                table: "Detalles",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_ProductoId",
                table: "Detalles",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Productos_ProductoId",
                table: "Detalles",
                column: "ProductoId",
                principalTable: "Productos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
