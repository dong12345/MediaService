using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class addInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Interview",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Interview",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "HighlightsInfo",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "HighlightsInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Website",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "HighlightsInfo");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "HighlightsInfo");
        }
    }
}
