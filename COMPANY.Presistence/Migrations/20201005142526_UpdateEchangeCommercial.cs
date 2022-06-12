using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateEchangeCommercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_AgendaEvenementId",
                table: "EchangeCommercials");

            migrationBuilder.RenameColumn(
                name: "AgendaEvenementId",
                table: "EchangeCommercials",
                newName: "TypeAppelId");

            migrationBuilder.RenameIndex(
                name: "IX_EchangeCommercials_AgendaEvenementId",
                table: "EchangeCommercials",
                newName: "IX_EchangeCommercials_TypeAppelId");

            migrationBuilder.AddColumn<string>(
                name: "CategorieId",
                table: "EchangeCommercials",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RdvTypeId",
                table: "EchangeCommercials",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TacheTypeId",
                table: "EchangeCommercials",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_CategorieId",
                table: "EchangeCommercials",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_RdvTypeId",
                table: "EchangeCommercials",
                column: "RdvTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_TacheTypeId",
                table: "EchangeCommercials",
                column: "TacheTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_CategorieId",
                table: "EchangeCommercials",
                column: "CategorieId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_RdvTypeId",
                table: "EchangeCommercials",
                column: "RdvTypeId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_TacheTypeId",
                table: "EchangeCommercials",
                column: "TacheTypeId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_TypeAppelId",
                table: "EchangeCommercials",
                column: "TypeAppelId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_CategorieId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_RdvTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_TacheTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_TypeAppelId",
                table: "EchangeCommercials");

            migrationBuilder.DropIndex(
                name: "IX_EchangeCommercials_CategorieId",
                table: "EchangeCommercials");

            migrationBuilder.DropIndex(
                name: "IX_EchangeCommercials_RdvTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropIndex(
                name: "IX_EchangeCommercials_TacheTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "CategorieId",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "RdvTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "TacheTypeId",
                table: "EchangeCommercials");

            migrationBuilder.RenameColumn(
                name: "TypeAppelId",
                table: "EchangeCommercials",
                newName: "AgendaEvenementId");

            migrationBuilder.RenameIndex(
                name: "IX_EchangeCommercials_TypeAppelId",
                table: "EchangeCommercials",
                newName: "IX_EchangeCommercials_AgendaEvenementId");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_AgendaEvenementId",
                table: "EchangeCommercials",
                column: "AgendaEvenementId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
