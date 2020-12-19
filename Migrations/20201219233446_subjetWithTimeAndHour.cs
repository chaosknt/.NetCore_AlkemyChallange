using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class subjetWithTimeAndHour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Schedule",
                table: "Subjects",
                newName: "Hour");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOfTheWeek",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Subjects",
                newName: "Schedule");
        }
    }
}
