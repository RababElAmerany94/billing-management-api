namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Relations
{
    using COMPANY.Domain.Entities.Relations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ClientRelationEntityConfiguration : IEntityTypeConfiguration<ClientRelation>
    {
        public void Configure(EntityTypeBuilder<ClientRelation> builder)
        {
            builder
                .HasOne(e => e.Client)
                .WithMany(e => e.Relations)
                .HasForeignKey(e => e.ClientId)
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
