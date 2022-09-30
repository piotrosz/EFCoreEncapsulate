using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreEncapsulate.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teacher",
                newName: "TeacherID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Student",
                newName: "StudentID");

            migrationBuilder.RenameColumn(
                name: "Email_Value",
                table: "Student",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SportEnrollment",
                newName: "SportEnrollmentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sport",
                newName: "SportID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CourseEnrollment",
                newName: "CourseEnrollmentID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.CreateTable(
                name: "CourseEnrollmentData",
                columns: table => new
                {
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SportEnrollmentData",
                columns: table => new
                {
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    SportName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEnrollmentData");

            migrationBuilder.DropTable(
                name: "SportEnrollmentData");

            migrationBuilder.RenameColumn(
                name: "TeacherID",
                table: "Teacher",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Student",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Student",
                newName: "Email_Value");

            migrationBuilder.RenameColumn(
                name: "SportEnrollmentID",
                table: "SportEnrollment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "SportID",
                table: "Sport",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseEnrollmentID",
                table: "CourseEnrollment",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "Id");
        }
    }
}
