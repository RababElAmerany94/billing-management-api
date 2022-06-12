using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class fixDeletePremierRdv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_EchangeCommercials_PremierRdvId",
                table: "Dossiers");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_EchangeCommercials_PremierRdvId",
                table: "Dossiers",
                column: "PremierRdvId",
                principalTable: "EchangeCommercials",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_EchangeCommercials_PremierRdvId",
                table: "Dossiers");

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_EchangeCommercials_PremierRdvId",
                table: "Dossiers",
                column: "PremierRdvId",
                principalTable: "EchangeCommercials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
