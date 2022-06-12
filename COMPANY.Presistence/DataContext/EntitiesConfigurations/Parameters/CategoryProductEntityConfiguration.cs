namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System;

    /// <summary>
    /// the entity <see cref="CategoryProduct"/> database Configuration
    /// </summary>
    internal class CategoryProductEntityConfiguration : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            //builder.ToTable("CategoryProducts");
        }
    }
}
