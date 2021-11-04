using Microsoft.EntityFrameworkCore.Migrations;

namespace DbMigrations.Migrations
{
    public partial class TrueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name1",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name2",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name3",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name4",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name1",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name2",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name3",
                table: "Students",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name4",
                table: "Students",
                type: "text",
                nullable: true);
        }
    }
}
