namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Relations
{
    using COMPANY.Domain.Entities.Documents;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class FactureDevisEntityConfiguration : IEntityTypeConfiguration<FactureDevis>
    {
        public void Configure(EntityTypeBuilder<FactureDevis> builder)
        {
            builder
                .HasOne(e => e.Facture)
                .WithMany(e => e.Devis)
                .HasForeignKey(e => e.FactureId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Devis)
                .WithMany(e => e.Factures)
                .HasForeignKey(e => e.DevisId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
