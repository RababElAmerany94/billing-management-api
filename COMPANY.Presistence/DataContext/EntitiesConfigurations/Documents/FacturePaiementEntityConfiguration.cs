namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Documents
{
    using COMPANY.Domain.Enums.Documents;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class FacturePaiementEntityConfiguration : IEntityTypeConfiguration<FacturePaiement>
    {
        public void Configure(EntityTypeBuilder<FacturePaiement> builder)
        {
            // relationships
            builder
                .HasOne(e => e.Facture)
                .WithMany(m => m.FacturePaiements)
                .HasForeignKey(e => e.FactureId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Paiement)
                .WithMany(m => m.FacturePaiements)
                .HasForeignKey(e => e.PaiementId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
