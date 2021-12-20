using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class AddJobDateToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Job",
                table: "OurTeams",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Date",
                table: "Blogs",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Job",
                table: "OurTeams");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Blogs");
        }
    }
}
