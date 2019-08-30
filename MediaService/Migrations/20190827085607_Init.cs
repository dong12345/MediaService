using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkManCountryId",
                table: "HotelBookRecord");

            migrationBuilder.AddColumn<string>(
                name: "LinkManCountry",
                table: "HotelBookRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkManCountry",
                table: "HotelBookRecord");

            migrationBuilder.AddColumn<int>(
                name: "LinkManCountryId",
                table: "HotelBookRecord",
                nullable: false,
                defaultValue: 0);
        }
    }
}
