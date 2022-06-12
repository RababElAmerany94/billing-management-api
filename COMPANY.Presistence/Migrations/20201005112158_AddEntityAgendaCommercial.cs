using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddEntityAgendaCommercial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_CategorieEvenements_CategorieId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_RdvTypes_RdvTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_TacheTypes_TacheTypeId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_TypeAppel_TypeAppelId",
                table: "EchangeCommercials");

            migrationBuilder.DropTable(
                name: "CategorieEvenements");

            migrationBuilder.DropTable(
                name: "RdvTypes");

            migrationBuilder.DropTable(
                name: "TacheTypes");

            migrationBuilder.DropTable(
                name: "TypeAppel");

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

            migrationBuilder.AddColumn<string>(
                name: "AgenceId",
                table: "SpecialArticles",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgendaEvenements",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgendaEvenements", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AgendaEvenements",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms", "Type" },
                values: new object[,]
                {
                    { "AgendaEvenement::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Prospection", null, 0 },
                    { "AgendaEvenement::2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Vérification", null, 0 },
                    { "AgendaEvenement::3", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Planification", null, 0 },
                    { "AgendaEvenement::4", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Tâche", null, 0 },
                    { "AgendaEvenement::5", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Visite de contrôle", null, 1 },
                    { "AgendaEvenement::6", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Pose", null, 1 },
                    { "AgendaEvenement::7", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Visite technique", null, 1 },
                    { "AgendaEvenement::8", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Commercial", null, 3 },
                    { "AgendaEvenement::9", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Administratif", null, 3 },
                    { "AgendaEvenement::10", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Technique", null, 3 },
                    { "AgendaEvenement::11", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Appel", null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecialArticles_AgenceId",
                table: "SpecialArticles",
                column: "AgenceId");

            migrationBuilder.CreateIndex(
                name: "IX_AgendaEvenements_SearchTerms",
                table: "AgendaEvenements",
                column: "SearchTerms");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_AgendaEvenementId",
                table: "EchangeCommercials",
                column: "AgendaEvenementId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialArticles_Agence_AgenceId",
                table: "SpecialArticles",
                column: "AgenceId",
                principalTable: "Agence",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_AgendaEvenementId",
                table: "EchangeCommercials");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialArticles_Agence_AgenceId",
                table: "SpecialArticles");

            migrationBuilder.DropTable(
                name: "AgendaEvenements");

            migrationBuilder.DropIndex(
                name: "IX_SpecialArticles_AgenceId",
                table: "SpecialArticles");

            migrationBuilder.DropColumn(
                name: "AgenceId",
                table: "SpecialArticles");

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

            migrationBuilder.CreateTable(
                name: "CategorieEvenements",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieEvenements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdvTypes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdvTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TacheTypes",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TacheTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeAppel",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeAppel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TacheTypes",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "TacheType::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Tâche", null });

            migrationBuilder.InsertData(
                table: "TypeAppel",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "AppelType::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Appel", null });

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

            migrationBuilder.CreateIndex(
                name: "IX_CategorieEvenements_SearchTerms",
                table: "CategorieEvenements",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_RdvTypes_SearchTerms",
                table: "RdvTypes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_TacheTypes_SearchTerms",
                table: "TacheTypes",
                column: "SearchTerms");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAppel_SearchTerms",
                table: "TypeAppel",
                column: "SearchTerms");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_CategorieEvenements_CategorieId",
                table: "EchangeCommercials",
                column: "CategorieId",
                principalTable: "CategorieEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_RdvTypes_RdvTypeId",
                table: "EchangeCommercials",
                column: "RdvTypeId",
                principalTable: "RdvTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_TacheTypes_TacheTypeId",
                table: "EchangeCommercials",
                column: "TacheTypeId",
                principalTable: "TacheTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_TypeAppel_TypeAppelId",
                table: "EchangeCommercials",
                column: "TypeAppelId",
                principalTable: "TypeAppel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
