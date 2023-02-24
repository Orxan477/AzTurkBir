using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aztobir.Data.Migrations
{
    public partial class OneColumnNameChangedAndOneColumnTypeChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Positions_PositionId1",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PositionId1",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "PositionId1",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Universities",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Teams",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "News",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Goals",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Feedbacks",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "FAQs",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "İsDeleted",
                table: "Abouts",
                newName: "IsDeleted");

            migrationBuilder.AlterColumn<int>(
                name: "PositionId",
                table: "Teams",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PositionId",
                table: "Teams",
                column: "PositionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Positions_PositionId",
                table: "Teams",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Positions_PositionId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_PositionId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Universities",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Teams",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "News",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Goals",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Feedbacks",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "FAQs",
                newName: "İsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Abouts",
                newName: "İsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "PositionId",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PositionId1",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_PositionId1",
                table: "Teams",
                column: "PositionId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Positions_PositionId1",
                table: "Teams",
                column: "PositionId1",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
