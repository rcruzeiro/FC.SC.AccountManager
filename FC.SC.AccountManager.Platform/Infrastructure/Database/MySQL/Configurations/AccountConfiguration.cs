using FC.SC.AccountManager.Platform.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("accounts").HasIndex(ac => ac.Id);
            builder.Property(ac => ac.Id).HasColumnName("id").IsRequired();
            builder.Property(ac => ac.Balance).HasColumnName("balance").IsRequired().HasColumnType("decimal(7,2)");
            builder.Property(ac => ac.CreatedAt).HasColumnName("created_at").IsRequired()
                .HasColumnType("datetime").HasDefaultValueSql("now()");
            builder.Property(ac => ac.UpdatedAt).HasColumnName("updated_at").HasColumnType("datetime");

            // navigation (has to be navigation field because entries list is read-only)
            var navigation =
                builder.Metadata.FindNavigation(nameof(Account.Entries));

            // ef access the entries collection property through its backing field
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            // relationships
            builder.HasMany(ac => ac.Entries)
                .WithOne()
                .HasForeignKey(e => e.AccountId);
        }
    }
}
