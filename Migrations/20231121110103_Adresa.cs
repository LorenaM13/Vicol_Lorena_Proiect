using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    public partial class Adresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Angajat");
        }
    }
}
