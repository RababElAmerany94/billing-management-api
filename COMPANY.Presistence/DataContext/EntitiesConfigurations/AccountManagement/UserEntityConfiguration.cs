namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using COMPANY.Domain.Entities;
    using COMPANY.Domain.Entities.OwnedEntities;
    using COMPANY.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using System.Collections.Generic;

    /// <summary>
    /// the entity <see cref="Client"/> database Configuration
    /// </summary>
    internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // properties configuration
            builder.Property(e => e.FirstName)
                .HasMaxLength(50);

            builder.Property(e => e.LastName)
                .HasMaxLength(50);

            builder.Property(e => e.Passwordhash)
                .HasMaxLength(100);

            builder.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Email)
                .HasMaxLength(50);

            builder.Property(e => e.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(e => e.Historique)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<ChangesHistory>>()
                )
                .HasColumnType("LONGTEXT");

            builder.Property(e => e.Memos)
                .HasConversion(
                    e => e.ToJson(false, false),
                    e => e.FromJson<ICollection<Memo>>()
                )
                .HasColumnType("LONGTEXT");

            // index
            builder.HasIndex(e => e.UserName)
                .IsUnique();

            // relationShips
            builder.HasOne(e => e.Agence)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.AgenceId)
                .IsRequired(false);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
        }
    }

}
