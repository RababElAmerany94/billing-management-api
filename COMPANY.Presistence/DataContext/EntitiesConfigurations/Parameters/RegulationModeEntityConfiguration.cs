namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    class RegulationModeEntityConfiguration : IEntityTypeConfiguration<RegulationMode>
    {
        public void Configure(EntityTypeBuilder<RegulationMode> builder)
        {
            builder.HasData(new RegulationMode[]
            {
                new RegulationMode()
                {
                    Id = "RegulationMode::1",
                    Name="Carte bancaire",
                    IsModify = true
                },
                new RegulationMode()
                {
                    Id = "RegulationMode::2",
                    Name="Chèque",
                    IsModify = true
                },
                new RegulationMode()
                {
                    Id = "RegulationMode::3",
                    Name="Espèces",
                    IsModify = true
                },
                new RegulationMode()
                {
                    Id = "RegulationMode::4",
                    Name="Paypal",
                    IsModify = true
                },
                new RegulationMode()
                {
                    Id = "RegulationMode::5",
                    Name="Prélevèment",
                    IsModify = true
                },
                new RegulationMode()
                {
                    Id = "RegulationMode::6",
                    Name="Virement",
                    IsModify = true
                },
                new RegulationMode()
                {
                    Id = "RegulationMode::7",
                    Name="Avoir",
                    IsModify = false
                }
            });
        }
    }
}
