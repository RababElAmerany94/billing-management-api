namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class FournisseurEntityConfiguration : IEntityTypeConfiguration<Fournisseur>
    {
        public void Configure(EntityTypeBuilder<Fournisseur> builder)
        {
            // properties configuration
            builder.Property(e => e.RaisonSociale)
                .IsRequired(true);

            builder.Property(e => e.Historique)
               .HasConversion(
                   e => e.ToJson(false, false),
                   e => e.FromJson<ICollection<ChangesHistory>>()
               )
               .HasColumnType("LONGTEXT");

            builder.Property(e => e.Addresses)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Address>>()
                )
               .HasColumnType("LONGTEXT");

            builder.Property(e => e.Contacts)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Contact>>()
                )
               .HasColumnType("LONGTEXT");

            builder.HasOne(e => e.Agence)
                .WithMany()
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
