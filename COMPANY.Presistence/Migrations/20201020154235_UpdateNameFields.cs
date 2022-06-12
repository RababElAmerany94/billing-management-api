using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateNameFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Article",
                table: "DossierPVs");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AdresseFacturation",
                table: "Agence");

            migrationBuilder.DropColumn(
                name: "AdresseLivraison",
                table: "Agence");

            migrationBuilder.DropColumn(
                name: "Memo",
                table: "Agence");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Produits",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "LONGTEXT",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addresses",
                table: "Fournisseurs",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "Fournisseurs",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addresses",
                table: "EchangeCommercials",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Dossiers",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memos",
                table: "Dossiers",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Articles",
                table: "DossierPVs",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Addresses",
                table: "Clients",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memos",
                table: "Clients",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SearchTerms",
                table: "CategoryDocuments",
                maxLength: 750,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryDocuments",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "CategoryDocuments",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CategoryDocuments",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "AdressesFacturation",
                table: "Agence",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdressesLivraison",
                table: "Agence",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memos",
                table: "Agence",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryDocuments_SearchTerms",
                table: "CategoryDocuments",
                column: "SearchTerms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryDocuments_SearchTerms",
                table: "CategoryDocuments");

            migrationBuilder.DropColumn(
                name: "Addresses",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Contacts",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "Addresses",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Memos",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "Articles",
                table: "DossierPVs");

            migrationBuilder.DropColumn(
                name: "Addresses",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Memos",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AdressesFacturation",
                table: "Agence");

            migrationBuilder.DropColumn(
                name: "AdressesLivraison",
                table: "Agence");

            migrationBuilder.DropColumn(
                name: "Memos",
                table: "Agence");

            migrationBuilder.AlterColumn<string>(
                name: "Designation",
                table: "Produits",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Fournisseurs",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contact",
                table: "Fournisseurs",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "EchangeCommercials",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contacts",
                table: "Dossiers",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "Dossiers",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Article",
                table: "DossierPVs",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Clients",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "Clients",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SearchTerms",
                table: "CategoryDocuments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 750,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CategoryDocuments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "CategoryDocuments",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "CategoryDocuments",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "AdresseFacturation",
                table: "Agence",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresseLivraison",
                table: "Agence",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Memo",
                table: "Agence",
                type: "LONGTEXT",
                maxLength: 256,
                nullable: true);
        }
    }
}
