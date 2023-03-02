using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aztobir.Data.Migrations
{
    public partial class UpdateColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Experiences_ExperienceId",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ExperienceId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ExperienceId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "News");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "FAQs");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Abouts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExperienceId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Teams",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "News",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Goals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Feedbacks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "FAQs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ExperienceId",
                table: "Teams",
                column: "ExperienceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Experiences_ExperienceId",
                table: "Teams",
                column: "ExperienceId",
                principalTable: "Experiences",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
