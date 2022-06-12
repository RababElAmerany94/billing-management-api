using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace COMPANY.Presistence.Migrations
{
    public partial class UpdateRolesAndPermissions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "PermissionModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "PermissionId", "SearchTerms" },
                values: new object[,]
                {
                    { "Admin.Read.DashboardProduction", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardProduction", "Permission::Admin.Read", null },
                    { "Admin.Read.DashboardCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardCommercial", "Permission::Admin.Read", null }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Access", "CreatedOn", "LastModifiedOn", "Name", "RoleId", "SearchTerms" },
                values: new object[,]
                {
                    { "Permission::AdminAgence.Read", 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Read", 7, null },
                    { "Permission::Technicien.Delete", 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Delete", 4, null },
                    { "Permission::Technicien.Create", 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Create", 4, null },
                    { "Permission::Technicien.Update", 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Update", 4, null },
                    { "Permission::Technicien.Read", 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Read", 4, null },
                    { "Permission::Commercial.Delete", 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Delete", 6, null },
                    { "Permission::Commercial.Create", 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Create", 6, null },
                    { "Permission::Commercial.Update", 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Update", 6, null },
                    { "Permission::Commercial.Read", 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Read", 6, null },
                    { "Permission::Directeur.Delete", 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Delete", 3, null },
                    { "Permission::Directeur.Update", 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Update", 3, null },
                    { "Permission::Directeur.Read", 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Read", 3, null },
                    { "Permission::Controleur.Delete", 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Delete", 2, null },
                    { "Permission::Controleur.Create", 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Create", 2, null },
                    { "Permission::Controleur.Update", 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Update", 2, null },
                    { "Permission::Controleur.Read", 2, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Read", 2, null },
                    { "Permission::AdminAgence.ManipulationLogin", 5, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Manipulation login", 7, null },
                    { "Permission::AdminAgence.Delete", 4, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Delete", 7, null },
                    { "Permission::AdminAgence.Create", 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Create", 7, null },
                    { "Permission::AdminAgence.Update", 3, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Update", 7, null },
                    { "Permission::Directeur.Create", 1, new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Create", 3, null }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SearchTerms" },
                values: new object[] { "directeur", "directeur" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "commercial");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "admin agence");

            migrationBuilder.InsertData(
                table: "PermissionModules",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "ModuleId", "PermissionId", "SearchTerms" },
                values: new object[,]
                {
                    { "AdminAgence.Read.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::AdminAgence.Read", null },
                    { "Directeur.Create.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Directeur.Create", null },
                    { "Directeur.Create.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::Directeur.Create", null },
                    { "Directeur.Create.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::Directeur.Create", null },
                    { "Directeur.Create.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Directeur.Create", null },
                    { "Directeur.Delete.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::Directeur.Delete", null },
                    { "Directeur.Delete.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Directeur.Delete", null },
                    { "Commercial.Read.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Commercial.Read", null },
                    { "Commercial.Read.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Commercial.Read", null },
                    { "Commercial.Read.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Commercial.Read", null },
                    { "Commercial.Read.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Commercial.Read", null },
                    { "Commercial.Read.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Commercial.Read", null },
                    { "Commercial.Read.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Commercial.Read", null },
                    { "Commercial.Read.CategoryProduct", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "CategoryProduct", "Permission::Commercial.Read", null },
                    { "Directeur.Create.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Directeur.Create", null },
                    { "Commercial.Read.ModesReglement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModesReglement", "Permission::Commercial.Read", null },
                    { "Directeur.Create.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Directeur.Create", null },
                    { "Directeur.Create.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::Directeur.Create", null },
                    { "Directeur.Read.CategoryProduct", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "CategoryProduct", "Permission::Directeur.Read", null },
                    { "Directeur.Read.ModesReglement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModesReglement", "Permission::Directeur.Read", null },
                    { "Directeur.Read.BankAccount", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BankAccount", "Permission::Directeur.Read", null },
                    { "Directeur.Read.AgendaParametrage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaParametrage", "Permission::Directeur.Read", null },
                    { "Directeur.Read.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Directeur.Read", null },
                    { "Directeur.Read.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Directeur.Read", null },
                    { "Directeur.Read.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Directeur.Read", null },
                    { "Directeur.Read.DashboardCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardCommercial", "Permission::Directeur.Read", null },
                    { "Directeur.Read.DashboardProduction", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardProduction", "Permission::Directeur.Read", null },
                    { "Directeur.Update.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Directeur.Update", null },
                    { "Directeur.Update.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::Directeur.Update", null },
                    { "Directeur.Update.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Directeur.Update", null },
                    { "Directeur.Create.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Directeur.Create", null },
                    { "Directeur.Create.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Directeur.Create", null },
                    { "Directeur.Create.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Directeur.Create", null },
                    { "Directeur.Read.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Directeur.Read", null },
                    { "Commercial.Read.BankAccount", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BankAccount", "Permission::Commercial.Read", null },
                    { "Commercial.Read.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Commercial.Read", null },
                    { "Technicien.Read.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Technicien.Read", null },
                    { "Technicien.Read.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Technicien.Read", null },
                    { "Technicien.Read.CategoryProduct", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "CategoryProduct", "Permission::Technicien.Read", null },
                    { "Technicien.Read.ModesReglement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModesReglement", "Permission::Technicien.Read", null },
                    { "Technicien.Read.BankAccount", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BankAccount", "Permission::Technicien.Read", null },
                    { "Technicien.Read.AgendaParametrage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaParametrage", "Permission::Technicien.Read", null },
                    { "Technicien.Read.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Technicien.Read", null },
                    { "Technicien.Read.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Technicien.Read", null },
                    { "Technicien.Read.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Technicien.Read", null },
                    { "Technicien.Update.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Technicien.Update", null },
                    { "Technicien.Update.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Technicien.Update", null },
                    { "Technicien.Update.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Technicien.Update", null },
                    { "Technicien.Update.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Technicien.Update", null },
                    { "Technicien.Update.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Technicien.Update", null },
                    { "Technicien.Create.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Technicien.Create", null },
                    { "Technicien.Create.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Technicien.Create", null },
                    { "Technicien.Create.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Technicien.Create", null },
                    { "Technicien.Create.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Technicien.Create", null },
                    { "Technicien.Delete.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Technicien.Delete", null },
                    { "Technicien.Delete.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Technicien.Delete", null },
                    { "Technicien.Delete.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Technicien.Delete", null },
                    { "Technicien.Read.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Technicien.Read", null },
                    { "Commercial.Read.AgendaParametrage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaParametrage", "Permission::Commercial.Read", null },
                    { "Technicien.Read.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Technicien.Read", null },
                    { "Commercial.Delete.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Commercial.Delete", null },
                    { "Commercial.Read.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Commercial.Read", null },
                    { "Commercial.Read.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Commercial.Read", null },
                    { "Commercial.Read.DashboardCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardCommercial", "Permission::Commercial.Read", null },
                    { "Commercial.Update.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Commercial.Update", null },
                    { "Commercial.Update.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Commercial.Update", null },
                    { "Commercial.Update.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Commercial.Update", null },
                    { "Commercial.Update.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Commercial.Update", null },
                    { "Commercial.Update.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Commercial.Update", null },
                    { "Commercial.Update.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Commercial.Update", null },
                    { "Commercial.Update.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Commercial.Update", null },
                    { "Commercial.Create.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Commercial.Create", null },
                    { "Commercial.Create.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Commercial.Create", null },
                    { "Commercial.Create.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Commercial.Create", null },
                    { "Commercial.Create.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Commercial.Create", null },
                    { "Commercial.Create.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Commercial.Create", null },
                    { "Commercial.Create.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Commercial.Create", null },
                    { "Commercial.Delete.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Commercial.Delete", null },
                    { "Commercial.Delete.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Commercial.Delete", null },
                    { "Commercial.Delete.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Commercial.Delete", null },
                    { "Commercial.Delete.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Commercial.Delete", null },
                    { "Commercial.Delete.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Commercial.Delete", null },
                    { "Commercial.Delete.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Commercial.Delete", null },
                    { "Directeur.Read.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::Directeur.Read", null },
                    { "Directeur.Read.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::Directeur.Read", null },
                    { "Directeur.Read.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Directeur.Read", null },
                    { "AdminAgence.Update.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Create.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Users", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Users", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Create.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::AdminAgence.Create", null },
                    { "AdminAgence.Delete.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Update.Users", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Users", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Delete.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Update.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Update.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Read.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Users", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Users", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Accounting", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Accounting", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.CategoryProduct", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "CategoryProduct", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.ModesReglement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModesReglement", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.BankAccount", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BankAccount", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.AgendaParametrage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaParametrage", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.DashboardCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardCommercial", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Read.DashboardProduction", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardProduction", "Permission::AdminAgence.Read", null },
                    { "AdminAgence.Update.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::AdminAgence.Update", null },
                    { "AdminAgence.Delete.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Users", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Users", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::AdminAgence.Delete", null },
                    { "Controleur.Update.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Controleur.Update", null },
                    { "Controleur.Update.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Controleur.Update", null },
                    { "Controleur.Create.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Controleur.Create", null },
                    { "Controleur.Create.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Controleur.Create", null },
                    { "Controleur.Create.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Controleur.Create", null },
                    { "Controleur.Create.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Controleur.Create", null },
                    { "Controleur.Create.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Controleur.Create", null },
                    { "Controleur.Create.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Controleur.Create", null },
                    { "Controleur.Delete.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Controleur.Delete", null },
                    { "Controleur.Delete.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Controleur.Delete", null },
                    { "Controleur.Delete.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Controleur.Delete", null },
                    { "Controleur.Delete.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Controleur.Delete", null },
                    { "Controleur.Delete.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Controleur.Delete", null },
                    { "Controleur.Delete.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Controleur.Delete", null },
                    { "Controleur.Delete.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Controleur.Delete", null },
                    { "Directeur.Read.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Directeur.Read", null },
                    { "Directeur.Read.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Directeur.Read", null },
                    { "Directeur.Read.Fournisseurs", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Fournisseurs", "Permission::Directeur.Read", null },
                    { "Directeur.Read.Produits", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Produits", "Permission::Directeur.Read", null },
                    { "Directeur.Read.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Directeur.Read", null },
                    { "Directeur.Read.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Directeur.Read", null },
                    { "Controleur.Update.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Controleur.Update", null },
                    { "Controleur.Update.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Controleur.Update", null },
                    { "Controleur.Update.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Controleur.Update", null },
                    { "Controleur.Update.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Controleur.Update", null },
                    { "AdminAgence.Delete.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Facture", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Facture", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Avoir", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Avoir", "Permission::AdminAgence.Delete", null },
                    { "AdminAgence.Delete.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::AdminAgence.Delete", null },
                    { "Controleur.Read.Clients", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Clients", "Permission::Controleur.Read", null },
                    { "Controleur.Read.Parameters", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Parameters", "Permission::Controleur.Read", null },
                    { "Controleur.Read.Dossiers", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Dossiers", "Permission::Controleur.Read", null },
                    { "Technicien.Delete.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Technicien.Delete", null },
                    { "Controleur.Read.AgendaCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaCommercial", "Permission::Controleur.Read", null },
                    { "Controleur.Read.Paiement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Paiement", "Permission::Controleur.Read", null },
                    { "Controleur.Read.CategoryProduct", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "CategoryProduct", "Permission::Controleur.Read", null },
                    { "Controleur.Read.ModesReglement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModesReglement", "Permission::Controleur.Read", null },
                    { "Controleur.Read.BankAccount", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "BankAccount", "Permission::Controleur.Read", null },
                    { "Controleur.Read.AgendaParametrage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "AgendaParametrage", "Permission::Controleur.Read", null },
                    { "Controleur.Read.ModeleSms", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "ModeleSms", "Permission::Controleur.Read", null },
                    { "Controleur.Read.TypeChauffage", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeChauffage", "Permission::Controleur.Read", null },
                    { "Controleur.Read.TypeLogement", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "TypeLogement", "Permission::Controleur.Read", null },
                    { "Controleur.Read.DashboardCommercial", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "DashboardCommercial", "Permission::Controleur.Read", null },
                    { "Controleur.Update.Home", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Home", "Permission::Controleur.Update", null },
                    { "Controleur.Read.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Controleur.Read", null },
                    { "Technicien.Delete.Devis", new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, "Devis", "Permission::Technicien.Delete", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.DashboardCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Admin.Read.DashboardProduction");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Create.Users");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Delete.Users");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Accounting");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.AgendaParametrage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.BankAccount");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.CategoryProduct");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.DashboardCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.DashboardProduction");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.ModesReglement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Read.Users");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "AdminAgence.Update.Users");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Create.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Delete.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.AgendaParametrage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.BankAccount");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.CategoryProduct");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.DashboardCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.ModesReglement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Read.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Commercial.Update.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Create.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Delete.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.AgendaParametrage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.BankAccount");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.CategoryProduct");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.DashboardCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.ModesReglement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Read.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Controleur.Update.Parameters");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Create.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Delete.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.AgendaParametrage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.BankAccount");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.CategoryProduct");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.DashboardCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.DashboardProduction");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.ModesReglement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Read.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Avoir");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Facture");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Fournisseurs");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Paiement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Directeur.Update.Produits");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Create.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Create.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Create.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Create.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Delete.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Delete.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Delete.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Delete.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Delete.Home");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.AgendaParametrage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.BankAccount");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.CategoryProduct");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.ModeleSms");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.ModesReglement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.TypeChauffage");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Read.TypeLogement");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Update.AgendaCommercial");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Update.Clients");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Update.Devis");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Update.Dossiers");

            migrationBuilder.DeleteData(
                table: "PermissionModules",
                keyColumn: "Id",
                keyValue: "Technicien.Update.Home");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::AdminAgence.ManipulationLogin");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::AdminAgence.Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::AdminAgence.Delete");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::AdminAgence.Read");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::AdminAgence.Update");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Commercial.Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Commercial.Delete");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Commercial.Read");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Commercial.Update");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Controleur.Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Controleur.Delete");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Controleur.Read");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Controleur.Update");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Directeur.Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Directeur.Delete");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Directeur.Read");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Directeur.Update");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Technicien.Create");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Technicien.Delete");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Technicien.Read");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: "Permission::Technicien.Update");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "SearchTerms" },
                values: new object[] { "directeurCommercial", "directeur commercial" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Commercial");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Admin Agence");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name", "SearchTerms" },
                values: new object[] { 5, new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "manager", "manager" });
        }
    }
}
