namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <summary>
    /// the entity <see cref="EchangeCommercial"/> database Configuration
    /// </summary>
    public class EchangeCommercialEntityConfiguration : IEntityTypeConfiguration<EchangeCommercial>
    {
        public void Configure(EntityTypeBuilder<EchangeCommercial> builder)
        {
            // properties configuration
            builder
                .Property(e => e.Description)
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Memos)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Memo>>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Historique)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<ChangesHistory>>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Contacts)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Contact>>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Addresses)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Address>>()
                )
                .HasColumnType("LONGTEXT");

            // relationships

            builder
                .HasOne(e => e.TacheType)
                .WithMany(e => e.EchangeCommercialsTacheType)
                .HasForeignKey(e => e.TacheTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasOne(e => e.TypeAppel)
               .WithMany(e => e.EchangeCommercialsTypeAppel)
               .HasForeignKey(e => e.TypeAppelId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.RdvType)
                .WithMany(e => e.EchangeCommercialsRdvType)
                .HasForeignKey(e => e.RdvTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Categorie)
                .WithMany(e => e.EchangeCommercialsCategorie)
                .HasForeignKey(e => e.CategorieId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.SourceRDV)
                .WithMany(e => e.EchangeCommercialsSourceRDV)
                .HasForeignKey(e => e.SourceRDVId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.EchangeCommercials)
                .HasForeignKey(e => e.ClientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Responsable)
                .WithMany(e => e.EchangeCommercials)
                .HasForeignKey(x => x.ResponsableId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Dossier)
                .WithMany(e => e.EchangeCommercials)
                .HasForeignKey(x => x.DossierId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(e => e.Agence)
                .WithMany(e => e.EchangeCommercials)
                .HasForeignKey(x => x.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Createur)
                .WithMany(e => e.EchangeCommercialsCreateurs)
                .HasForeignKey(x => x.CreateurId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
