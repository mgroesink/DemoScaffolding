using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoScaffolding.Data.Migrations
{
    /// <inheritdoc />
    public partial class EigenarenToegevoegd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eigenaren",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Postcode = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true),
                    Plaats = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eigenaren", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AutoEigenaar",
                columns: table => new
                {
                    AutosID = table.Column<int>(type: "int", nullable: false),
                    EigenarenID = table.Column<int>(type: "int", nullable: false),
                    From = table.Column<DateTime>(type: "date", nullable: false),
                    To = table.Column<DateTime>(type: "date", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoEigenaar", x => new { x.AutosID, x.EigenarenID });
                    table.ForeignKey(
                        name: "FK_AutoEigenaar_Autos_AutosID",
                        column: x => x.AutosID,
                        principalTable: "Autos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoEigenaar_Eigenaren_EigenarenID",
                        column: x => x.EigenarenID,
                        principalTable: "Eigenaren",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoEigenaar_EigenarenID",
                table: "AutoEigenaar",
                column: "EigenarenID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoEigenaar");

            migrationBuilder.DropTable(
                name: "Eigenaren");
        }
    }
}
