using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdatePermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PermissionModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "PermissionId", "SearchTerms" },
                values: new object[,]
                {
                    { "Directeur.Read.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Commercial.Read", null },
                    { "Commercial.Read.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Commercial.Read", null },
                    { "Commercial.Read.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Commercial.Read", null },
                    { "Controleur.Read.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Controleur.Read", null },
                    { "Controleur.Read.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Controleur.Read", null },
                    { "Technicien.Read.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Technicien.Read", null },
                    { "Technicien.Read.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Technicien.Read", null },
                    { "Technicien.Read.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Technicien.Read", null }
                });

            migrationBuilder.InsertData(
                table: "RolesModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "RoleId", "SearchTerms" },
                values: new object[] { "RoleModule::Commercial.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", 6, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.Produits");

            migrationBuilder.DeleteData(
                table: "RolesModules",
                keyColumn: "Id",
                keyValue: "RoleModule::Commercial.Home");
        }
    }
}
