using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddSoyurceRDVAndIsTraitant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SourceRDVId",
                table: "EchangeCommercials",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSousTraitant",
                table: "Clients",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AgendaEvenements",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms", "Type" },
                values: new object[] { "AgendaEvenement::12", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "rdv perso", null, 4 });

            migrationBuilder.InsertData(
                table: "AgendaEvenements",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms", "Type" },
                values: new object[] { "AgendaEvenement::13", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "rdv company", null, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_SourceRDVId",
                table: "EchangeCommercials",
                column: "SourceRDVId");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_SourceRDVId",
                table: "EchangeCommercials",
                column: "SourceRDVId",
                principalTable: "AgendaEvenements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_AgendaEvenements_SourceRDVId",
                table: "EchangeCommercials");

            migrationBuilder.DropIndex(
                name: "IX_EchangeCommercials_SourceRDVId",
                table: "EchangeCommercials");

            migrationBuilder.DeleteData(
                table: "AgendaEvenements",
                keyColumn: "Id",
                keyValue: "AgendaEvenement::12");

            migrationBuilder.DeleteData(
                table: "AgendaEvenements",
                keyColumn: "Id",
                keyValue: "AgendaEvenement::13");

            migrationBuilder.DropColumn(
                name: "SourceRDVId",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "IsSousTraitant",
                table: "Clients");
        }
    }
}
