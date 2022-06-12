using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class FixClientCommercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCommercial_Clients_ClientId",
                table: "ClientCommercial");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCommercial_Users_CommercialId",
                table: "ClientCommercial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCommercial",
                table: "ClientCommercial");

            migrationBuilder.RenameTable(
                name: "ClientCommercial",
                newName: "ClientCommercials");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCommercial_SearchTerms",
                table: "ClientCommercials",
                newName: "IX_ClientCommercials_SearchTerms");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCommercial_CommercialId",
                table: "ClientCommercials",
                newName: "IX_ClientCommercials_CommercialId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCommercial_ClientId",
                table: "ClientCommercials",
                newName: "IX_ClientCommercials_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "CommercialId",
                table: "ClientCommercials",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCommercials",
                table: "ClientCommercials",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCommercials_Clients_ClientId",
                table: "ClientCommercials",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCommercials_Users_CommercialId",
                table: "ClientCommercials",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientCommercials_Clients_ClientId",
                table: "ClientCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientCommercials_Users_CommercialId",
                table: "ClientCommercials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientCommercials",
                table: "ClientCommercials");

            migrationBuilder.RenameTable(
                name: "ClientCommercials",
                newName: "ClientCommercial");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCommercials_SearchTerms",
                table: "ClientCommercial",
                newName: "IX_ClientCommercial_SearchTerms");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCommercials_CommercialId",
                table: "ClientCommercial",
                newName: "IX_ClientCommercial_CommercialId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientCommercials_ClientId",
                table: "ClientCommercial",
                newName: "IX_ClientCommercial_ClientId");

            migrationBuilder.AlterColumn<string>(
                name: "CommercialId",
                table: "ClientCommercial",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 256);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientCommercial",
                table: "ClientCommercial",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCommercial_Clients_ClientId",
                table: "ClientCommercial",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientCommercial_Users_CommercialId",
                table: "ClientCommercial",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
