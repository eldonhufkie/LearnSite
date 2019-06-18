using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSite.Migrations
{
    public partial class userIDToCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "UserId",
                "Courses",
                nullable: true);

            migrationBuilder.CreateIndex(
                "IX_Courses_UserId",
                "Courses",
                "UserId");

            migrationBuilder.AddForeignKey(
                "FK_Courses_AspNetUsers_UserId",
                "Courses",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Courses_AspNetUsers_UserId",
                "Courses");

            migrationBuilder.DropIndex(
                "IX_Courses_UserId",
                "Courses");

            migrationBuilder.DropColumn(
                "UserId",
                "Courses");
        }
    }
}