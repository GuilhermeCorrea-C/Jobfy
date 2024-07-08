using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobfy_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Agendamento",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_UsuarioId",
                table: "Agendamento",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agendamento_Usuario_UsuarioId",
                table: "Agendamento",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agendamento_Usuario_UsuarioId",
                table: "Agendamento");

            migrationBuilder.DropIndex(
                name: "IX_Agendamento_UsuarioId",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Agendamento");
        }
    }
}
