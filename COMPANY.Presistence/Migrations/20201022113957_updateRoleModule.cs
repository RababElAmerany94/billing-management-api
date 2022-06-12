using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class updateRoleModule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RolesModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "RoleId", "SearchTerms" },
                values: new object[,]
                {
                    { "RoleModule::Admin.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", 1, null },
                    { "RoleModule::AdminAgence.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", 1, null },
                    { "RoleModule::Directeur.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", 1, null },
                    { "RoleModule::Commercial.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", 1, null },
                    { "RoleModule::Controleur.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", 1, null },
                    { "RoleModule::Technicien.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", 1, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Admin.BonCommande");

            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::AdminAgence.BonCommande");

            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Commercial.BonCommande");

            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Controleur.BonCommande");

            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Directeur.BonCommande");

            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Technicien.BonCommande");
        }
    }
}
