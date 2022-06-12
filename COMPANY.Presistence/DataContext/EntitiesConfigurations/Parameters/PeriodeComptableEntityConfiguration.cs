namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using COMPANY.Domain.Entities;

    public class PeriodeComptableEntityConfiguration : IEntityTypeConfiguration<PeriodeComptable>
    {
        public void Configure(EntityTypeBuilder<PeriodeComptable> builder)
        {
            // relationships
            builder.HasOne(e => e.Agence)
                   .WithMany()
                   .HasForeignKey(e => e.AgenceId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.User)
                   .WithMany()
                   .HasForeignKey(e => e.UserId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
