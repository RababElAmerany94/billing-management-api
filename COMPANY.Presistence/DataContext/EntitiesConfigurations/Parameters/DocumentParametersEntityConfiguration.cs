namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// a class describe document parameters entity configuration
    /// </summary>
    public class DocumentParametersEntityConfiguration : IEntityTypeConfiguration<DocumentParameters>
    {
        public void Configure(EntityTypeBuilder<DocumentParameters> builder)
        {
            builder
                .Property(e => e.TVA)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<TvaParameters>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Facture)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<FactureDocumentParameters>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Avoir)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<AvoirDocumentParameters>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Devis)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<DevisDocumentParameters>()
                )
                .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.BonCommande)
               .HasConversion(
                   e => e.ToJson(false, false),
                   e => e.FromJson<BonCommandeParameters>()
               )
               .HasColumnType("LONGTEXT");

            // relationship
            builder.HasOne(e => e.Agence)
                   .WithMany()
                   .HasForeignKey(e => e.AgenceId)
                   .IsRequired(false);
        }
    }
}
