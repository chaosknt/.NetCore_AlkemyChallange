using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class students : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Subjects_SubjectId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_SubjectId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Users");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.AddColumn<Guid>(
                name: "SubjectId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubjectId",
                table: "Users",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Subjects_SubjectId",
                table: "Users",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
