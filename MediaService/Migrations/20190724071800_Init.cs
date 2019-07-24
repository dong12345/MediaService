using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HptelRoomTypeId",
                table: "HotelRoomType",
                newName: "HotelRoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HotelRoomTypeId",
                table: "HotelRoomType",
                newName: "HptelRoomTypeId");
        }
    }
}
