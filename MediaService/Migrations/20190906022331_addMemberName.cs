using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class addMemberName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "HotelBookRecord",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "HotelBookRecord");
        }
    }
}
