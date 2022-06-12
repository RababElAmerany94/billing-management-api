namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    public class ProduitEntitiesConfiguration : IEntityTypeConfiguration<Produit>
    {
        public void Configure(EntityTypeBuilder<Produit> builder)
        {
            builder
                .Property(e => e.Description)
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.PrixParTranche)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<PrixParQuantite>>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Labels)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<string>>()
                )
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

            // relations
            builder
                .HasOne(e => e.Agence)
                .WithMany(e => e.Produits)
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Fournisseur)
                .WithMany(e => e.Produits)
                .HasForeignKey(e => e.FournisseurId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasOne(e => e.Category)
                .WithMany(e => e.Produits)
                .HasForeignKey(e => e.CategoryId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(c => c.PrixProduitParAgences)
                .WithOne(e => e.Produit)
                .IsRequired(false);
        }
    }

    public class PrixProduitParAgenceEntityConfiguration : IEntityTypeConfiguration<PrixProduitParAgence>
    {
        public void Configure(EntityTypeBuilder<PrixProduitParAgence> builder)
        {
            // relations 
            builder
                .HasOne(e => e.Produit)
                .WithMany(e => e.PrixProduitParAgences)
                .HasForeignKey(e => e.ProduitId)
                .IsRequired(false);

            builder
                .HasOne(e => e.Agence)
                .WithMany(e => e.PrixProduitParAgences)
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false);
        }
    }
}
