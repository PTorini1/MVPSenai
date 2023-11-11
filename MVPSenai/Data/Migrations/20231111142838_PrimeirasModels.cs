using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPSenai.Data.Migrations
{
    /// <inheritdoc />
    public partial class PrimeirasModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "setores",
                columns: table => new
                {
                    IdSetor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSetor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setores", x => x.IdSetor);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Equipamentos = table.Column<bool>(type: "bit", nullable: false),
                    setorIdSetor = table.Column<int>(type: "int", nullable: false),
                    IdSetor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_funcionarios_setores_setorIdSetor",
                        column: x => x.setorIdSetor,
                        principalTable: "setores",
                        principalColumn: "IdSetor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "logs",
                columns: table => new
                {
                    IdLogs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFuncionario = table.Column<int>(type: "int", nullable: false),
                    funcionarioIdFuncionario = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HorasTrabalhadas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.IdLogs);
                    table.ForeignKey(
                        name: "FK_logs_funcionarios_funcionarioIdFuncionario",
                        column: x => x.funcionarioIdFuncionario,
                        principalTable: "funcionarios",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_setorIdSetor",
                table: "funcionarios",
                column: "setorIdSetor");

            migrationBuilder.CreateIndex(
                name: "IX_logs_funcionarioIdFuncionario",
                table: "logs",
                column: "funcionarioIdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "setores");
        }
    }
}
