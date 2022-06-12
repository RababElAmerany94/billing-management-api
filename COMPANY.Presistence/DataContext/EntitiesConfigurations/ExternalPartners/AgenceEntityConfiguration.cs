namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class AgenceEntityConfiguration : IEntityTypeConfiguration<Agence>
    {
        public void Configure(EntityTypeBuilder<Agence> builder)
        {
            // properties configuration
            builder.Property(e => e.Historique)
               .HasConversion(
                   e => e.ToJson(false, false),
                   e => e.FromJson<ICollection<ChangesHistory>>()
               )
               .HasColumnType("LONGTEXT");

            builder.Property(e => e.AdressesFacturation)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Address>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.AdressesLivraison)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Address>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Memos)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Memo>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Contacts)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Contact>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.RegulationModeId)
                .IsRequired(false);

            // relationships
            builder.HasOne(a => a.AgenceLogin)
                .WithOne(u => u.AgenceLogin)
                .HasForeignKey<Agence>(e => e.AgenceLoginId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }

        /// <summary>
        /// get the assembly for registering the configuration
        /// </summary>
        /// <returns><see cref="System.Reflection.Assembly"/></returns>
        public static System.Reflection.Assembly GetAssembly() 
            => typeof(AgenceEntityConfiguration).Assembly;
    }
}
