using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class new_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExbContractID",
                table: "Interview",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExbContractID",
                table: "HighlightsInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsExhibitor",
                table: "Express",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Year",
                table: "Express",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExbContractID",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "ExbContractID",
                table: "HighlightsInfo");

            migrationBuilder.DropColumn(
                name: "IsExhibitor",
                table: "Express");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Express");
        }
    }
}
