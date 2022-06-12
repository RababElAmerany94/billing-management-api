namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Parameters
{
    using COMPANY.Domain.Entities.Parameters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ModeleSmsEntityConfiguration : IEntityTypeConfiguration<ModeleSms>
    {
        public void Configure(EntityTypeBuilder<ModeleSms> builder)
        {
            builder
                .Property(e => e.Text)
                .HasColumnType("LONGTEXT");
        }
    }
}
