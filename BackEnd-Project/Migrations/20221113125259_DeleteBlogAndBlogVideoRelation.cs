using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Project.Migrations
{
    public partial class DeleteBlogAndBlogVideoRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogVideos_Blogs_BlogId",
                table: "BlogVideos");

            migrationBuilder.DropIndex(
                name: "IX_BlogVideos_BlogId",
                table: "BlogVideos");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogVideos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogVideos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BlogVideos_BlogId",
                table: "BlogVideos",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogVideos_Blogs_BlogId",
                table: "BlogVideos",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
