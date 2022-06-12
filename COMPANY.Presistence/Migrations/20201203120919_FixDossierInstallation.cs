using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class FixDossierInstallation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierInstallations_Dossiers_DossierId",
                table: "DossierInstallations");

            migrationBuilder.DropForeignKey(
                name: "FK_DossierInstallations_Users_TechnicienId",
                table: "DossierInstallations");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicienId",
                table: "DossierInstallations",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DossierId",
                table: "DossierInstallations",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierInstallations_Dossiers_DossierId",
                table: "DossierInstallations",
                column: "DossierId",
                principalTable: "Dossiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierInstallations_Users_TechnicienId",
                table: "DossierInstallations",
                column: "TechnicienId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DossierInstallations_Dossiers_DossierId",
                table: "DossierInstallations");

            migrationBuilder.DropForeignKey(
                name: "FK_DossierInstallations_Users_TechnicienId",
                table: "DossierInstallations");

            migrationBuilder.AlterColumn<string>(
                name: "TechnicienId",
                table: "DossierInstallations",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "DossierId",
                table: "DossierInstallations",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierInstallations_Dossiers_DossierId",
                table: "DossierInstallations",
                column: "DossierId",
                principalTable: "Dossiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DossierInstallations_Users_TechnicienId",
                table: "DossierInstallations",
                column: "TechnicienId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
