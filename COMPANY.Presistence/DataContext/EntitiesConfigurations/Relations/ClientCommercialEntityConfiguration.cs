namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Relations
{
    using COMPANY.Domain.Entities.Relations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientCommercialEntityConfiguration : IEntityTypeConfiguration<ClientCommercial>
    {
        public void Configure(EntityTypeBuilder<ClientCommercial> builder)
        {
            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Commercials)
                .HasForeignKey(e => e.ClientId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.Commercial)
                .WithMany(e => e.ClientCommercials)
                .HasForeignKey(e => e.CommercialId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
