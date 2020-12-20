using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class updateSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_DayOfTheWeek_DayOfTheWeekId",
                table: "Subjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "DayOfTheWeekId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_DayOfTheWeek_DayOfTheWeekId",
                table: "Subjects",
                column: "DayOfTheWeekId",
                principalTable: "DayOfTheWeek",
                principalColumn: "DayOfTheWeekId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_DayOfTheWeek_DayOfTheWeekId",
                table: "Subjects");

            migrationBuilder.AlterColumn<Guid>(
                name: "DayOfTheWeekId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_DayOfTheWeek_DayOfTheWeekId",
                table: "Subjects",
                column: "DayOfTheWeekId",
                principalTable: "DayOfTheWeek",
                principalColumn: "DayOfTheWeekId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
