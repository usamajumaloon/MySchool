using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.DAL.Migrations
{
    public partial class AddedForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeClassId",
                table: "Teachers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GradeClassId",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_GradeClassId",
                table: "Teachers",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_GradeClassId",
                table: "Students",
                column: "GradeClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GradeClasses_GradeClassId",
                table: "Students",
                column: "GradeClassId",
                principalTable: "GradeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_GradeClasses_GradeClassId",
                table: "Teachers",
                column: "GradeClassId",
                principalTable: "GradeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GradeClasses_GradeClassId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_GradeClasses_GradeClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_GradeClassId",
                table: "Teachers");

            migrationBuilder.DropIndex(
                name: "IX_Students_GradeClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GradeClassId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "GradeClassId",
                table: "Students");
        }
    }
}
