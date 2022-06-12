namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Documents
{
    using COMPANY.Domain.Entities.Documents;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <summary>
    /// the entity <see cref="Avoir"/> database Configuration
    /// </summary>
    class AvoirEntityConfiguration : IEntityTypeConfiguration<Avoir>
    {
        public void Configure(EntityTypeBuilder<Avoir> builder)
        {
            // properties configuration
            builder.Property(e => e.Articles)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Article>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.ReglementCondition)
                   .HasColumnType("LONGTEXT");

            builder.Property(e => e.Note)
                   .HasColumnType("LONGTEXT");

            builder.Property(e => e.Historique)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<ChangesHistory>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Memos)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Memo>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Emails)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<MailHistoryModel>>()
                )
                .HasColumnType("LONGTEXT");

            // relation configuration
            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Avoirs)
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Agence)
                .WithMany(e => e.Avoirs)
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Facture)
                .WithMany(e => e.Avoirs)
                .HasForeignKey(e => e.FactureId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
