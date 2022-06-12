namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Parameters
{
    using COMPANY.Domain.Entities.Parameters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LogementTypeEntityConfiguration : IEntityTypeConfiguration<LogementType>
    {
        public void Configure(EntityTypeBuilder<LogementType> builder)
        {
            builder.HasData(new LogementType[] {
                new LogementType(){ Id= "LogementType::1", Name="Appartement" },
                new LogementType(){ Id= "LogementType::2", Name="Maison" },
            });
        }
    }
}
