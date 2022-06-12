using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class SeedRoleModuleWithChampsSiteInstallation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolesModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "RoleId", "SearchTerms" },
                values: new object[] { "RoleModule::Admin.ChampsSiteInstallation", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ChampsSiteInstallation", 1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Admin.ChampsSiteInstallation");
        }
    }
}
