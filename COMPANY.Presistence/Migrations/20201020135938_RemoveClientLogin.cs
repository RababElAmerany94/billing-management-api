using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class RemoveClientLogin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_ClientLoginId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_ClientLoginId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "ClientLoginId",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientLoginId",
                table: "Clients",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientLoginId",
                table: "Clients",
                column: "ClientLoginId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_ClientLoginId",
                table: "Clients",
                column: "ClientLoginId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
