using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddSiteInstallationInformationsSuplementaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SiteInstallationInformationsSupplementaire",
                table: "Dossiers",
                type: "LONGTEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SiteInstallationInformationsSupplementaire",
                table: "Dossiers");
        }
    }
}
