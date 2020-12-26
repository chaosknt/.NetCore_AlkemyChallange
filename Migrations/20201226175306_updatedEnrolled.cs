using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class updatedEnrolled : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    EnrolledStudentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrolledSubjectsSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.EnrolledStudentsId, x.EnrolledSubjectsSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subjects_EnrolledSubjectsSubjectId",
                        column: x => x.EnrolledSubjectsSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "SubjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Users_EnrolledStudentsId",
                        column: x => x.EnrolledStudentsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_EnrolledSubjectsSubjectId",
                table: "StudentSubject",
                column: "EnrolledSubjectsSubjectId");
        }
    }
}
