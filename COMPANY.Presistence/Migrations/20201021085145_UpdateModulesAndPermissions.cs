using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateModulesAndPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BonCommande",
                table: "DocumentParameters",
                type: "LONGTEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Bon commande", null });

            migrationBuilder.InsertData(
                table: "PermissionModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "PermissionId", "SearchTerms" },
                values: new object[,]
                {
                    { "Admin.Read.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Admin.Read", null },
                    { "Commercial.Update.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Commercial.Update", null },
                    { "Directeur.Update.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Directeur.Update", null },
                    { "AdminAgence.Update.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::AdminAgence.Update", null },
                    { "Admin.Update.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Admin.Update", null },
                    { "Technicien.Delete.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Technicien.Delete", null },
                    { "Controleur.Delete.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Controleur.Delete", null },
                    { "Commercial.Delete.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Commercial.Delete", null },
                    { "Directeur.Delete.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Directeur.Delete", null },
                    { "AdminAgence.Delete.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::AdminAgence.Delete", null },
                    { "Admin.Delete.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Admin.Delete", null },
                    { "Technicien.Create.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Technicien.Create", null },
                    { "Controleur.Create.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Controleur.Create", null },
                    { "Commercial.Create.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Commercial.Create", null },
                    { "Directeur.Create.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Directeur.Create", null },
                    { "AdminAgence.Create.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::AdminAgence.Create", null },
                    { "Admin.Create.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Admin.Create", null },
                    { "Technicien.Read.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Technicien.Read", null },
                    { "Controleur.Read.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Controleur.Read", null },
                    { "Commercial.Read.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Commercial.Read", null },
                    { "Directeur.Read.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Directeur.Read", null },
                    { "AdminAgence.Read.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::AdminAgence.Read", null },
                    { "Controleur.Update.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Controleur.Update", null },
                    { "Technicien.Update.BonCommande", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BonCommande", "Permission::Technicien.Update", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Create.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Delete.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Update.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Create.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Delete.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.BonCommande");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Update.BonCommande");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "BonCommande");

            migrationBuilder.DropColumn(
                name: "BonCommande",
                table: "DocumentParameters");
        }
    }
}
