using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplicationWebAPIDemo.Migrations
{
    public partial class AddStudentToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblStudents",
                columns: table => new
                {
                    StdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StdName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    StdAge = table.Column<int>(type: "int", nullable: false),
                    StdEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStudents", x => x.StdId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblStudents");
        }
    }
}
