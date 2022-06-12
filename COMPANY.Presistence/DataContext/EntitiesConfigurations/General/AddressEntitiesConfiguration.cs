namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DepartementEntityConfiguration : IEntityTypeConfiguration<Departement>
    {
        public void Configure(EntityTypeBuilder<Departement> builder)
        {
            builder.HasOne(e => e.Country)
                .WithMany(d => d.Departements)
                .HasForeignKey(e => e.CountryId)
                .IsRequired(false);
        }
    }
}
