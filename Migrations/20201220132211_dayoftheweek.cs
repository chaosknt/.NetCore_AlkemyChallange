using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkemyChallange.Migrations
{
    public partial class dayoftheweek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfTheWeek",
                table: "Subjects");

            migrationBuilder.AddColumn<Guid>(
                name: "DayOfTheWeekId",
                table: "Subjects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DayOfTheWeek",
                columns: table => new
                {
                    DayOfTheWeekId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfTheWeek", x => x.DayOfTheWeekId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_DayOfTheWeekId",
                table: "Subjects",
                column: "DayOfTheWeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subjects_DayOfTheWeek_DayOfTheWeekId",
                table: "Subjects",
                column: "DayOfTheWeekId",
                principalTable: "DayOfTheWeek",
                principalColumn: "DayOfTheWeekId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subjects_DayOfTheWeek_DayOfTheWeekId",
                table: "Subjects");

            migrationBuilder.DropTable(
                name: "DayOfTheWeek");

            migrationBuilder.DropIndex(
                name: "IX_Subjects_DayOfTheWeekId",
                table: "Subjects");

            migrationBuilder.DropColumn(
                name: "DayOfTheWeekId",
                table: "Subjects");

            migrationBuilder.AddColumn<DateTime>(
                name: "DayOfTheWeek",
                table: "Subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
