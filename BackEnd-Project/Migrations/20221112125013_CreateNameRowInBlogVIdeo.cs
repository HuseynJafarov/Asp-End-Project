using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Project.Migrations
{
    public partial class CreateNameRowInBlogVIdeo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BlogVideos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BlogVideos");
        }
    }
}
