namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.AccountManagement
{
    using COMPANY.Application.Enums;
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.Relations;
    using COMPANY.Domain.Enums.Authentification;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RoleEntitiesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // properties configuration
            builder
                .Property(e => e.Name)
                .HasMaxLength(250)
                .IsRequired();

            builder
                .Property(e => e.CreatedOn)
                .HasDefaultValue();

            // index
            builder
                .HasIndex(e => e.Name)
                .IsUnique();

            builder.HasData(new Role[] {
                Role.CreateAdminRole(),
                Role.CreateControleurRole(),
                Role.CreateDirecteurRole(),
                Role.CreateTechnicienRole(),
                Role.CreateCommercialRole(),
                Role.CreateAgenceAdmin()
            });
        }
    }

    public class RoleModuleEntityConfiguration : IEntityTypeConfiguration<RoleModule>
    {
        public void Configure(EntityTypeBuilder<RoleModule> builder)
        {
            builder
                .HasOne(e => e.Module)
                .WithMany(e => e.RoleModules)
                .HasForeignKey(e => e.ModuleId);

            builder
                .HasOne(e => e.Role)
                .WithMany(e => e.Modules)
                .HasForeignKey(e => e.RoleId);

            builder.HasData(

            #region Admin

                new RoleModule("RoleModule::Admin.Home", UserRole.Admin, Modules.Home.ToString()),
                new RoleModule("RoleModule::Admin.DashboardCommercial", UserRole.Admin, Modules.DashboardCommercial.ToString()),
                new RoleModule("RoleModule::Admin.DashboardProduction", UserRole.Admin, Modules.DashboardProduction.ToString()),
                new RoleModule("RoleModule::Admin.Clients", UserRole.Admin, Modules.Clients.ToString()),
                new RoleModule("RoleModule::Admin.Fournisseurs", UserRole.Admin, Modules.Fournisseurs.ToString()),
                new RoleModule("RoleModule::Admin.Agences", UserRole.Admin, Modules.Agences.ToString()),
                new RoleModule("RoleModule::Admin.Users", UserRole.Admin, Modules.Users.ToString()),
                new RoleModule("RoleModule::Admin.Produits", UserRole.Admin, Modules.Produits.ToString()),
                new RoleModule("RoleModule::Admin.Parameters", UserRole.Admin, Modules.Parameters.ToString()),
                new RoleModule("RoleModule::Admin.Dossiers", UserRole.Admin, Modules.Dossiers.ToString()),
                new RoleModule("RoleModule::Admin.AgendaCommercial", UserRole.Admin, Modules.AgendaCommercial.ToString()),
                new RoleModule("RoleModule::Admin.Devis", UserRole.Admin, Modules.Devis.ToString()),
                new RoleModule("RoleModule::Admin.Facture", UserRole.Admin, Modules.Facture.ToString()),
                new RoleModule("RoleModule::Admin.Avoir", UserRole.Admin, Modules.Avoir.ToString()),
                new RoleModule("RoleModule::Admin.Paiement", UserRole.Admin, Modules.Paiement.ToString()),
                new RoleModule("RoleModule::Admin.Accounting", UserRole.Admin, Modules.Accounting.ToString()),
                new RoleModule("RoleModule::Admin.CategoryProduct", UserRole.Admin, Modules.CategoryProduct.ToString()),
                new RoleModule("RoleModule::Admin.ModesReglement", UserRole.Admin, Modules.ModesReglement.ToString()),
                new RoleModule("RoleModule::Admin.BankAccount", UserRole.Admin, Modules.BankAccount.ToString()),
                new RoleModule("RoleModule::Admin.AgendaParametrage", UserRole.Admin, Modules.AgendaParametrage.ToString()),
                new RoleModule("RoleModule::Admin.ModeleSms", UserRole.Admin, Modules.ModeleSms.ToString()),
                new RoleModule("RoleModule::Admin.TypeChauffage", UserRole.Admin, Modules.TypeChauffage.ToString()),
                new RoleModule("RoleModule::Admin.TypeLogement", UserRole.Admin, Modules.TypeLogement.ToString()),
                new RoleModule("RoleModule::Admin.ChampsSiteInstallation", UserRole.Admin, Modules.ChampsSiteInstallation.ToString()),
                new RoleModule("RoleModule::Admin.BonCommande", UserRole.Admin, Modules.BonCommande.ToString()),

            #endregion

            #region AdminAgence

                new RoleModule("RoleModule::AdminAgence.Home", UserRole.AdminAgence, Modules.Home.ToString()),
                new RoleModule("RoleModule::AdminAgence.DashboardCommercial", UserRole.AdminAgence, Modules.DashboardCommercial.ToString()),
                new RoleModule("RoleModule::AdminAgence.DashboardProduction", UserRole.AdminAgence, Modules.DashboardProduction.ToString()),
                new RoleModule("RoleModule::AdminAgence.Clients", UserRole.AdminAgence, Modules.Clients.ToString()),
                new RoleModule("RoleModule::AdminAgence.Fournisseurs", UserRole.AdminAgence, Modules.Fournisseurs.ToString()),
                new RoleModule("RoleModule::AdminAgence.Users", UserRole.AdminAgence, Modules.Users.ToString()),
                new RoleModule("RoleModule::AdminAgence.Produits", UserRole.AdminAgence, Modules.Produits.ToString()),
                new RoleModule("RoleModule::AdminAgence.Parameters", UserRole.AdminAgence, Modules.Parameters.ToString()),
                new RoleModule("RoleModule::AdminAgence.Dossiers", UserRole.AdminAgence, Modules.Dossiers.ToString()),
                new RoleModule("RoleModule::AdminAgence.AgendaCommercial", UserRole.AdminAgence, Modules.AgendaCommercial.ToString()),
                new RoleModule("RoleModule::AdminAgence.Devis", UserRole.AdminAgence, Modules.Devis.ToString()),
                new RoleModule("RoleModule::AdminAgence.Facture", UserRole.AdminAgence, Modules.Facture.ToString()),
                new RoleModule("RoleModule::AdminAgence.Avoir", UserRole.AdminAgence, Modules.Avoir.ToString()),
                new RoleModule("RoleModule::AdminAgence.Paiement", UserRole.AdminAgence, Modules.Paiement.ToString()),
                new RoleModule("RoleModule::AdminAgence.Accounting", UserRole.AdminAgence, Modules.Accounting.ToString()),
                new RoleModule("RoleModule::AdminAgence.BankAccount", UserRole.AdminAgence, Modules.BankAccount.ToString()),
                new RoleModule("RoleModule::AdminAgence.BonCommande", UserRole.Admin, Modules.BonCommande.ToString()),

            #endregion

            #region Directeur

                new RoleModule("RoleModule::Directeur.Home", UserRole.Directeur, Modules.Home.ToString()),
                new RoleModule("RoleModule::Directeur.DashboardCommercial", UserRole.Directeur, Modules.DashboardCommercial.ToString()),
                new RoleModule("RoleModule::Directeur.DashboardProduction", UserRole.Directeur, Modules.DashboardProduction.ToString()),
                new RoleModule("RoleModule::Directeur.Clients", UserRole.Directeur, Modules.Clients.ToString()),
                new RoleModule("RoleModule::Directeur.Fournisseurs", UserRole.Directeur, Modules.Fournisseurs.ToString()),
                new RoleModule("RoleModule::Directeur.Produits", UserRole.Directeur, Modules.Produits.ToString()),
                new RoleModule("RoleModule::Directeur.Dossiers", UserRole.Directeur, Modules.Dossiers.ToString()),
                new RoleModule("RoleModule::Directeur.AgendaCommercial", UserRole.Directeur, Modules.AgendaCommercial.ToString()),
                new RoleModule("RoleModule::Directeur.Devis", UserRole.Directeur, Modules.Devis.ToString()),
                new RoleModule("RoleModule::Directeur.Facture", UserRole.Directeur, Modules.Facture.ToString()),
                new RoleModule("RoleModule::Directeur.Avoir", UserRole.Directeur, Modules.Avoir.ToString()),
                new RoleModule("RoleModule::Directeur.Paiement", UserRole.Directeur, Modules.Paiement.ToString()),
                new RoleModule("RoleModule::Directeur.BonCommande", UserRole.Admin, Modules.BonCommande.ToString()),

            #endregion

            #region Commercial

                new RoleModule("RoleModule::Commercial.Home", UserRole.Commercial, Modules.Home.ToString()),
                new RoleModule("RoleModule::Commercial.DashboardCommercial", UserRole.Commercial, Modules.DashboardCommercial.ToString()),
                new RoleModule("RoleModule::Commercial.Clients", UserRole.Commercial, Modules.Clients.ToString()),
                new RoleModule("RoleModule::Commercial.Produits", UserRole.Commercial, Modules.Produits.ToString()),
                new RoleModule("RoleModule::Commercial.Dossiers", UserRole.Commercial, Modules.Dossiers.ToString()),
                new RoleModule("RoleModule::Commercial.AgendaCommercial", UserRole.Commercial, Modules.AgendaCommercial.ToString()),
                new RoleModule("RoleModule::Commercial.Devis", UserRole.Commercial, Modules.Devis.ToString()),
                new RoleModule("RoleModule::Commercial.BonCommande", UserRole.Admin, Modules.BonCommande.ToString()),

            #endregion

            #region Controleur

                new RoleModule("RoleModule::Controleur.DashboardCommercial", UserRole.Controleur, Modules.DashboardCommercial.ToString()),
                new RoleModule("RoleModule::Controleur.Clients", UserRole.Controleur, Modules.Clients.ToString()),
                new RoleModule("RoleModule::Controleur.Produits", UserRole.Controleur, Modules.Produits.ToString()),
                new RoleModule("RoleModule::Controleur.Dossiers", UserRole.Controleur, Modules.Dossiers.ToString()),
                new RoleModule("RoleModule::Controleur.AgendaCommercial", UserRole.Controleur, Modules.AgendaCommercial.ToString()),
                new RoleModule("RoleModule::Controleur.Devis", UserRole.Controleur, Modules.Devis.ToString()),
                new RoleModule("RoleModule::Controleur.BonCommande", UserRole.Admin, Modules.BonCommande.ToString()),

            #endregion

            #region Technicien

                new RoleModule("RoleModule::Technicien.Clients", UserRole.Technicien, Modules.Clients.ToString()),
                new RoleModule("RoleModule::Technicien.Dossiers", UserRole.Technicien, Modules.Dossiers.ToString()),
                new RoleModule("RoleModule::Technicien.AgendaCommercial", UserRole.Technicien, Modules.AgendaCommercial.ToString()),
                new RoleModule("RoleModule::Technicien.Devis", UserRole.Technicien, Modules.Devis.ToString()),
                new RoleModule("RoleModule::Technicien.BonCommande", UserRole.Admin, Modules.BonCommande.ToString())

            #endregion

            );
        }
    }

}
