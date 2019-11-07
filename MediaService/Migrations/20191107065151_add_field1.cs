using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class add_field1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExbContractID",
                table: "Interview",
                newName: "ExbContractId");

            migrationBuilder.RenameColumn(
                name: "ExbContractID",
                table: "HighlightsInfo",
                newName: "ExbContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExbContractId",
                table: "Interview",
                newName: "ExbContractID");

            migrationBuilder.RenameColumn(
                name: "ExbContractId",
                table: "HighlightsInfo",
                newName: "ExbContractID");
        }
    }
}
