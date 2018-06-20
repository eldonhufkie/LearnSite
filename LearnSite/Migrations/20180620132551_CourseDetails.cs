using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LearnSite.Migrations
{
    public partial class CourseDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CourseBriefDescription",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CourseDetailedDescription",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThingsYouWillLearn",
                table: "Courses",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseBriefDescription",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CourseDetailedDescription",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ThingsYouWillLearn",
                table: "Courses");
        }
    }
}
