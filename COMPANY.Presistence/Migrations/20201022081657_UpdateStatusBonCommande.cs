using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateStatusBonCommande : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonsCommandes_BonsCommandes_StatusId",
                table: "BonsCommandes");

            migrationBuilder.DropIndex(
                name: "IX_BonsCommandes_StatusId",
                table: "BonsCommandes");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "BonsCommandes");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "BonsCommandes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "BonsCommandes");

            migrationBuilder.AddColumn<string>(
                name: "StatusId",
                table: "BonsCommandes",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_StatusId",
                table: "BonsCommandes",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonsCommandes_BonsCommandes_StatusId",
                table: "BonsCommandes",
                column: "StatusId",
                principalTable: "BonsCommandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
