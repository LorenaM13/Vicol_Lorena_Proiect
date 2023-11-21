using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vicol_Lorena_Proiect.Migrations
{
    public partial class DataAngajarii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAngajarii",
                table: "Angajat",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataAngajarii",
                table: "Angajat");
        }
    }
}
