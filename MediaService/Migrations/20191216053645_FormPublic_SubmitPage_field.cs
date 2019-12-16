using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MediaService.Migrations
{
    public partial class FormPublic_SubmitPage_field : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmitPage",
                table: "FormPublic",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SentDate",
                table: "Express",
                nullable: true,
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmitPage",
                table: "FormPublic");

            migrationBuilder.AlterColumn<DateTime>(
                name: "SentDate",
                table: "Express",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
