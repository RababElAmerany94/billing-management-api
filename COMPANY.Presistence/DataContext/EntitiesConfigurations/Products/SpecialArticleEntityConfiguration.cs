namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    /// <summary>
    /// an class describe special article entity configuration
    /// </summary>
    public class SpecialArticleEntityConfiguration : IEntityTypeConfiguration<SpecialArticle>
    {
        public void Configure(EntityTypeBuilder<SpecialArticle> builder)
        {
            builder.Property(e => e.Description)
                .HasColumnType("LONGTEXT");
        }
    }
}
