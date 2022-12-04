using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations
{
    //AutoAdded by Add-Migration command - Pratik Chaudhari
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    birthDate = table.Column<string>(nullable: true),
                    programName = table.Column<string>(nullable: true),
                    programYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "birthDate", "fullName", "programName", "programYear" },
                values: new object[] { 1, "09-02-2002", "Pratik Chaudhari", "Information Technology", "2025" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
