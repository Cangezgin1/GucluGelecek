using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsesLayer.Migrations
{
    public partial class mig_AddJobSeekerTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "JobSeekers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "JobSeekers");
        }
    }
}
