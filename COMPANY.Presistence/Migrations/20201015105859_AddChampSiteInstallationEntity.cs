using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class AddChampSiteInstallationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChampsSiteInstallation",
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
                    table.PrimaryKey("PK_ChampsSiteInstallation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "ChampsSiteInstallation", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Champs Site Installation", null });

            migrationBuilder.InsertData(
                table: "PermissionModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "PermissionId", "SearchTerms" },
                values: new object[,]
                {
                    { "Admin.Read.ChampsSiteInstallation", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ChampsSiteInstallation", "Permission::Admin.Read", null },
                    { "Admin.Create.ChampsSiteInstallation", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ChampsSiteInstallation", "Permission::Admin.Create", null },
                    { "Admin.Delete.ChampsSiteInstallation", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ChampsSiteInstallation", "Permission::Admin.Delete", null },
                    { "Admin.Update.ChampsSiteInstallation", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ChampsSiteInstallation", "Permission::Admin.Update", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampsSiteInstallation_Name",
                table: "ChampsSiteInstallation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChampsSiteInstallation_SearchTerms",
                table: "ChampsSiteInstallation",
                column: "SearchTerms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChampsSiteInstallation");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Create.ChampsSiteInstallation");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Delete.ChampsSiteInstallation");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.ChampsSiteInstallation");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Update.ChampsSiteInstallation");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "ChampsSiteInstallation");
        }
    }
}
