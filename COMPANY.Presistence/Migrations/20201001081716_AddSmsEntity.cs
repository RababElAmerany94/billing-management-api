using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddSmsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sms",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    NumeroTelephone = table.Column<string>(maxLength: 256, nullable: true),
                    Message = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    IsBloquer = table.Column<bool>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    SmsEnvoyeId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    DossierId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sms_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sms_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sms_Sms_SmsEnvoyeId",
                        column: x => x.SmsEnvoyeId,
                        principalTable: "Sms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sms_ClientId",
                table: "Sms",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sms_DossierId",
                table: "Sms",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_Sms_SearchTerms",
                table: "Sms",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_Sms_SmsEnvoyeId",
                table: "Sms",
                column: "SmsEnvoyeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sms");
        }
    }
}
