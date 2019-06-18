using Microsoft.EntityFrameworkCore.Migrations;

namespace LearnSite.Data.Migrations
{
    public partial class initialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "UserNameIndex",
                "AspNetUsers");

            migrationBuilder.DropIndex(
                "IX_AspNetUserRoles_UserId",
                "AspNetUserRoles");

            migrationBuilder.DropIndex(
                "RoleNameIndex",
                "AspNetRoles");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                "FK_AspNetUserTokens_AspNetUsers_UserId",
                "AspNetUserTokens",
                "UserId",
                "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_AspNetUserTokens_AspNetUsers_UserId",
                "AspNetUserTokens");

            migrationBuilder.DropIndex(
                "UserNameIndex",
                "AspNetUsers");

            migrationBuilder.DropIndex(
                "RoleNameIndex",
                "AspNetRoles");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_UserId",
                "AspNetUserRoles",
                "UserId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName");
        }
    }
}