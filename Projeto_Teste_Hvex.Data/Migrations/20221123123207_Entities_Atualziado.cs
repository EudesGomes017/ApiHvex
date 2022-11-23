using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Teste_Hvex.Data.Migrations
{
    public partial class Entities_Atualziado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_report_TestId",
                table: "report");

            migrationBuilder.DropIndex(
                name: "IX_report_TransformerId",
                table: "report");

            migrationBuilder.DropColumn(
                name: "TransformerId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "TestId",
                table: "transformer");

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

            migrationBuilder.AlterColumn<string>(
                name: "Current",
                table: "transformer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_report_TestId",
                table: "report",
                column: "TestId");

            migrationBuilder.CreateIndex(
                name: "IX_report_TransformerId",
                table: "report",
                column: "TransformerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_report_TestId",
                table: "report");

            migrationBuilder.DropIndex(
                name: "IX_report_TransformerId",
                table: "report");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "user",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AddColumn<int>(
                name: "TransformerId",
                table: "user",
                type: "int",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Current",
                table: "transformer",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TestId",
                table: "transformer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_report_TestId",
                table: "report",
                column: "TestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_report_TransformerId",
                table: "report",
                column: "TransformerId",
                unique: true);
        }
    }
}
