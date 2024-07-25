using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaSaude.Api.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaotabelaAgendamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Agendamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Agendamento",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Paciente",
                table: "Agendamento",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Agendamento",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Paciente",
                table: "Agendamento");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Agendamento");
        }
    }
}
