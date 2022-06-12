namespace COMPANY.Presistence.DataContext.EntitiesConfigurations.Relations
{
    using COMPANY.Domain.Entities.Relations;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class GoogleCalendarEchangeCommercialConfiguration : IEntityTypeConfiguration<GoogleCalendarEchangeCommercial>
    {
        public void Configure(EntityTypeBuilder<GoogleCalendarEchangeCommercial> builder)
        {
            builder
                .HasOne(e => e.EchangeCommercial)
                .WithMany(e => e.GoogleCalendarEvents)
                .HasForeignKey(e => e.EchangeCommercialId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(e => e.User)
                .WithMany(e => e.GoogleCalendarEvents)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
