namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Documents
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class DossierPVEntityConfiguration : IEntityTypeConfiguration<DossierPV>
    {
        public void Configure(EntityTypeBuilder<DossierPV> builder)
        {
            builder
                .Property(e => e.Photos)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<PhotoDocument>>()
                )
                .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.Articles)
               .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Article>>()
                )
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.SignatureClient)
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.SignatureTechnicien)
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.ReasonNoSatisfaction)
               .HasColumnType("LONGTEXT");

            // relationships
            builder
                .HasOne(e => e.Dossier)
                .WithMany(e => e.PVs)
                .HasForeignKey(e => e.DossierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasOne(a => a.FicheControle)
               .WithOne(b => b.DossierPV)
               .HasForeignKey<DossierPV>(b => b.FicheControleId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
