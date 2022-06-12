namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NumerotationEntityConfiguration : IEntityTypeConfiguration<Numerotation>
    {
        public void Configure(EntityTypeBuilder<Numerotation> builder) {

            // relationships
            builder.HasOne(e => e.Agence)
                   .WithMany()
                   .HasForeignKey(e => e.AgenceId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
