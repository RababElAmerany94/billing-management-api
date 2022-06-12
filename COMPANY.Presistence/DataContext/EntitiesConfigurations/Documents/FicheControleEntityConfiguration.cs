namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Documents
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class FicheControleEntityConfiguration : IEntityTypeConfiguration<FicheControle>
    {
        public void Configure(EntityTypeBuilder<FicheControle> builder)
        {
            builder
               .Property(e => e.Photos)
               .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<PhotoDocument>>()
                )
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.ConstatCombles)
               .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ConstatCombles>()
                )
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.ConstatPlanchers)
               .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ConstatPlanchers>()
                )
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.ConstatMurs)
              .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ConstatMurs>()
                )
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.Remarques)
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.SignatureController)
               .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.SignatureClient)
               .HasColumnType("LONGTEXT");

            // relationships
            builder.HasOne(e => e.Controller)
                .WithMany(e => e.FicheControles)
                .HasForeignKey(e => e.ControllerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
