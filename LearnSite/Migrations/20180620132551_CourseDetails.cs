using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSite.Migrations
{
    public partial class CourseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "CourseBriefDescription",
                "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "CourseDetailedDescription",
                "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ThingsYouWillLearn",
                "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                "CourseBriefDescription",
                "Courses");

            migrationBuilder.DropColumn(
                "CourseDetailedDescription",
                "Courses");

            migrationBuilder.DropColumn(
                "ThingsYouWillLearn",
                "Courses");
        }
    }
}