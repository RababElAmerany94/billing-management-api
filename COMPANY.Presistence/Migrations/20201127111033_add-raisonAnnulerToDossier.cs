using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addraisonAnnulerToDossier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RaisonAnnulation",
                table: "Dossiers",
                maxLength: 256,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RaisonAnnulation",
                table: "Dossiers");
        }
    }
}
