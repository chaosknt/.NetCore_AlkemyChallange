using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class updateNameEnrolledStudents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrooledStudents_Subjects_SubjectId",
                table: "EnrooledStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrooledStudents_Users_StudentId",
                table: "EnrooledStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrooledStudents",
                table: "EnrooledStudents");

            migrationBuilder.RenameTable(
                name: "EnrooledStudents",
                newName: "EnrolledStudents");

            migrationBuilder.RenameIndex(
                name: "IX_EnrooledStudents_SubjectId",
                table: "EnrolledStudents",
                newName: "IX_EnrolledStudents_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_EnrooledStudents_StudentId",
                table: "EnrolledStudents",
                newName: "IX_EnrolledStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrolledStudents",
                table: "EnrolledStudents",
                column: "EnrolledStudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledStudents_Subjects_SubjectId",
                table: "EnrolledStudents",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrolledStudents_Users_StudentId",
                table: "EnrolledStudents",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledStudents_Subjects_SubjectId",
                table: "EnrolledStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_EnrolledStudents_Users_StudentId",
                table: "EnrolledStudents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrolledStudents",
                table: "EnrolledStudents");

            migrationBuilder.RenameTable(
                name: "EnrolledStudents",
                newName: "EnrooledStudents");

            migrationBuilder.RenameIndex(
                name: "IX_EnrolledStudents_SubjectId",
                table: "EnrooledStudents",
                newName: "IX_EnrooledStudents_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_EnrolledStudents_StudentId",
                table: "EnrooledStudents",
                newName: "IX_EnrooledStudents_StudentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrooledStudents",
                table: "EnrooledStudents",
                column: "EnrolledStudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnrooledStudents_Subjects_SubjectId",
                table: "EnrooledStudents",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "SubjectId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnrooledStudents_Users_StudentId",
                table: "EnrooledStudents",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
