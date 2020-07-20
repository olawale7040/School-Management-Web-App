using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolMgtWebApp.Migrations
{
    public partial class addCoureRegistrationToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseRegistered",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    Level = table.Column<string>(nullable: true),
                    Session = table.Column<string>(nullable: true),
                    DateRegistered = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseRegistered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseRegistered_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseRegistered_StudentId",
                table: "CourseRegistered",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseRegistered");
        }
    }
}
