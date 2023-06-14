using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsesLayer.Migrations
{
    public partial class UpdateDb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobSeekers_JobSeekerID",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobSeekerID",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "JobSeekerID",
                table: "Jobs");

            migrationBuilder.CreateTable(
                name: "JobApplication",
                columns: table => new
                {
                    JobApplicationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobSeekerID = table.Column<int>(type: "int", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplication", x => x.JobApplicationID);
                    table.ForeignKey(
                        name: "FK_JobApplication_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobApplication_JobSeekers_JobSeekerID",
                        column: x => x.JobSeekerID,
                        principalTable: "JobSeekers",
                        principalColumn: "JobSeekerID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobID",
                table: "JobApplication",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplication_JobSeekerID",
                table: "JobApplication",
                column: "JobSeekerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplication");

            migrationBuilder.AddColumn<int>(
                name: "JobSeekerID",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobSeekerID",
                table: "Jobs",
                column: "JobSeekerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobSeekers_JobSeekerID",
                table: "Jobs",
                column: "JobSeekerID",
                principalTable: "JobSeekers",
                principalColumn: "JobSeekerID");
        }
    }
}
