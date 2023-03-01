using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aztobir.Data.Migrations
{
    public partial class UpdateSomeColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DilHazirlikEgitimi",
                table: "Universities",
                newName: "EducationLanguage");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FAQs",
                newName: "Question");

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "FAQs",
                newName: "Response");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "EducationLanguage",
                table: "Universities",
                newName: "DilHazirlikEgitimi");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "FAQs",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "Question",
                table: "FAQs",
                newName: "Name");
        }
    }
}
