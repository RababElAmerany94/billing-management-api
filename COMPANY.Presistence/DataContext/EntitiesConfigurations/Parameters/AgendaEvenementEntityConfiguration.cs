namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Parameters
{
    using COMPANY.Domain.Entities.Parameters;
    using Domain.Enums.Parameters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AgendaEvenementEntityConfiguration : IEntityTypeConfiguration<AgendaEvenement>
    {
        public void Configure(EntityTypeBuilder<AgendaEvenement> builder)
        {
            builder.HasData(
                new AgendaEvenement[] {
                    new AgendaEvenement(){ Id= "AgendaEvenement::1", Name="Prospection", Type= AgendaEvenementType.Tache },
                    new AgendaEvenement(){ Id= "AgendaEvenement::2", Name="Vérification", Type= AgendaEvenementType.Tache },
                    new AgendaEvenement(){ Id= "AgendaEvenement::3", Name="Planification", Type= AgendaEvenementType.Tache },
                    new AgendaEvenement(){ Id= "AgendaEvenement::4", Name="Tâche", Type= AgendaEvenementType.Tache },
                    new AgendaEvenement(){ Id= "AgendaEvenement::5", Name="Visite de contrôle", Type= AgendaEvenementType.Rdv },
                    new AgendaEvenement(){ Id= "AgendaEvenement::6", Name="Pose", Type= AgendaEvenementType.Rdv },
                    new AgendaEvenement(){ Id= "AgendaEvenement::7", Name="Visite technique", Type= AgendaEvenementType.Rdv },
                    new AgendaEvenement(){ Id= "AgendaEvenement::8", Name="Commercial", Type= AgendaEvenementType.CategorieEvenement },
                    new AgendaEvenement(){ Id= "AgendaEvenement::9", Name="Administratif", Type= AgendaEvenementType.CategorieEvenement },
                    new AgendaEvenement(){ Id= "AgendaEvenement::10", Name="Technique", Type= AgendaEvenementType.CategorieEvenement },
                    new AgendaEvenement(){ Id= "AgendaEvenement::11", Name="Appel", Type= AgendaEvenementType.Appel },
                    new AgendaEvenement(){ Id= "AgendaEvenement::12", Name="rdv perso", Type= AgendaEvenementType.SourceRDV },
                    new AgendaEvenement(){ Id= "AgendaEvenement::13", Name="rdv company", Type= AgendaEvenementType.SourceRDV },
                }
            );
        }
    }
}
