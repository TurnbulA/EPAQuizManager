using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Migrations
{
    public partial class questionRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionRef",
                table: "Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionRef",
                table: "Answer");
        }
    }
}
