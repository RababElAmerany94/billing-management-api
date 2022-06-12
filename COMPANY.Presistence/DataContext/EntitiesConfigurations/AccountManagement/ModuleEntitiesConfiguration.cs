namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Application.Enums;
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// a class defines configuration of entity Module
    /// </summary>
    public class ModuleEntitiesConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            // seed data
            builder.HasData(new Module[]
            {
                new Module(){ Id = Modules.Home.ToString(), Name="Home" },
                new Module(){ Id = Modules.Clients.ToString(), Name="Clients" },
                new Module(){ Id = Modules.Fournisseurs.ToString(), Name="Fournisseurs" },
                new Module(){ Id = Modules.Agences.ToString(), Name="Agences" },
                new Module(){ Id = Modules.Produits.ToString(), Name="Produits" },
                new Module(){ Id = Modules.Parameters.ToString(), Name="Parameters" },
                new Module(){ Id = Modules.Users.ToString(), Name="Users" },
                new Module(){ Id = Modules.Dossiers.ToString(), Name="Dossiers" },
                new Module(){ Id = Modules.AgendaCommercial.ToString(), Name="Agenda Commercial" },
                new Module(){ Id = Modules.Devis.ToString(), Name="Devis" },
                new Module(){ Id = Modules.Facture.ToString(), Name="Facture" },
                new Module(){ Id = Modules.Avoir.ToString(), Name="Avoir" },
                new Module(){ Id = Modules.Paiement.ToString(), Name="Paiement" },
                new Module(){ Id = Modules.Accounting.ToString(), Name="Accounting" },
                new Module(){ Id = Modules.CategoryProduct.ToString(), Name="Category Product" },
                new Module(){ Id = Modules.ModesReglement.ToString(), Name="Modes Reglement" },
                new Module(){ Id = Modules.BankAccount.ToString(), Name="Bank Account" },
                new Module(){ Id = Modules.AgendaParametrage.ToString(), Name="Agenda Parametrage" },
                new Module(){ Id = Modules.ModeleSms.ToString(), Name="Modele Sms" },
                new Module(){ Id = Modules.TypeChauffage.ToString(), Name="Type Chauffage" },
                new Module(){ Id = Modules.TypeLogement.ToString(), Name="Type Logement" },
                new Module(){ Id = Modules.DashboardCommercial.ToString(), Name="Dashboard Commercial" },
                new Module(){ Id = Modules.DashboardProduction.ToString(), Name="Dashboard Production" },
                new Module(){ Id = Modules.ChampsSiteInstallation.ToString(), Name="Champs Site Installation" },
                new Module(){ Id = Modules.BonCommande.ToString(), Name="Bon commande" },
            });
        }
    }
}
