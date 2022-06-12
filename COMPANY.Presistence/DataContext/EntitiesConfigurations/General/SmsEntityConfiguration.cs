namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.General
{
    using Domain.Entities.Generals;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SmsEntityConfiguration : IEntityTypeConfiguration<Sms>
    {
        public void Configure(EntityTypeBuilder<Sms> builder)
        {
            builder
                .Property(e => e.Message)
                .HasColumnType("LONGTEXT");

            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Sms)
                .HasForeignKey(e => e.ClientId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Dossier)
                .WithMany(e => e.Sms)
                .HasForeignKey(e => e.DossierId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.SmsEnvoye)
                .WithMany(e => e.Reponses)
                .HasForeignKey(e => e.SmsEnvoyeId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
