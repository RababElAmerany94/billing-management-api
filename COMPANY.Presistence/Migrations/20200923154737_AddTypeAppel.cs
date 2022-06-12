using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddTypeAppel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TacheTypes",
                keyColumn: "Id",
                keyValue: "TacheType::2");

            migrationBuilder.AddColumn<string>(
                name: "TypeAppelId",
                table: "EchangeCommercials",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeAppel",
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
                    table.PrimaryKey("PK_TypeAppel", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TypeAppel",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "AppelType::1", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Appel", null });

            migrationBuilder.CreateIndex(
                name: "IX_EchangeCommercials_TypeAppelId",
                table: "EchangeCommercials",
                column: "TypeAppelId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeAppel_SearchTerms",
                table: "TypeAppel",
                column: "SearchTerms");

            migrationBuilder.AddForeignKey(
                name: "FK_EchangeCommercials_TypeAppel_TypeAppelId",
                table: "EchangeCommercials",
                column: "TypeAppelId",
                principalTable: "TypeAppel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EchangeCommercials_TypeAppel_TypeAppelId",
                table: "EchangeCommercials");

            migrationBuilder.DropTable(
                name: "TypeAppel");

            migrationBuilder.DropIndex(
                name: "IX_EchangeCommercials_TypeAppelId",
                table: "EchangeCommercials");

            migrationBuilder.DropColumn(
                name: "TypeAppelId",
                table: "EchangeCommercials");

            migrationBuilder.InsertData(
                table: "TacheTypes",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "TacheType::2", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Appel", null });
        }
    }
}
