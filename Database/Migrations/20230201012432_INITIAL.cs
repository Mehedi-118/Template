using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class INITIAL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenericLookupType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericLookupType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenericLookup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenericLookupTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenericLookup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenericLookup_GenericLookupType_GenericLookupTypeId",
                        column: x => x.GenericLookupTypeId,
                        principalTable: "GenericLookupType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentInfoId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    GradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentInfoId",
                        column: x => x.StudentInfoId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "EEE" },
                    { 2, "CSE" },
                    { 3, "ME" },
                    { 4, "TE" },
                    { 5, "ECE" }
                });

            migrationBuilder.InsertData(
                table: "GenericLookupType",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "ResultType" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "DepartmentId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 2, "", "Algorithm" },
                    { 2, 2, "", "Data Structure" },
                    { 3, 2, "", "OOP" },
                    { 4, 1, "", "Circuit Analysis" },
                    { 5, 1, "", "Load Balancing" },
                    { 6, 1, "", "Circuit Desing" }
                });

            migrationBuilder.InsertData(
                table: "GenericLookup",
                columns: new[] { "Id", "GenericLookupTypeId", "Grade" },
                values: new object[,]
                {
                    { 1, 1, "3.25" },
                    { 2, 1, "3.50" },
                    { 3, 1, "3.75" },
                    { 4, 1, "3.86" },
                    { 5, 1, "4.00" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Code", "DepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, "I01", 2, "Iron Man" },
                    { 2, "H02", 2, "Hulk" },
                    { 3, "T03", 1, "Thor" },
                    { 4, "HM01", 1, "Hitman" },
                    { 5, "B05", 4, "Black Widow" }
                });

            migrationBuilder.InsertData(
                table: "StudentsCourses",
                columns: new[] { "Id", "CourseId", "GradeId", "StudentInfoId" },
                values: new object[,]
                {
                    { 1, 1, 5, 1 },
                    { 2, 2, 4, 1 },
                    { 3, 2, 2, 2 },
                    { 4, 3, 3, 2 },
                    { 5, 4, 2, 3 },
                    { 6, 5, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_GenericLookup_GenericLookupTypeId",
                table: "GenericLookup",
                column: "GenericLookupTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_StudentInfoId",
                table: "StudentsCourses",
                column: "StudentInfoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenericLookup");

            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "GenericLookupType");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
