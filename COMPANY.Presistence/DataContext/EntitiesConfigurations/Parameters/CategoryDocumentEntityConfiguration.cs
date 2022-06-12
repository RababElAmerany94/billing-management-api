using COMPANY.Domain.Entities.Parameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    /// <summary>
    /// the entity <see cref="CategoryDocuments"/> database Configuration
    /// </summary>
    public class CategoryDocumentEntityConfiguration : IEntityTypeConfiguration<CategoryDocuments>
    {
        public void Configure(EntityTypeBuilder<CategoryDocuments> builder)
        {}
    }
}
