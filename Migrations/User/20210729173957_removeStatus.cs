using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Migrations.User
{
    public partial class removeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Access",
                table: "UserLogin",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "UserLogin");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
