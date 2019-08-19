using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Hotel",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Country",
                table: "Hotel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
