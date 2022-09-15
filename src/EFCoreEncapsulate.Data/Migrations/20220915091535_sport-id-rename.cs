using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreEncapsulate.Api.Migrations
{
    public partial class sportidrename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseEnrollment_Course_CourseId",
                table: "CourseEnrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_SportEnrollment_Sport_SportId",
                table: "SportEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_SportEnrollment_SportId",
                table: "SportEnrollment");

            migrationBuilder.DropIndex(
                name: "IX_CourseEnrollment_CourseId",
                table: "CourseEnrollment");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Sport",
                newName: "SportID");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sport",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                name: "SportID",
                table: "Sport",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sport",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateIndex(
                name: "IX_SportEnrollment_SportId",
                table: "SportEnrollment",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_CourseId",
                table: "CourseEnrollment",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseEnrollment_Course_CourseId",
                table: "CourseEnrollment",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportEnrollment_Sport_SportId",
                table: "SportEnrollment",
                column: "SportId",
                principalTable: "Sport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
