namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.AccountManagement
{
    using COMPANY.Application.Enums;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Authentification;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PermissionEntityConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            // relationship
            builder
                .HasOne(e => e.Role)
                .WithMany(e => e.Permissions)
                .HasForeignKey(e => e.RoleId);

            // seed
            builder.HasData(

            #region permissions for admin

                new Permission()
                {
                    Id = "Permission::Admin.Read",
                    Name = "Read",
                    Access = Access.Read,
                    RoleId = (int)UserRole.Admin
                },
                new Permission()
                {
                    Id = "Permission::Admin.Update",
                    Name = "Update",
                    Access = Access.Update,
                    RoleId = (int)UserRole.Admin
                },
                new Permission()
                {
                    Id = "Permission::Admin.Create",
                    Name = "Create",
                    Access = Access.Create,
                    RoleId = (int)UserRole.Admin
                },
                new Permission()
                {
                    Id = "Permission::Admin.Delete",
                    Name = "Delete",
                    Access = Access.Delete,
                    RoleId = (int)UserRole.Admin
                },
                new Permission()
                {
                    Id = "Permission::Admin.ManipulationLogin",
                    Name = "Manipulation login",
                    Access = Access.ManipulationLogin,
                    RoleId = (int)UserRole.Admin
                },

            #endregion

            #region permissions for admin agence

                new Permission()
                {
                    Id = "Permission::AdminAgence.Read",
                    Name = "Read",
                    Access = Access.Read,
                    RoleId = (int)UserRole.AdminAgence
                },
                new Permission()
                {
                    Id = "Permission::AdminAgence.Update",
                    Name = "Update",
                    Access = Access.Update,
                    RoleId = (int)UserRole.AdminAgence
                },
                new Permission()
                {
                    Id = "Permission::AdminAgence.Create",
                    Name = "Create",
                    Access = Access.Create,
                    RoleId = (int)UserRole.AdminAgence
                },
                new Permission()
                {
                    Id = "Permission::AdminAgence.Delete",
                    Name = "Delete",
                    Access = Access.Delete,
                    RoleId = (int)UserRole.AdminAgence
                },
                new Permission()
                {
                    Id = "Permission::AdminAgence.ManipulationLogin",
                    Name = "Manipulation login",
                    Access = Access.ManipulationLogin,
                    RoleId = (int)UserRole.AdminAgence
                },

            #endregion

            #region permissions for Contrôleur

                new Permission()
                {
                    Id = "Permission::Controleur.Read",
                    Name = "Read",
                    Access = Access.Read,
                    RoleId = (int)UserRole.Controleur
                },
                new Permission()
                {
                    Id = "Permission::Controleur.Update",
                    Name = "Update",
                    Access = Access.Update,
                    RoleId = (int)UserRole.Controleur
                },
                new Permission()
                {
                    Id = "Permission::Controleur.Create",
                    Name = "Create",
                    Access = Access.Create,
                    RoleId = (int)UserRole.Controleur
                },
                new Permission()
                {
                    Id = "Permission::Controleur.Delete",
                    Name = "Delete",
                    Access = Access.Delete,
                    RoleId = (int)UserRole.Controleur
                },

            #endregion

            #region permissions for Directeur

                new Permission()
                {
                    Id = "Permission::Directeur.Read",
                    Name = "Read",
                    Access = Access.Read,
                    RoleId = (int)UserRole.Directeur
                },
                new Permission()
                {
                    Id = "Permission::Directeur.Update",
                    Name = "Update",
                    Access = Access.Update,
                    RoleId = (int)UserRole.Directeur
                },
                new Permission()
                {
                    Id = "Permission::Directeur.Create",
                    Name = "Create",
                    Access = Access.Create,
                    RoleId = (int)UserRole.Directeur
                },
                new Permission()
                {
                    Id = "Permission::Directeur.Delete",
                    Name = "Delete",
                    Access = Access.Delete,
                    RoleId = (int)UserRole.Directeur
                },

            #endregion

            #region permissions for Commercial

                new Permission()
                {
                    Id = "Permission::Commercial.Read",
                    Name = "Read",
                    Access = Access.Read,
                    RoleId = (int)UserRole.Commercial
                },
                new Permission()
                {
                    Id = "Permission::Commercial.Update",
                    Name = "Update",
                    Access = Access.Update,
                    RoleId = (int)UserRole.Commercial
                },
                new Permission()
                {
                    Id = "Permission::Commercial.Create",
                    Name = "Create",
                    Access = Access.Create,
                    RoleId = (int)UserRole.Commercial
                },
                new Permission()
                {
                    Id = "Permission::Commercial.Delete",
                    Name = "Delete",
                    Access = Access.Delete,
                    RoleId = (int)UserRole.Commercial
                },

            #endregion

            #region permissions for Technicien

                new Permission()
                {
                    Id = "Permission::Technicien.Read",
                    Name = "Read",
                    Access = Access.Read,
                    RoleId = (int)UserRole.Technicien
                },
                new Permission()
                {
                    Id = "Permission::Technicien.Update",
                    Name = "Update",
                    Access = Access.Update,
                    RoleId = (int)UserRole.Technicien
                },
                new Permission()
                {
                    Id = "Permission::Technicien.Create",
                    Name = "Create",
                    Access = Access.Create,
                    RoleId = (int)UserRole.Technicien
                },
                new Permission()
                {
                    Id = "Permission::Technicien.Delete",
                    Name = "Delete",
                    Access = Access.Delete,
                    RoleId = (int)UserRole.Technicien
                }

                #endregion

            );

        }
    }

    public class PermissionModuleEntityConfiguration : IEntityTypeConfiguration<PermissionModule>
    {
        public void Configure(EntityTypeBuilder<PermissionModule> builder)
        {
            // configuration
            builder
               .HasOne(e => e.Module)
               .WithMany(e => e.PermissionModules)
               .HasForeignKey(e => e.ModuleId);

            builder
                .HasOne(e => e.Permission)
                .WithMany(e => e.Modules)
                .HasForeignKey(e => e.PermissionId);

            // Seed 
            builder.HasData(

            #region Read

            #region admin

                new PermissionModule() { Id = "Admin.Read.Home", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Admin.Read.Clients", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Admin.Read.Fournisseurs", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Admin.Read.Agences", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Agences.ToString() },
                new PermissionModule() { Id = "Admin.Read.Users", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "Admin.Read.Produits", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Admin.Read.Parameters", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Admin.Read.Dossiers", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Admin.Read.AgendaCommercial", PermissionId = "Permission::Admin.Read", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Admin.Read.Devis", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Admin.Read.BonCommande", PermissionId = "Permission::Admin.Read", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Admin.Read.Facture", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Admin.Read.Avoir", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Admin.Read.Paiement", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Admin.Read.Accounting", PermissionId = "Permission::Admin.Read", ModuleId = Modules.Accounting.ToString() },
                new PermissionModule() { Id = "Admin.Read.CategoryProduct", PermissionId = "Permission::Admin.Read", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Admin.Read.ModesReglement", PermissionId = "Permission::Admin.Read", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Admin.Read.BankAccount", PermissionId = "Permission::Admin.Read", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Admin.Read.AgendaParametrage", PermissionId = "Permission::Admin.Read", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Admin.Read.ModeleSms", PermissionId = "Permission::Admin.Read", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Admin.Read.TypeChauffage", PermissionId = "Permission::Admin.Read", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Admin.Read.TypeLogement", PermissionId = "Permission::Admin.Read", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Admin.Read.DashboardCommercial", PermissionId = "Permission::Admin.Read", ModuleId = Modules.DashboardCommercial.ToString() },
                new PermissionModule() { Id = "Admin.Read.DashboardProduction", PermissionId = "Permission::Admin.Read", ModuleId = Modules.DashboardProduction.ToString() },
                new PermissionModule() { Id = "Admin.Read.ChampsSiteInstallation", PermissionId = "Permission::Admin.Read", ModuleId = Modules.ChampsSiteInstallation.ToString() },

            #endregion

            #region Admin Agence

                new PermissionModule() { Id = "AdminAgence.Read.Home", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Clients", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Fournisseurs", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Users", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Produits", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Parameters", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Dossiers", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.AgendaCommercial", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Devis", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.BonCommande", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Facture", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Avoir", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Accounting", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Accounting.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.Paiement", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.CategoryProduct", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.ModesReglement", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.BankAccount", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.AgendaParametrage", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.ModeleSms", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.TypeChauffage", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.TypeLogement", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.DashboardCommercial", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.DashboardCommercial.ToString() },
                new PermissionModule() { Id = "AdminAgence.Read.DashboardProduction", PermissionId = "Permission::AdminAgence.Read", ModuleId = Modules.DashboardProduction.ToString() },

            #endregion

            #region Directeur

                new PermissionModule() { Id = "Directeur.Read.Home", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Clients", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Fournisseurs", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Produits", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Dossiers", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Directeur.Read.AgendaCommercial", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Devis", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Directeur.Read.BonCommande", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Facture", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Avoir", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Paiement", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Directeur.Read.CategoryProduct", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Directeur.Read.ModesReglement", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Directeur.Read.BankAccount", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Directeur.Read.AgendaParametrage", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Directeur.Read.ModeleSms", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Directeur.Read.TypeChauffage", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Directeur.Read.TypeLogement", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Directeur.Read.DashboardCommercial", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.DashboardCommercial.ToString() },
                new PermissionModule() { Id = "Directeur.Read.DashboardProduction", PermissionId = "Permission::Directeur.Read", ModuleId = Modules.DashboardProduction.ToString() },
                new PermissionModule() { Id = "Directeur.Read.Parameters", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Parameters.ToString() },

            #endregion

            #region Commercial

                new PermissionModule() { Id = "Commercial.Read.Home", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Commercial.Read.Clients", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Commercial.Read.Parameters", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Commercial.Read.Dossiers", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Commercial.Read.AgendaCommercial", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Commercial.Read.Devis", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Commercial.Read.BonCommande", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Commercial.Read.Paiement", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Commercial.Read.CategoryProduct", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Commercial.Read.ModesReglement", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Commercial.Read.BankAccount", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Commercial.Read.AgendaParametrage", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Commercial.Read.ModeleSms", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Commercial.Read.TypeChauffage", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Commercial.Read.TypeLogement", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Commercial.Read.DashboardCommercial", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.DashboardCommercial.ToString() },
                new PermissionModule() { Id = "Commercial.Read.Produits", PermissionId = "Permission::Commercial.Read", ModuleId = Modules.Produits.ToString() },

            #endregion

            #region Contrôleur

                new PermissionModule() { Id = "Controleur.Read.Home", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Controleur.Read.Clients", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Controleur.Read.Parameters", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Controleur.Read.Dossiers", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Controleur.Read.AgendaCommercial", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Controleur.Read.Devis", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Controleur.Read.BonCommande", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Controleur.Read.Paiement", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Controleur.Read.CategoryProduct", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Controleur.Read.ModesReglement", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Controleur.Read.BankAccount", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Controleur.Read.AgendaParametrage", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Controleur.Read.ModeleSms", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Controleur.Read.TypeChauffage", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Controleur.Read.TypeLogement", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Controleur.Read.DashboardCommercial", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.DashboardCommercial.ToString() },
                new PermissionModule() { Id = "Controleur.Read.Produits", PermissionId = "Permission::Controleur.Read", ModuleId = Modules.Produits.ToString() },

            #endregion

            #region Technicien

                new PermissionModule() { Id = "Technicien.Read.Home", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Technicien.Read.Clients", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Technicien.Read.Dossiers", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Technicien.Read.AgendaCommercial", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Technicien.Read.Devis", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Technicien.Read.BonCommande", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Technicien.Read.CategoryProduct", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Technicien.Read.ModesReglement", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Technicien.Read.BankAccount", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Technicien.Read.AgendaParametrage", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Technicien.Read.ModeleSms", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Technicien.Read.TypeChauffage", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Technicien.Read.TypeLogement", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Technicien.Read.Produits", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Technicien.Read.Parameters", PermissionId = "Permission::Technicien.Read", ModuleId = Modules.Parameters.ToString() },

            #endregion

            #endregion

            #region Create

            #region Admin

                new PermissionModule() { Id = "Admin.Create.Home", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Admin.Create.Clients", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Admin.Create.Fournisseurs", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Admin.Create.Agences", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Agences.ToString() },
                new PermissionModule() { Id = "Admin.Create.Users", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "Admin.Create.Produits", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Admin.Create.Parameters", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Admin.Create.Dossiers", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Admin.Create.AgendaCommercial", PermissionId = "Permission::Admin.Create", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Admin.Create.Devis", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Admin.Create.BonCommande", PermissionId = "Permission::Admin.Create", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Admin.Create.Facture", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Admin.Create.Avoir", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Admin.Create.Paiement", PermissionId = "Permission::Admin.Create", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Admin.Create.CategoryProduct", PermissionId = "Permission::Admin.Create", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Admin.Create.ModesReglement", PermissionId = "Permission::Admin.Create", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Admin.Create.BankAccount", PermissionId = "Permission::Admin.Create", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Admin.Create.AgendaParametrage", PermissionId = "Permission::Admin.Create", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Admin.Create.ModeleSms", PermissionId = "Permission::Admin.Create", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Admin.Create.TypeChauffage", PermissionId = "Permission::Admin.Create", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Admin.Create.TypeLogement", PermissionId = "Permission::Admin.Create", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Admin.Create.ChampsSiteInstallation", PermissionId = "Permission::Admin.Create", ModuleId = Modules.ChampsSiteInstallation.ToString() },

            #endregion

            #region Admin Agence

                new PermissionModule() { Id = "AdminAgence.Create.Home", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Clients", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Fournisseurs", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Users", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Produits", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Parameters", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Dossiers", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.AgendaCommercial", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Devis", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.BonCommande", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Facture", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Avoir", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "AdminAgence.Create.Paiement", PermissionId = "Permission::AdminAgence.Create", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Directeur

                new PermissionModule() { Id = "Directeur.Create.Home", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Clients", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Fournisseurs", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Produits", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Dossiers", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Directeur.Create.AgendaCommercial", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Devis", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Directeur.Create.BonCommande", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Facture", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Avoir", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Directeur.Create.Paiement", PermissionId = "Permission::Directeur.Create", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Commercial

                new PermissionModule() { Id = "Commercial.Create.Clients", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Commercial.Create.Parameters", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Commercial.Create.Dossiers", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Commercial.Create.AgendaCommercial", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Commercial.Create.Devis", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Commercial.Create.BonCommande", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Commercial.Create.Paiement", PermissionId = "Permission::Commercial.Create", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Contrôleur

                new PermissionModule() { Id = "Controleur.Create.Clients", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Controleur.Create.Parameters", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Controleur.Create.Dossiers", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Controleur.Create.AgendaCommercial", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Controleur.Create.Devis", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Controleur.Create.BonCommande", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Controleur.Create.Paiement", PermissionId = "Permission::Controleur.Create", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Technicien

                new PermissionModule() { Id = "Technicien.Create.Clients", PermissionId = "Permission::Technicien.Create", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Technicien.Create.Dossiers", PermissionId = "Permission::Technicien.Create", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Technicien.Create.AgendaCommercial", PermissionId = "Permission::Technicien.Create", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Technicien.Create.Devis", PermissionId = "Permission::Technicien.Create", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Technicien.Create.BonCommande", PermissionId = "Permission::Technicien.Create", ModuleId = Modules.BonCommande.ToString() },

            #endregion

            #endregion

            #region Delete

            #region admin

                new PermissionModule() { Id = "Admin.Delete.Home", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Clients", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Fournisseurs", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Agences", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Agences.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Users", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Produits", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Parameters", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Dossiers", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Admin.Delete.AgendaCommercial", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Devis", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Admin.Delete.BonCommande", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Facture", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Avoir", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Admin.Delete.Paiement", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Admin.Delete.CategoryProduct", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Admin.Delete.ModesReglement", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Admin.Delete.BankAccount", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Admin.Delete.AgendaParametrage", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Admin.Delete.ModeleSms", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Admin.Delete.TypeChauffage", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Admin.Delete.TypeLogement", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Admin.Delete.ChampsSiteInstallation", PermissionId = "Permission::Admin.Delete", ModuleId = Modules.ChampsSiteInstallation.ToString() },

            #endregion

            #region Admin Agence

                new PermissionModule() { Id = "AdminAgence.Delete.Home", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Clients", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Fournisseurs", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Users", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Produits", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Parameters", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Dossiers", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.AgendaCommercial", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Devis", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.BonCommande", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Facture", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Avoir", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "AdminAgence.Delete.Paiement", PermissionId = "Permission::AdminAgence.Delete", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Directeur

                new PermissionModule() { Id = "Directeur.Delete.Home", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Clients", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Fournisseurs", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Produits", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Dossiers", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.AgendaCommercial", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Devis", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.BonCommande", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Facture", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Avoir", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Directeur.Delete.Paiement", PermissionId = "Permission::Directeur.Delete", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Commercial

                new PermissionModule() { Id = "Commercial.Delete.Home", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.Clients", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.Parameters", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.Dossiers", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.AgendaCommercial", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.Devis", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.BonCommande", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Commercial.Delete.Paiement", PermissionId = "Permission::Commercial.Delete", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Contrôleur

                new PermissionModule() { Id = "Controleur.Delete.Home", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.Clients", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.Parameters", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.Dossiers", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.AgendaCommercial", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.Devis", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.BonCommande", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Controleur.Delete.Paiement", PermissionId = "Permission::Controleur.Delete", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Technicien

                new PermissionModule() { Id = "Technicien.Delete.Home", PermissionId = "Permission::Technicien.Delete", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Technicien.Delete.Clients", PermissionId = "Permission::Technicien.Delete", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Technicien.Delete.Dossiers", PermissionId = "Permission::Technicien.Delete", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Technicien.Delete.AgendaCommercial", PermissionId = "Permission::Technicien.Delete", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Technicien.Delete.Devis", PermissionId = "Permission::Technicien.Delete", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Technicien.Delete.BonCommande", PermissionId = "Permission::Technicien.Delete", ModuleId = Modules.BonCommande.ToString() },

            #endregion

            #endregion

            #region Update

            #region admin

                new PermissionModule() { Id = "Admin.Update.Home", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Admin.Update.Clients", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Admin.Update.Fournisseurs", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Admin.Update.Agences", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Agences.ToString() },
                new PermissionModule() { Id = "Admin.Update.Users", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "Admin.Update.Produits", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Admin.Update.Parameters", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Admin.Update.Dossiers", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Admin.Update.AgendaCommercial", PermissionId = "Permission::Admin.Update", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Admin.Update.Devis", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Admin.Update.BonCommande", PermissionId = "Permission::Admin.Update", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Admin.Update.Facture", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Admin.Update.Avoir", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Admin.Update.Paiement", PermissionId = "Permission::Admin.Update", ModuleId = Modules.Paiement.ToString() },
                new PermissionModule() { Id = "Admin.Update.CategoryProduct", PermissionId = "Permission::Admin.Update", ModuleId = Modules.CategoryProduct.ToString() },
                new PermissionModule() { Id = "Admin.Update.ModesReglement", PermissionId = "Permission::Admin.Update", ModuleId = Modules.ModesReglement.ToString() },
                new PermissionModule() { Id = "Admin.Update.BankAccount", PermissionId = "Permission::Admin.Update", ModuleId = Modules.BankAccount.ToString() },
                new PermissionModule() { Id = "Admin.Update.AgendaParametrage", PermissionId = "Permission::Admin.Update", ModuleId = Modules.AgendaParametrage.ToString() },
                new PermissionModule() { Id = "Admin.Update.ModeleSms", PermissionId = "Permission::Admin.Update", ModuleId = Modules.ModeleSms.ToString() },
                new PermissionModule() { Id = "Admin.Update.TypeChauffage", PermissionId = "Permission::Admin.Update", ModuleId = Modules.TypeChauffage.ToString() },
                new PermissionModule() { Id = "Admin.Update.TypeLogement", PermissionId = "Permission::Admin.Update", ModuleId = Modules.TypeLogement.ToString() },
                new PermissionModule() { Id = "Admin.Update.ChampsSiteInstallation", PermissionId = "Permission::Admin.Update", ModuleId = Modules.ChampsSiteInstallation.ToString() },

            #endregion

            #region Admin Agence

                new PermissionModule() { Id = "AdminAgence.Update.Home", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Clients", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Fournisseurs", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Users", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Users.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Produits", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Parameters", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Dossiers", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.AgendaCommercial", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Devis", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.BonCommande", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Facture", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Avoir", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "AdminAgence.Update.Paiement", PermissionId = "Permission::AdminAgence.Update", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Directeur

                new PermissionModule() { Id = "Directeur.Update.Home", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Clients", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Fournisseurs", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Fournisseurs.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Produits", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Produits.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Dossiers", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Directeur.Update.AgendaCommercial", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Devis", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Directeur.Update.BonCommande", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Facture", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Facture.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Avoir", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Avoir.ToString() },
                new PermissionModule() { Id = "Directeur.Update.Paiement", PermissionId = "Permission::Directeur.Update", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Commercial

                new PermissionModule() { Id = "Commercial.Update.Home", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Commercial.Update.Clients", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Commercial.Update.Parameters", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Commercial.Update.Dossiers", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Commercial.Update.AgendaCommercial", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Commercial.Update.Devis", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Commercial.Update.BonCommande", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Commercial.Update.Paiement", PermissionId = "Permission::Commercial.Update", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Contrôleur

                new PermissionModule() { Id = "Controleur.Update.Home", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Controleur.Update.Clients", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Controleur.Update.Parameters", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.Parameters.ToString() },
                new PermissionModule() { Id = "Controleur.Update.Dossiers", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Controleur.Update.AgendaCommercial", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Controleur.Update.Devis", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Controleur.Update.BonCommande", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.BonCommande.ToString() },
                new PermissionModule() { Id = "Controleur.Update.Paiement", PermissionId = "Permission::Controleur.Update", ModuleId = Modules.Paiement.ToString() },

            #endregion

            #region Technicien

                new PermissionModule() { Id = "Technicien.Update.Home", PermissionId = "Permission::Technicien.Update", ModuleId = Modules.Home.ToString() },
                new PermissionModule() { Id = "Technicien.Update.Clients", PermissionId = "Permission::Technicien.Update", ModuleId = Modules.Clients.ToString() },
                new PermissionModule() { Id = "Technicien.Update.Dossiers", PermissionId = "Permission::Technicien.Update", ModuleId = Modules.Dossiers.ToString() },
                new PermissionModule() { Id = "Technicien.Update.AgendaCommercial", PermissionId = "Permission::Technicien.Update", ModuleId = Modules.AgendaCommercial.ToString() },
                new PermissionModule() { Id = "Technicien.Update.Devis", PermissionId = "Permission::Technicien.Update", ModuleId = Modules.Devis.ToString() },
                new PermissionModule() { Id = "Technicien.Update.BonCommande", PermissionId = "Permission::Technicien.Update", ModuleId = Modules.BonCommande.ToString() },

            #endregion

            #endregion

            #region Manipulation login

                new PermissionModule() { Id = "Admin.ManipulationLogin.Agence", PermissionId = "Permission::Admin.ManipulationLogin", ModuleId = Modules.Agences.ToString() }

            #endregion

            );
        }
    }
}
