using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSite.Migrations
{
    public partial class addCourseModel : Migration
    {
        //Section and Course ID
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "SectionId",
                "Videos",
                nullable: true);

            migrationBuilder.CreateTable(
                "Courses",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Courses", x => x.Id); });

            migrationBuilder.CreateTable(
                "Sections",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: true),
                    SectionDescription = table.Column<string>(nullable: true),
                    SectionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                    table.ForeignKey(
                        "FK_Sections_Courses_CourseId",
                        x => x.CourseId,
                        "Courses",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                "IX_Videos_SectionId",
                "Videos",
                "SectionId");

            migrationBuilder.CreateIndex(
                "IX_Sections_CourseId",
                "Sections",
                "CourseId");

            migrationBuilder.AddForeignKey(
                "FK_Videos_Sections_SectionId",
                "Videos",
                "SectionId",
                "Sections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Videos_Sections_SectionId",
                "Videos");

            migrationBuilder.DropTable(
                "Sections");

            migrationBuilder.DropTable(
                "Courses");

            migrationBuilder.DropIndex(
                "IX_Videos_SectionId",
                "Videos");

            migrationBuilder.DropColumn(
                "SectionId",
                "Videos");
        }
    }
}