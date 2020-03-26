using Microsoft.EntityFrameworkCore.Migrations;

namespace scm.Migrations
{
    public partial class new04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MaestrosRfc",
                table: "horarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_horarios_MaestrosRfc",
                table: "horarios",
                column: "MaestrosRfc");

            migrationBuilder.AddForeignKey(
                name: "FK_horarios_maestros_MaestrosRfc",
                table: "horarios",
                column: "MaestrosRfc",
                principalTable: "maestros",
                principalColumn: "Rfc",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_horarios_maestros_MaestrosRfc",
                table: "horarios");

            migrationBuilder.DropIndex(
                name: "IX_horarios_MaestrosRfc",
                table: "horarios");

            migrationBuilder.DropColumn(
                name: "MaestrosRfc",
                table: "horarios");
        }
    }
}
