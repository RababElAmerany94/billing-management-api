namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ConfigMessagerieEntityConfiguration : IEntityTypeConfiguration<ConfigMessagerie>
    {
        public void Configure(EntityTypeBuilder<ConfigMessagerie> builder)
        {
            // setup relations
            builder
                .HasOne(e => e.Agence) 
                .WithMany()
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false);
        }
    }
}
