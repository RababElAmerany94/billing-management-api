using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addAgenceIdToFournisseur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgenceId",
                table: "Fournisseurs",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_AgenceId",
                table: "Fournisseurs",
                column: "AgenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fournisseurs_Agence_AgenceId",
                table: "Fournisseurs",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fournisseurs_Agence_AgenceId",
                table: "Fournisseurs");

            migrationBuilder.DropIndex(
                name: "IX_Fournisseurs_AgenceId",
                table: "Fournisseurs");

            migrationBuilder.DropColumn(
                name: "AgenceId",
                table: "Fournisseurs");
        }
    }
}
