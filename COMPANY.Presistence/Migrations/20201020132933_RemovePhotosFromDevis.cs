using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class RemovePhotosFromDevis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photos",
                table: "Devis");

            migrationBuilder.AlterColumn<string>(
                name: "SiteIntervention",
                table: "Dossiers",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contacts",
                table: "Dossiers",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SiteIntervention",
                table: "Dossiers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contacts",
                table: "Dossiers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photos",
                table: "Devis",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);
        }
    }
}
