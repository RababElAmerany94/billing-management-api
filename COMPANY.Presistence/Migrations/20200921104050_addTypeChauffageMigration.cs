using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class addTypeChauffageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Dossiers",
                newName: "TypeChauffageId");

            migrationBuilder.AlterColumn<string>(
                name: "SourceLead",
                table: "Dossiers",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "FirstPhoneNumber",
                table: "Dossiers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondPhoneNumber",
                table: "Dossiers",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SourceLead",
                table: "Clients",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "TypeChauffageId",
                table: "Clients",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeChauffage",
                columns: table => new
                {
                    CreatedOn = table.Column<DateTimeOffset>(nullable: false),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    SearchTerms = table.Column<string>(maxLength: 750, nullable: true),
                    Id = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeChauffage", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dossiers_TypeChauffageId",
                table: "Dossiers",
                column: "TypeChauffageId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TypeChauffageId",
                table: "Clients",
                column: "TypeChauffageId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeChauffage_SearchTerms",
                table: "TypeChauffage",
                column: "SearchTerms");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_TypeChauffage_TypeChauffageId",
                table: "Clients",
                column: "TypeChauffageId",
                principalTable: "TypeChauffage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dossiers_TypeChauffage_TypeChauffageId",
                table: "Dossiers",
                column: "TypeChauffageId",
                principalTable: "TypeChauffage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_TypeChauffage_TypeChauffageId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Dossiers_TypeChauffage_TypeChauffageId",
                table: "Dossiers");

            migrationBuilder.DropTable(
                name: "TypeChauffage");

            migrationBuilder.DropIndex(
                name: "IX_Dossiers_TypeChauffageId",
                table: "Dossiers");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TypeChauffageId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "FirstPhoneNumber",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "SecondPhoneNumber",
                table: "Dossiers");

            migrationBuilder.DropColumn(
                name: "TypeChauffageId",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "TypeChauffageId",
                table: "Dossiers",
                newName: "PhoneNumber");

            migrationBuilder.AlterColumn<int>(
                name: "SourceLead",
                table: "Dossiers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SourceLead",
                table: "Clients",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 256,
                oldNullable: true);
        }
    }
}
