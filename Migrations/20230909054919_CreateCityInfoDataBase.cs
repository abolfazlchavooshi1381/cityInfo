using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CityInfo.API.Migrations
{
    /// <inheritdoc />
    public partial class CreateCityInfoDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PointsOfIntrest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    cityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfIntrest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsOfIntrest_Cities_cityId",
                        column: x => x.cityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "This Is Tehran", "Tehran" },
                    { 2, "This Is Mashhad", "Mashhad" },
                    { 3, "This Is Shahroud", "Shahroud" },
                    { 4, "This Is Esfehan", "Esfehan" },
                    { 5, "This Is Tanriz", "Tanriz" }
                });

            migrationBuilder.InsertData(
                table: "PointsOfIntrest",
                columns: new[] { "Id", "Description", "Name", "cityId" },
                values: new object[,]
                {
                    { 1, "This Is Point Of Intrest 1", "Point Of Intrest 1", 1 },
                    { 2, "This Is Point Of Intrest 2", "Point Of Intrest 2", 1 },
                    { 3, "This Is Point Of Intrest 3", "Point Of Intrest 3", 2 },
                    { 4, "This Is Point Of Intrest 4", "Point Of Intrest 4", 2 },
                    { 5, "This Is Point Of Intrest 5", "Point Of Intrest 5", 3 },
                    { 6, "This Is Point Of Intrest 6", "Point Of Intrest 6", 3 },
                    { 7, "This Is Point Of Intrest 7", "Point Of Intrest 7", 4 },
                    { 8, "This Is Point Of Intrest 8", "Point Of Intrest 8", 4 },
                    { 9, "This Is Point Of Intrest 9", "Point Of Intrest 9", 5 },
                    { 10, "This Is Point Of Intrest 10", "Point Of Intrest 10", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PointsOfIntrest_cityId",
                table: "PointsOfIntrest",
                column: "cityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PointsOfIntrest");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
