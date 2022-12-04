using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations.HobbyAccess
{
    //AutoAdded by Add-Migration command - Pratik Chaudhari
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HobbyRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    hobby = table.Column<string>(nullable: true),
                    favoriteVideoGame = table.Column<string>(nullable: true),
                    favoriteBoardGame = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HobbyRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HobbyRecords",
                columns: new[] { "Id", "favoriteBoardGame", "favoriteVideoGame", "fullName", "hobby" },
                values: new object[] { 1, "Chess", "Call of Duty", "Pratik Chaudhari", "Swimming" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HobbyRecords");
        }
    }
}
