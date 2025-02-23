using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AdessoDraw.Domain.Migrations
{
    /// <inheritdoc />
    public partial class TeamMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teams_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Adesso İstanbul" },
                    { 2, 1, "Adesso Ankara" },
                    { 3, 1, "Adesso İzmir" },
                    { 4, 1, "Adesso Antalya" },
                    { 5, 2, "Adesso Berlin" },
                    { 6, 2, "Adesso Frankfurt" },
                    { 7, 2, "Adesso Münih" },
                    { 8, 2, "Adesso Dortmund" },
                    { 9, 3, "Adesso Paris" },
                    { 10, 3, "Adesso Marsilya" },
                    { 11, 3, "Adesso Nice" },
                    { 12, 3, "Adesso Lyon" },
                    { 13, 4, "Adesso Amsterdam" },
                    { 14, 4, "Adesso Rotterdam" },
                    { 15, 4, "Adesso Lahey" },
                    { 16, 4, "Adesso Eindhoven" },
                    { 17, 5, "Adesso Lisbon" },
                    { 18, 5, "Adesso Porto" },
                    { 19, 5, "Adesso Braga" },
                    { 20, 5, "Adesso Coimbra" },
                    { 21, 6, "Adesso Roma" },
                    { 22, 6, "Adesso Milano" },
                    { 23, 6, "Adesso Venedik" },
                    { 24, 6, "Adesso Napoli" },
                    { 25, 7, "Adesso Sevilla" },
                    { 26, 7, "Adesso Madrid" },
                    { 27, 7, "Adesso Barselona" },
                    { 28, 7, "Adesso Granada" },
                    { 29, 8, "Adesso Brüksel" },
                    { 30, 8, "Adesso Brugge" },
                    { 31, 8, "Adesso Gent" },
                    { 32, 8, "Adesso Anvers" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CountryId",
                table: "Teams",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
