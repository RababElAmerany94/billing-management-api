using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addEchangeCommercialCreateur : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreateurId",
                table: "EchangeCommercials",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_CreateurId",
                table: "EchangeCommercials",
                column: "CreateurId");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_Users_CreateurId",
                table: "EchangeCommercials",
                column: "CreateurId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_Users_CreateurId",
                table: "EchangeCommercials");

            migrationBuilder.DropIndex(
                name: "IX_EchangeCommercials_CreateurId",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "CreateurId",
                table: "EchangeCommercials");
        }
    }
}
