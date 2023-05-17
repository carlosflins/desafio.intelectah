using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(14)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: true),
                    Sexo = table.Column<int>(type: "int", nullable: true),
                    Telefone = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoExame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(256)", nullable: true, defaultValue: "")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExame", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(1000)", nullable: true, defaultValue: ""),
                    TipoExameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exame_TipoExame_TipoExameId",
                        column: x => x.TipoExameId,
                        principalTable: "TipoExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarcacaoConsulta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    TipoExameId = table.Column<int>(type: "int", nullable: false),
                    ExameId = table.Column<int>(type: "int", nullable: true),
                    DataHoraMarcacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Protocolo = table.Column<string>(type: "varchar(40)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcacaoConsulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarcacaoConsulta_Exame_ExameId",
                        column: x => x.ExameId,
                        principalTable: "Exame",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MarcacaoConsulta_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MarcacaoConsulta_TipoExame_TipoExameId",
                        column: x => x.TipoExameId,
                        principalTable: "TipoExame",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exame_TipoExameId",
                table: "Exame",
                column: "TipoExameId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoConsulta_ExameId",
                table: "MarcacaoConsulta",
                column: "ExameId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoConsulta_PacienteId",
                table: "MarcacaoConsulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoConsulta_Protocolo",
                table: "MarcacaoConsulta",
                column: "Protocolo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarcacaoConsulta_TipoExameId",
                table: "MarcacaoConsulta",
                column: "TipoExameId");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_CPF",
                table: "Paciente",
                column: "CPF",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarcacaoConsulta");

            migrationBuilder.DropTable(
                name: "Exame");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "TipoExame");
        }
    }
}
