using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsesLayer.Migrations
{
    public partial class mig_AddJobStatüs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Jobs",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Jobs");
        }
    }
}
