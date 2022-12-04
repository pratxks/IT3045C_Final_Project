using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Project.Migrations.FoodAccess
{
    //AutoAdded by Add-Migration command - Pratik Chaudhari
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FoodRecords",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    favoriteBreakfast = table.Column<string>(nullable: true),
                    favoriteLunch = table.Column<string>(nullable: true),
                    favoriteDinner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodRecords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FoodRecords",
                columns: new[] { "Id", "favoriteBreakfast", "favoriteDinner", "favoriteLunch", "fullName" },
                values: new object[] { 1, "Sandwitch", "Burger", "Pizza", "Pratik Chaudhari" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodRecords");
        }
    }
}
