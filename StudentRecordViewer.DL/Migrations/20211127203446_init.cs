using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentRecordViewer.DL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentCredits",
                columns: table => new
                {
                    StudentCreditsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year1Credits = table.Column<int>(type: "int", nullable: false),
                    Year2Credits = table.Column<int>(type: "int", nullable: false),
                    Year3Credits = table.Column<int>(type: "int", nullable: false),
                    Year4Credits = table.Column<int>(type: "int", nullable: false),
                    Year5Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCredits", x => x.StudentCreditsId);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudentCreditsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Student_StudentCredits_StudentCreditsId",
                        column: x => x.StudentCreditsId,
                        principalTable: "StudentCredits",
                        principalColumn: "StudentCreditsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentCreditsId",
                table: "Student",
                column: "StudentCreditsId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "StudentCredits");
        }
    }
}
