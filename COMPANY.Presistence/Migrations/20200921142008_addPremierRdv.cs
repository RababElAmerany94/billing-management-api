using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addPremierRdv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PremierRdvId",
                table: "Dossiers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_PremierRdvId",
                table: "Dossiers",
                column: "PremierRdvId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_EchangeCommercials_PremierRdvId",
                table: "Dossiers",
                column: "PremierRdvId",
                principalTable: "EchangeCommercials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_EchangeCommercials_PremierRdvId",
                table: "Dossiers");

            migrationBuilder.DropIndex(
                name: "IX_Dossiers_PremierRdvId",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "PremierRdvId",
                table: "Dossiers");
        }
    }
}
