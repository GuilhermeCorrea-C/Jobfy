using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Jobfy_API.Migrations
{
    /// <inheritdoc />
    public partial class MigrationIncremental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Agendamento",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicio",
                table: "Agendamento",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Despesas",
                table: "Agendamento",
                type: "numeric",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "DataInicio",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Despesas",
                table: "Agendamento");
        }
    }
}
