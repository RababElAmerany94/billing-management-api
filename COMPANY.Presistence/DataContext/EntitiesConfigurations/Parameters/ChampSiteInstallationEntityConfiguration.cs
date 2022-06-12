namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Parameters
{
    using COMPANY.Domain.Entities.Parameters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ChampSiteInstallationEntityConfiguration : IEntityTypeConfiguration<ChampSiteInstallation>
    {
        public void Configure(EntityTypeBuilder<ChampSiteInstallation> builder)
        {
            builder
                .HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}
