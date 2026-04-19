using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Larare",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Namn = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Larare", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kurser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kursnamn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Poang = table.Column<int>(type: "int", nullable: false),
                    LarareId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurser_Larare_LarareId",
                        column: x => x.LarareId,
                        principalTable: "Larare",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurser_LarareId",
                table: "Kurser",
                column: "LarareId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kurser");

            migrationBuilder.DropTable(
                name: "Larare");
        }
    }
}
