using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSite.Migrations
{
    public partial class AddImagesToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                "ImageData",
                "Courses",
                nullable: true);

            migrationBuilder.CreateTable(
                "Images",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    ContentType = table.Column<string>(nullable: false),
                    Data = table.Column<byte[]>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Length = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Width = table.Column<int>(nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Images", x => x.Id); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Images");

            migrationBuilder.DropColumn(
                "ImageData",
                "Courses");
        }
    }
}