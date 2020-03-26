using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class new01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiantes",
                columns: table => new
                {
                    IdEstudiantes = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido1 = table.Column<string>(maxLength: 200, nullable: false),
                    Apellido2 = table.Column<string>(maxLength: 200, nullable: false),
                    Edad = table.Column<int>(maxLength: 200, nullable: false),
                    Genero = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiantes", x => x.IdEstudiantes);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    email = table.Column<string>(nullable: false),
                    password = table.Column<string>(maxLength: 200, nullable: false),
                    name = table.Column<string>(maxLength: 200, nullable: false),
                    lastName = table.Column<string>(maxLength: 200, nullable: false),
                    role = table.Column<string>(maxLength: 200, nullable: false),
                    token = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.email);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estudiantes");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
