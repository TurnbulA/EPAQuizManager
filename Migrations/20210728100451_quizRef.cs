using Microsoft.EntityFrameworkCore.Migrations;

namespace QuizManager.Migrations
{
    public partial class quizRef : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Quiz_QuizID",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizID",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuizID",
                table: "Quiz",
                newName: "QuizId");

            migrationBuilder.RenameColumn(
                name: "QuizID",
                table: "Question",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuizID",
                table: "Question",
                newName: "IX_Question_QuizId");

            migrationBuilder.RenameColumn(
                name: "QuizID",
                table: "Answer",
                newName: "QuizId");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuizID",
                table: "Answer",
                newName: "IX_Answer_QuizId");

            migrationBuilder.AddColumn<int>(
                name: "QuizRef",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Quiz_QuizId",
                table: "Answer",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question",
                column: "QuizId",
                principalTable: "Quiz",
                principalColumn: "QuizId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answer_Quiz_QuizId",
                table: "Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_Quiz_QuizId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "QuizRef",
                table: "Question");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Quiz",
                newName: "QuizID");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Question",
                newName: "QuizID");

            migrationBuilder.RenameIndex(
                name: "IX_Question_QuizId",
                table: "Question",
                newName: "IX_Question_QuizID");

            migrationBuilder.RenameColumn(
                name: "QuizId",
                table: "Answer",
                newName: "QuizID");

            migrationBuilder.RenameIndex(
                name: "IX_Answer_QuizId",
                table: "Answer",
                newName: "IX_Answer_QuizID");

            migrationBuilder.AddForeignKey(
                name: "FK_Answer_Quiz_QuizID",
                table: "Answer",
                column: "QuizID",
                principalTable: "Quiz",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Quiz_QuizID",
                table: "Question",
                column: "QuizID",
                principalTable: "Quiz",
                principalColumn: "QuizID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
