using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addRemiseToDevisAndBonDeCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Remise",
                table: "Devis",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RemiseType",
                table: "Devis",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Remise",
                table: "BonsCommandes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "RemiseType",
                table: "BonsCommandes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remise",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "RemiseType",
                table: "Devis");

            migrationBuilder.DropColumn(
                name: "Remise",
                table: "BonsCommandes");

            migrationBuilder.DropColumn(
                name: "RemiseType",
                table: "BonsCommandes");
        }
    }
}
