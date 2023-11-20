using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    public partial class Echipa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EchipaID",
                table: "Produs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Echipa",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EchipaNume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echipa", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produs_EchipaID",
                table: "Produs",
                column: "EchipaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produs_Echipa_EchipaID",
                table: "Produs",
                column: "EchipaID",
                principalTable: "Echipa",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produs_Echipa_EchipaID",
                table: "Produs");

            migrationBuilder.DropTable(
                name: "Echipa");

            migrationBuilder.DropIndex(
                name: "IX_Produs_EchipaID",
                table: "Produs");

            migrationBuilder.DropColumn(
                name: "EchipaID",
                table: "Produs");
        }
    }
}
