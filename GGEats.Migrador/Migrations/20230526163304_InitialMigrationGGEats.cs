using Microsoft.EntityFrameworkCore.Migrations;

namespace GGEats.Migrador.Migrations
{
    public partial class InitialMigrationGGEats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fecha = table.Column<string>(nullable: true),
                    Total = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    Impuesto = table.Column<decimal>(nullable: false),
                    Product_Id = table.Column<string>(nullable: true),
                    Importado = table.Column<bool>(nullable: false),
                    Procesada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detalles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    OrdenId = table.Column<string>(nullable: true),
                    Order_Id = table.Column<string>(nullable: true),
                    Product_Id = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    Impuesto = table.Column<decimal>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Total_Linea = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    ProductoId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Detalles_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_OrdenId",
                table: "Detalles",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_ProductoId",
                table: "Detalles",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalles");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");
        }
    }
}
