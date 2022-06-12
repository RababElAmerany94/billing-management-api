using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateDossierEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "DossierInstallations");

            migrationBuilder.AddColumn<string>(
                name: "AntsrouteOrderId",
                table: "Dossiers",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntsrouteOrderId",
                table: "Dossiers");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "DossierInstallations",
                nullable: false,
                defaultValue: 0);
        }
    }
}
