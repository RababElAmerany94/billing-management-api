namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Parameters
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// the entity <see cref="SourceDuLead"/> database Configuration
    /// </summary>
    internal class SourceDuLeadEntityConfiguration : IEntityTypeConfiguration<SourceDuLead>
    {
        public void Configure(EntityTypeBuilder<SourceDuLead> builder)
        {
            //builder.ToTable("SourceDuLead");
        }
    }
}
