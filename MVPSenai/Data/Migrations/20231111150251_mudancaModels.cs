using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVPSenai.Data.Migrations
{
    /// <inheritdoc />
    public partial class mudancaModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_setores_setorIdSetor",
                table: "funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "setorIdSetor",
                table: "funcionarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_setores_setorIdSetor",
                table: "funcionarios",
                column: "setorIdSetor",
                principalTable: "setores",
                principalColumn: "IdSetor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_funcionarios_setores_setorIdSetor",
                table: "funcionarios");

            migrationBuilder.AlterColumn<int>(
                name: "setorIdSetor",
                table: "funcionarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_funcionarios_setores_setorIdSetor",
                table: "funcionarios",
                column: "setorIdSetor",
                principalTable: "setores",
                principalColumn: "IdSetor",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
