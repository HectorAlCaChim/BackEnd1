using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class new05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horarios_maestros_Rfc",
                table: "horarios");

            migrationBuilder.DropIndex(
                name: "IX_horarios_Rfc",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "Rfc",
                table: "horarios");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rfc",
                table: "horarios",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_horarios_Rfc",
                table: "horarios",
                column: "Rfc");

            migrationBuilder.AddForeignKey(
                name: "FK_horarios_maestros_Rfc",
                table: "horarios",
                column: "Rfc",
                principalTable: "maestros",
                principalColumn: "Rfc",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
