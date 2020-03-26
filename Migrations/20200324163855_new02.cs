using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class new02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "maestros",
                columns: table => new
                {
                    Rfc = table.Column<string>(nullable: false),
                    Nombres = table.Column<string>(maxLength: 200, nullable: false),
                    Apellidos = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_maestros", x => x.Rfc);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    Materia = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.Materia);
                });

            migrationBuilder.CreateTable(
                name: "horarios",
                columns: table => new
                {
                    Clave = table.Column<string>(nullable: false),
                    Dias = table.Column<string>(maxLength: 200, nullable: false),
                    Salon = table.Column<string>(maxLength: 200, nullable: false),
                    Materia = table.Column<string>(nullable: true),
                    Rfc = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_horarios", x => x.Clave);
                    table.ForeignKey(
                        name: "FK_horarios_materias_Materia",
                        column: x => x.Materia,
                        principalTable: "materias",
                        principalColumn: "Materia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_horarios_maestros_Rfc",
                        column: x => x.Rfc,
                        principalTable: "maestros",
                        principalColumn: "Rfc",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_horarios_Materia",
                table: "horarios",
                column: "Materia");

            migrationBuilder.CreateIndex(
                name: "IX_horarios_Rfc",
                table: "horarios",
                column: "Rfc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "horarios");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "maestros");
        }
    }
}
