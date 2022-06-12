using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addDatesInDossier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreation",
                table: "Dossiers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateExpiration",
                table: "Dossiers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreation",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "DateExpiration",
                table: "Dossiers");
        }
    }
}
