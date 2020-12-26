using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class EnrolledStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnrooledStudents",
                columns: table => new
                {
                    EnrolledStudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrooledStudents", x => x.EnrolledStudentsId);
                    table.ForeignKey(
                        name: "FK_EnrooledStudents_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrooledStudents_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnrooledStudents_StudentId",
                table: "EnrooledStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrooledStudents_SubjectId",
                table: "EnrooledStudents",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnrooledStudents");
        }
    }
}
