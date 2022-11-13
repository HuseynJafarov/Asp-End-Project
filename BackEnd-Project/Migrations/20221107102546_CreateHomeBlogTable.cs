using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd_Project.Migrations
{
    public partial class CreateHomeBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "BlogHeaders");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "BlogHeaders");

            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Blogs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "BlogHeaders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "BlogHeaders");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "BlogHeaders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MyProperty",
                table: "BlogHeaders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
