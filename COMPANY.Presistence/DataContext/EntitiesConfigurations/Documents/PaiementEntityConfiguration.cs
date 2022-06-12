namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Documents
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Domain.Enums.Documents;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <summary>
    /// the entity <see cref="Paiement"/> database Configuration
    /// </summary>
    class PaiementEntityConfiguration : IEntityTypeConfiguration<Paiement>
    {
        public void Configure(EntityTypeBuilder<Paiement> builder)
        {
            // properties
            builder
                .Property(e => e.Description)
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Historique)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<ChangesHistory>>()
                )
                .HasColumnType("LONGTEXT");

            // relationships
            builder
                .HasOne(e => e.Avoir)
                .WithMany(e => e.Paiements)
                .HasForeignKey(e => e.AvoirId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(e => e.RegulationMode)
                .WithMany(e => e.Paiements)
                .HasForeignKey(e => e.RegulationModeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.BankAccount)
                .WithMany(e => e.Paiements)
                .HasForeignKey(e => e.BankAccountId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Agence)
                .WithMany(e => e.Paiements)
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
