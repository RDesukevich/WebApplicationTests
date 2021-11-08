using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationTests.Migrations
{
    public partial class Tests1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Questions",
                newName: "Request");

            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Answers",
                newName: "Response");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Request",
                table: "Questions",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Response",
                table: "Answers",
                newName: "Answer");
        }
    }
}
