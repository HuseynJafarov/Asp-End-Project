using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Project.Migrations
{
    public partial class CreateInfoTableDayRow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Day",
                table: "Infos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Day",
                table: "Infos");
        }
    }
}
