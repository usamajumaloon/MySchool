using Microsoft.EntityFrameworkCore.Migrations;

namespace MySchool.DAL.Migrations
{
    public partial class AddNullableStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GradeClasses_GradeClassId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "GradeClassId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GradeClasses_GradeClassId",
                table: "Students",
                column: "GradeClassId",
                principalTable: "GradeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_GradeClasses_GradeClassId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "GradeClassId",
                table: "Students",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_GradeClasses_GradeClassId",
                table: "Students",
                column: "GradeClassId",
                principalTable: "GradeClasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
