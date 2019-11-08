using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class interview_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Interview",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Interview",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Interview");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Interview");
        }
    }
}
