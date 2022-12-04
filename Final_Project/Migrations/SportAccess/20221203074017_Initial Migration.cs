using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations.SportAccess
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SportRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    favoriteSport = table.Column<string>(nullable: true),
                    favoriteTeam = table.Column<string>(nullable: true),
                    favoritePlayer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "SportRecords",
                columns: new[] { "Id", "favoritePlayer", "favoriteSport", "favoriteTeam", "fullName" },
                values: new object[] { 1, "Virat Kohli", "Cricket", "India", "Pratik Chaudhari" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SportRecords");
        }
    }
}
