using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreEncapsulate.Api.Migrations
{
    public partial class sportenrolmentsanddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.CreateTable(
                name: "CourseEnrollment",
                columns: table => new
                {
                    CourseEnrollmentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollment", x => x.CourseEnrollmentID);
                    table.ForeignKey(
                        name: "FK_CourseEnrollment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SportEnrollment",
                columns: table => new
                {
                    SportEnrollmentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    SportId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportEnrollment", x => x.SportEnrollmentID);
                    table.ForeignKey(
                        name: "FK_SportEnrollment_Sport_SportId",
                        column: x => x.SportId,
                        principalTable: "Sport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SportEnrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "CourseID", "Name" },
                values: new object[,]
                {
                    { 1L, "Physics" },
                    { 2L, "Mathematics" }
                });

            migrationBuilder.InsertData(
                table: "Sport",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Swimming" },
                    { 2L, "Basketball" }
                });

            migrationBuilder.InsertData(
                table: "CourseEnrollment",
                columns: new[] { "CourseEnrollmentID", "CourseId", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1L, 1L, 2, 1L },
                    { 2L, 2L, 1, 2L },
                    { 3L, 1L, 1, 2L }
                });

            migrationBuilder.InsertData(
                table: "SportEnrollment",
                columns: new[] { "SportEnrollmentID", "Grade", "SportId", "StudentId" },
                values: new object[,]
                {
                    { 1L, 3, 1L, 2L },
                    { 2L, 4, 2L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_CourseId",
                table: "CourseEnrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollment_StudentId",
                table: "CourseEnrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEnrollment_SportId",
                table: "SportEnrollment",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_SportEnrollment_StudentId",
                table: "SportEnrollment",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseEnrollment");

            migrationBuilder.DropTable(
                name: "SportEnrollment");

            migrationBuilder.DropTable(
                name: "Sport");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "CourseID",
                keyValue: 2L);

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    EnrollmentID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<long>(type: "bigint", nullable: false),
                    StudentId = table.Column<long>(type: "bigint", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.EnrollmentID);
                    table.ForeignKey(
                        name: "FK_Enrollment_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollment_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_CourseId",
                table: "Enrollment",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");
        }
    }
}
