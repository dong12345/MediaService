using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Interview",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Interview",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "HotelRoomType",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "HotelRoomType",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "HotelBookRecord",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "HotelBookRecord",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Hotel",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Hotel",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "HighlightsInfo",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "HighlightsInfo",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "FormPublic",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "FormPublic",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "Updated_at",
                table: "Express",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "Created_at",
                table: "Express",
                newName: "CreatedAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Interview",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Interview",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "HotelRoomType",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "HotelRoomType",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "HotelBookRecord",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "HotelBookRecord",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Hotel",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Hotel",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "HighlightsInfo",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "HighlightsInfo",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "FormPublic",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "FormPublic",
                newName: "Created_at");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Express",
                newName: "Updated_at");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Express",
                newName: "Created_at");
        }
    }
}
