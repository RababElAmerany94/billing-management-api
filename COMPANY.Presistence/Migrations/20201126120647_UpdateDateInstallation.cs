using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateDateInstallation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateInstallation",
                table: "DossierInstallations",
                newName: "DateDebutTravaux");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateDebutTravaux",
                table: "DossierInstallations",
                newName: "DateInstallation");
        }
    }
}
