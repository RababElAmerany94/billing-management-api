using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateClientCommercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Users_CommercialId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_CommercialId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CommercialId",
                table: "Clients");

            migrationBuilder.CreateTable(
                name: "ClientCommercial",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CommercialId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCommercial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientCommercial_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientCommercial_Users_CommercialId",
                        column: x => x.CommercialId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientCommercial_ClientId",
                table: "ClientCommercial",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCommercial_CommercialId",
                table: "ClientCommercial",
                column: "CommercialId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientCommercial_SearchTerms",
                table: "ClientCommercial",
                column: "SearchTerms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientCommercial");

            migrationBuilder.AddColumn<string>(
                name: "CommercialId",
                table: "Clients",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CommercialId",
                table: "Clients",
                column: "CommercialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Users_CommercialId",
                table: "Clients",
                column: "CommercialId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
