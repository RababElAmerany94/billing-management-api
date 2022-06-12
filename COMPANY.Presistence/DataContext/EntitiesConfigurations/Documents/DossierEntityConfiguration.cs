namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <summary>
    /// the entity <see cref="Dossier"/> database Configuration
    /// </summary>
    public class DossierEntityConfiguration : IEntityTypeConfiguration<Dossier>
    {
        public void Configure(EntityTypeBuilder<Dossier> builder)
        {
            // properties configuration
            builder
                .Property(e => e.Reference)
                .IsRequired();

            builder
                .Property(e => e.Contact)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<Contact>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.SiteIntervention)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<Address>()
                )
                .HasColumnType("LONGTEXT");

            builder
                .Property(e => e.Memos)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<MemoDossier>>()
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
                .Property(e => e.VisteTechnique)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<VisteTechnique>()
                )
                .HasColumnType("LONGTEXT");

            builder
               .Property(e => e.SiteInstallationInformationsSupplementaire)
               .HasConversion(
                   e => e.ToJson(false, false),
                   e => e.FromJson<Dictionary<string, string>>()
               )
               .HasColumnType("LONGTEXT");

            // relationships
            builder
                .HasOne(e => e.Client)
                .WithMany()
                .HasForeignKey(e => e.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.PrimeCEE)
                .WithMany(e => e.Dossiers)
                .HasForeignKey(e => e.PrimeCEEId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Agence)
                .WithMany(e => e.Dossiers)
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Commercial)
                .WithMany(e => e.Dossiers)
                .HasForeignKey(e => e.CommercialId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.LogementType)
                .WithMany(e => e.Dossiers)
                .HasForeignKey(e => e.LogementTypeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.TypeChauffage)
                .WithMany(e => e.Dossiers)
                .HasForeignKey(e => e.TypeChauffageId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.SourceLead)
                .WithMany(e => e.Dossiers)
                .HasForeignKey(e => e.SourceLeadId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.PremierRdv)
                .WithMany(e => e.PremiersRdvsDossiers)
                .HasForeignKey(e => e.PremierRdvId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }


    /// <summary>
    /// the entity <see cref="DossierInstallation"/> database Configuration
    /// </summary>
    public class DossierInstallationEntityConfiguration : IEntityTypeConfiguration<DossierInstallation>
    {
        public void Configure(EntityTypeBuilder<DossierInstallation> builder)
        {
            builder
                .Property(e => e.Id);

            builder
                .HasOne(e => e.Technicien)
                .WithMany(e=> e.DossierInstallations)
                .HasForeignKey(e => e.TechnicienId)
                .IsRequired(true);

            builder
                .HasOne(e => e.Dossier)
                .WithMany(e => e.DossierInstallations)
                .HasForeignKey(e => e.DossierId)
                .IsRequired(true);
        }
    }
}
