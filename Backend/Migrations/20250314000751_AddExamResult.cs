using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuizAppForDriverLicense.Migrations
{
    public partial class AddExamResult : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserExam_userId",
                table: "UserExam",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExam_AspNetUsers_userId",
                table: "UserExam",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExam_AspNetUsers_userId",
                table: "UserExam");

            migrationBuilder.DropIndex(
                name: "IX_UserExam_userId",
                table: "UserExam");
        }
    }
}
