using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPSenai.Data.Migrations
{
    /// <inheritdoc />
    public partial class mudancasAtributos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_setores_setorIdSetor",
                table: "funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_logs_funcionarios_funcionarioIdFuncionario",
                table: "logs");

            migrationBuilder.DropIndex(
                name: "IX_logs_funcionarioIdFuncionario",
                table: "logs");

            migrationBuilder.DropColumn(
                name: "IdFuncionario",
                table: "logs");

            migrationBuilder.DropColumn(
                name: "funcionarioIdFuncionario",
                table: "logs");

            migrationBuilder.DropColumn(
                name: "IdSetor",
                table: "funcionarios");

            migrationBuilder.RenameColumn(
                name: "setorIdSetor",
                table: "funcionarios",
                newName: "SetorId");

            migrationBuilder.RenameIndex(
                name: "IX_funcionarios_setorIdSetor",
                table: "funcionarios",
                newName: "IX_funcionarios_SetorId");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_logs_FuncionarioId",
                table: "logs",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_setores_SetorId",
                table: "funcionarios",
                column: "SetorId",
                principalTable: "setores",
                principalColumn: "IdSetor");

            migrationBuilder.AddForeignKey(
                name: "FK_logs_funcionarios_FuncionarioId",
                table: "logs",
                column: "FuncionarioId",
                principalTable: "funcionarios",
                principalColumn: "IdFuncionario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_setores_SetorId",
                table: "funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_logs_funcionarios_FuncionarioId",
                table: "logs");

            migrationBuilder.DropIndex(
                name: "IX_logs_FuncionarioId",
                table: "logs");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "logs");

            migrationBuilder.RenameColumn(
                name: "SetorId",
                table: "funcionarios",
                newName: "setorIdSetor");

            migrationBuilder.RenameIndex(
                name: "IX_funcionarios_SetorId",
                table: "funcionarios",
                newName: "IX_funcionarios_setorIdSetor");

            migrationBuilder.AddColumn<int>(
                name: "IdFuncionario",
                table: "logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "funcionarioIdFuncionario",
                table: "logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdSetor",
                table: "funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_logs_funcionarioIdFuncionario",
                table: "logs",
                column: "funcionarioIdFuncionario");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_setores_setorIdSetor",
                table: "funcionarios",
                column: "setorIdSetor",
                principalTable: "setores",
                principalColumn: "IdSetor");

            migrationBuilder.AddForeignKey(
                name: "FK_logs_funcionarios_funcionarioIdFuncionario",
                table: "logs",
                column: "funcionarioIdFuncionario",
                principalTable: "funcionarios",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
