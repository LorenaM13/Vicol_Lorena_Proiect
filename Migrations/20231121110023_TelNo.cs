using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    public partial class TelNo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TelNo",
                table: "Angajat",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelNo",
                table: "Angajat");
        }
    }
}
