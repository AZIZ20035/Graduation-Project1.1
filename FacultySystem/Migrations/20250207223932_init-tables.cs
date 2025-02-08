using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacultySystem.Migrations
{
    /// <inheritdoc />
    public partial class inittables : Migration
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
                name: "Staffs",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staffs", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Department = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => new { x.Department, x.Level });
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Email);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StaffEmail = table.Column<int>(type: "int", nullable: false),
                    StaffEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Staffs_StaffEmail1",
                        column: x => x.StaffEmail1,
                        principalTable: "Staffs",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<byte>(type: "tinyint", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    StaffEmail = table.Column<int>(type: "int", nullable: false),
                    StaffEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectDepartment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectLevel = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Staffs_StaffEmail1",
                        column: x => x.StaffEmail1,
                        principalTable: "Staffs",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Exams_Subject_SubjectDepartment_SubjectLevel",
                        columns: x => new { x.SubjectDepartment, x.SubjectLevel },
                        principalTable: "Subject",
                        principalColumns: new[] { "Department", "Level" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    StaffEmail = table.Column<int>(type: "int", nullable: false),
                    SubjectDepartment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectLevel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => new { x.StaffEmail, x.SubjectDepartment, x.SubjectLevel });
                    table.ForeignKey(
                        name: "FK_Material_Staffs_StaffEmail1",
                        column: x => x.StaffEmail1,
                        principalTable: "Staffs",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Material_Subject_SubjectDepartment_SubjectLevel",
                        columns: x => new { x.SubjectDepartment, x.SubjectLevel },
                        principalTable: "Subject",
                        principalColumns: new[] { "Department", "Level" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    StaffEmail = table.Column<int>(type: "int", nullable: false),
                    SubjectDepartment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectLevel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StaffEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => new { x.StaffEmail, x.SubjectDepartment, x.SubjectLevel });
                    table.ForeignKey(
                        name: "FK_Post_Staffs_StaffEmail1",
                        column: x => x.StaffEmail1,
                        principalTable: "Staffs",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Post_Subject_SubjectDepartment_SubjectLevel",
                        columns: x => new { x.SubjectDepartment, x.SubjectLevel },
                        principalTable: "Subject",
                        principalColumns: new[] { "Department", "Level" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Registeration",
                columns: table => new
                {
                    StaffEmail = table.Column<int>(type: "int", nullable: false),
                    SubjectDepartment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubjectLevel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StaffEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registeration", x => new { x.StaffEmail, x.SubjectDepartment, x.SubjectLevel });
                    table.ForeignKey(
                        name: "FK_Registeration_Staffs_StaffEmail1",
                        column: x => x.StaffEmail1,
                        principalTable: "Staffs",
                        principalColumn: "Email");
                    table.ForeignKey(
                        name: "FK_Registeration_Subject_SubjectDepartment_SubjectLevel",
                        columns: x => new { x.SubjectDepartment, x.SubjectLevel },
                        principalTable: "Subject",
                        principalColumns: new[] { "Department", "Level" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<byte>(type: "tinyint", nullable: false),
                    CorrectAns = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    ExamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Question_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    PostStaffEmail = table.Column<int>(type: "int", nullable: false),
                    PostSubjectDepartment = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PostSubjectLevel = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CommenterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => new { x.PostStaffEmail, x.PostSubjectDepartment, x.PostSubjectLevel, x.Content });
                    table.ForeignKey(
                        name: "FK_Comment_Post_PostStaffEmail_PostSubjectDepartment_PostSubjectLevel",
                        columns: x => new { x.PostStaffEmail, x.PostSubjectDepartment, x.PostSubjectLevel },
                        principalTable: "Post",
                        principalColumns: new[] { "StaffEmail", "SubjectDepartment", "SubjectLevel" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AssignmentAns",
                columns: table => new
                {
                    StudentEmail = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    StudentEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentAns", x => new { x.QuestionId, x.StudentEmail });
                    table.ForeignKey(
                        name: "FK_AssignmentAns_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssignmentAns_Students_StudentEmail1",
                        column: x => x.StudentEmail1,
                        principalTable: "Students",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateTable(
                name: "Choice",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    choice = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choice", x => new { x.QuestionId, x.choice });
                    table.ForeignKey(
                        name: "FK_Choice_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QuestionAns",
                columns: table => new
                {
                    StudentEmail = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    StudentEmail1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    StudentAns = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAns", x => new { x.QuestionId, x.StudentEmail });
                    table.ForeignKey(
                        name: "FK_QuestionAns_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAns_Students_StudentEmail1",
                        column: x => x.StudentEmail1,
                        principalTable: "Students",
                        principalColumn: "Email");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentAns_StudentEmail1",
                table: "AssignmentAns",
                column: "StudentEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_StaffEmail1",
                table: "Exams",
                column: "StaffEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_SubjectDepartment_SubjectLevel",
                table: "Exams",
                columns: new[] { "SubjectDepartment", "SubjectLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_Material_StaffEmail1",
                table: "Material",
                column: "StaffEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Material_SubjectDepartment_SubjectLevel",
                table: "Material",
                columns: new[] { "SubjectDepartment", "SubjectLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_News_StaffEmail1",
                table: "News",
                column: "StaffEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Post_StaffEmail1",
                table: "Post",
                column: "StaffEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Post_SubjectDepartment_SubjectLevel",
                table: "Post",
                columns: new[] { "SubjectDepartment", "SubjectLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_Question_ExamId",
                table: "Question",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAns_StudentEmail1",
                table: "QuestionAns",
                column: "StudentEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Registeration_StaffEmail1",
                table: "Registeration",
                column: "StaffEmail1");

            migrationBuilder.CreateIndex(
                name: "IX_Registeration_SubjectDepartment_SubjectLevel",
                table: "Registeration",
                columns: new[] { "SubjectDepartment", "SubjectLevel" });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentId",
                table: "Students",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssignmentAns");

            migrationBuilder.DropTable(
                name: "Choice");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "QuestionAns");

            migrationBuilder.DropTable(
                name: "Registeration");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Staffs");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
