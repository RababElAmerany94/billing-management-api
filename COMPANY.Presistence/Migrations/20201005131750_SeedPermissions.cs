using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class SeedPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Modele Sms", null });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Type Chauffage", null });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { "TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Type Logement", null });

            migrationBuilder.InsertData(
                table: "PermissionModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "PermissionId", "SearchTerms" },
                values: new object[,]
                {
                    { "Admin.Read.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Admin.Read", null },
                    { "Admin.Create.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Admin.Create", null },
                    { "Admin.Delete.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Admin.Delete", null },
                    { "Admin.Update.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Admin.Update", null },
                    { "Admin.Read.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Admin.Read", null },
                    { "Admin.Create.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Admin.Create", null },
                    { "Admin.Delete.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Admin.Delete", null },
                    { "Admin.Update.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Admin.Update", null },
                    { "Admin.Read.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Admin.Read", null },
                    { "Admin.Create.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Admin.Create", null },
                    { "Admin.Delete.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Admin.Delete", null },
                    { "Admin.Update.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Admin.Update", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Create.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Create.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Create.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Delete.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Delete.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Delete.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Update.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Update.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Update.TypeLogement");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "ModeleSms");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "TypeChauffage");

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: "TypeLogement");
        }
    }
}
