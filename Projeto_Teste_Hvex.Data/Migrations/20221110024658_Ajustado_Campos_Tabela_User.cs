using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Teste_Hvex.Data.Migrations
{
    public partial class Ajustado_Campos_Tabela_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_test_transformer_TransformerId",
                table: "test");

            migrationBuilder.DropForeignKey(
                name: "FK_transformer_user_UserId",
                table: "transformer");

            migrationBuilder.DropIndex(
                name: "IX_transformer_UserId",
                table: "transformer");

            migrationBuilder.DropIndex(
                name: "IX_test_TransformerId",
                table: "test");

            migrationBuilder.AlterColumn<int>(
                name: "TransformerId",
                table: "user",
                type: "int",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TransformerId",
                table: "user",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_transformer_UserId",
                table: "transformer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_TransformerId",
                table: "test",
                column: "TransformerId");

            migrationBuilder.AddForeignKey(
                name: "FK_test_transformer_TransformerId",
                table: "test",
                column: "TransformerId",
                principalTable: "transformer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transformer_user_UserId",
                table: "transformer",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
