using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class updateSourceLeadInDossierAndClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SourceLead",
                table: "Dossiers",
                newName: "SourceLeadId");

            migrationBuilder.RenameColumn(
                name: "SourceLead",
                table: "Clients",
                newName: "SourceLeadId");

            migrationBuilder.AlterColumn<string>(
                name: "SearchTerms",
                table: "SourceDuLead",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SourceDuLead",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "SourceDuLead",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_SourceDuLead_SearchTerms",
                table: "SourceDuLead",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_SourceLeadId",
                table: "Dossiers",
                column: "SourceLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_SourceLeadId",
                table: "Clients",
                column: "SourceLeadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_SourceDuLead_SourceLeadId",
                table: "Clients",
                column: "SourceLeadId",
                principalTable: "SourceDuLead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_SourceDuLead_SourceLeadId",
                table: "Dossiers",
                column: "SourceLeadId",
                principalTable: "SourceDuLead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_SourceDuLead_SourceLeadId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_SourceDuLead_SourceLeadId",
                table: "Dossiers");

            migrationBuilder.DropIndex(
                name: "IX_SourceDuLead_SearchTerms",
                table: "SourceDuLead");

            migrationBuilder.DropIndex(
                name: "IX_Dossiers_SourceLeadId",
                table: "Dossiers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_SourceLeadId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "SourceLeadId",
                table: "Dossiers",
                newName: "SourceLead");

            migrationBuilder.RenameColumn(
                name: "SourceLeadId",
                table: "Clients",
                newName: "SourceLead");

            migrationBuilder.AlterColumn<string>(
                name: "SearchTerms",
                table: "SourceDuLead",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SourceDuLead",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "SourceDuLead",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);
        }
    }
}
