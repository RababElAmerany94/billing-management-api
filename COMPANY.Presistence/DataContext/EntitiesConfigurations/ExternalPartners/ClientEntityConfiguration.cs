namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <summary>
    /// the entity <see cref="Client"/> database Configuration
    /// </summary>
    internal class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            // properties configuration
            builder.Property(e => e.FirstName)
                .HasMaxLength(100);

            builder.Property(e => e.LastName)
                .IsRequired(false)
                .HasMaxLength(100);

            builder.Property(e => e.Memos)
              .HasConversion(
                  e => e.ToJson(false, false),
                  e => e.FromJson<ICollection<Memo>>()
              )
              .HasColumnType("LONGTEXT");

            builder.Property(e => e.Addresses)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Address>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Historique)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<ChangesHistory>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Contacts)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Contact>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.NoteDevis)
                .HasColumnType("LONGTEXT");

            // relationships
            builder.HasOne(e => e.Agence)
                .WithMany()
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.PrimeCEE)
                .WithMany(e => e.Clients)
                .HasForeignKey(e => e.PrimeCEEId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(a => a.RegulationMode)
               .WithMany()
               .HasForeignKey(e => e.RegulationModeId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);

            builder
               .HasOne(e => e.LogementType)
               .WithMany(e => e.Clients)
               .HasForeignKey(e => e.LogementTypeId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.TypeChauffage)
               .WithMany(e => e.Clients)
               .HasForeignKey(e => e.TypeChauffageId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.SourceLead)
                .WithMany(e => e.Clients)
                .HasForeignKey(e => e.SourceLeadId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
