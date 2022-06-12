using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddBonCommandeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BonsCommandes",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Reference = table.Column<string>(maxLength: 256, nullable: true),
                    SiteIntervention = table.Column<string>(type: "LONGTEXT", nullable: true),
                    DateVisit = table.Column<DateTime>(nullable: false),
                    Articles = table.Column<string>(type: "LONGTEXT", nullable: true),
                    StatusId = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false),
                    TotalHT = table.Column<decimal>(nullable: false),
                    TotalTTC = table.Column<decimal>(nullable: false),
                    TotalReduction = table.Column<decimal>(nullable: false),
                    TotalPaid = table.Column<decimal>(nullable: false),
                    RaisonAnnulation = table.Column<string>(maxLength: 256, nullable: true),
                    DateSignature = table.Column<DateTime>(nullable: true),
                    Signe = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    NameClientSignature = table.Column<string>(maxLength: 256, nullable: true),
                    Note = table.Column<string>(type: "LONGTEXT", maxLength: 256, nullable: true),
                    Historique = table.Column<string>(type: "LONGTEXT", nullable: true),
                    Emails = table.Column<string>(type: "LONGTEXT", nullable: true),
                    UserId = table.Column<string>(maxLength: 256, nullable: true),
                    ClientId = table.Column<string>(maxLength: 256, nullable: true),
                    DossierId = table.Column<string>(maxLength: 256, nullable: true),
                    DevisId = table.Column<string>(maxLength: 256, nullable: true),
                    AgenceId = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BonsCommandes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BonsCommandes_Agence_AgenceId",
                        column: x => x.AgenceId,
                        principalTable: "Agence",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonsCommandes_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonsCommandes_Devis_DevisId",
                        column: x => x.DevisId,
                        principalTable: "Devis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonsCommandes_Dossiers_DossierId",
                        column: x => x.DossierId,
                        principalTable: "Dossiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BonsCommandes_BonsCommandes_StatusId",
                        column: x => x.StatusId,
                        principalTable: "BonsCommandes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BonsCommandes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_AgenceId",
                table: "BonsCommandes",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_ClientId",
                table: "BonsCommandes",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_DevisId",
                table: "BonsCommandes",
                column: "DevisId");

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_DossierId",
                table: "BonsCommandes",
                column: "DossierId");

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_SearchTerms",
                table: "BonsCommandes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_StatusId",
                table: "BonsCommandes",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BonsCommandes_UserId",
                table: "BonsCommandes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BonsCommandes");
        }
    }
}
