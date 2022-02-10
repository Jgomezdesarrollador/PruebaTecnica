using Microsoft.EntityFrameworkCore.Migrations;

namespace Catalogo.Migrations
{
    public partial class v100 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contenido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo_producto = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    clase_producto = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    autor = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenido", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contenido");
        }
    }
}
