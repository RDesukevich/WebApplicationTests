using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationTests.Migrations
{
    public partial class Tests1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Answer",
                table: "Answers",
                newName: "AnswerToTheQuestion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AnswerToTheQuestion",
                table: "Answers",
                newName: "Answer");
        }
    }
}
