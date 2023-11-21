using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    public partial class ListaAngajati : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Angajat",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeAngajat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Angajat", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ListaAngajati",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipaID = table.Column<int>(type: "int", nullable: false),
                    AngajatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaAngajati", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListaAngajati_Angajat_AngajatID",
                        column: x => x.AngajatID,
                        principalTable: "Angajat",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListaAngajati_Echipa_EchipaID",
                        column: x => x.EchipaID,
                        principalTable: "Echipa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListaAngajati_AngajatID",
                table: "ListaAngajati",
                column: "AngajatID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaAngajati_EchipaID",
                table: "ListaAngajati",
                column: "EchipaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListaAngajati");

            migrationBuilder.DropTable(
                name: "Angajat");
        }
    }
}
