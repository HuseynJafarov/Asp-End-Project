using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Project.Migrations
{
    public partial class RemoveCurencyImageProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Currencies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
