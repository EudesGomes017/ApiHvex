using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto_Teste_Hvex.Data.Migrations
{
    public partial class Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "transformer");

            migrationBuilder.DropColumn(
                name: "ReportId",
                table: "test");

            migrationBuilder.AlterColumn<string>(
                name: "Current",
                table: "transformer",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateIndex(
                name: "IX_transformer_UserId",
                table: "transformer",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_test_TransformerId",
                table: "test",
                column: "TransformerId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_report_test_TestId",
                table: "report",
                column: "TestId",
                principalTable: "test",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_report_transformer_TransformerId",
                table: "report",
                column: "TransformerId",
                principalTable: "transformer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_report_test_TestId",
                table: "report");

            migrationBuilder.DropForeignKey(
                name: "FK_report_transformer_TransformerId",
                table: "report");

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

            migrationBuilder.DropIndex(
                name: "IX_report_TestId",
                table: "report");

            migrationBuilder.DropIndex(
                name: "IX_report_TransformerId",
                table: "report");

            migrationBuilder.AlterColumn<string>(
                name: "Current",
                table: "transformer",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "transformer",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReportId",
                table: "test",
                type: "int",
                nullable: true);
        }
    }
}
