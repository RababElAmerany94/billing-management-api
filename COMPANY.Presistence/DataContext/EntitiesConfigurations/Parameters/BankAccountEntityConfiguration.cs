namespace COMPANY.Presistence.DataContext.EntitiesConfigurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using COMPANY.Domain.Entities;

    public class BankAccountEntityConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            // configuration relationships
            builder.HasOne(e=>e.Agence)
                .WithMany()
                .HasForeignKey(e=> e.AgenceId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new BankAccount[] {
                new BankAccount()
                {
                    Id = "BankAccount::1",
                    Type = Domain.Enums.BankAccountType.Caisse,
                    CodeComptable ="44553",
                    IsModify = false,
                    Name = "Caisse"
                }
            });
        }
    }
}
