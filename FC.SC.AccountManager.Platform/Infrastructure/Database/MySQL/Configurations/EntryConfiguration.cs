using FC.SC.AccountManager.Platform.Domain.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL.Configurations
{
    public class EntryConfiguration : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            var enumConverter = new EnumToStringConverter<OperationType>();

            builder.ToTable("entries").HasIndex(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").IsRequired();
            builder.Property(e => e.AccountId).HasColumnName("account_id").IsRequired();
            builder.Property(e => e.RelatedAccountId).HasColumnName("related_account_id").IsRequired();
            builder.Property(e => e.OperationType).HasColumnName("operation_type").IsRequired().HasConversion(enumConverter);
            builder.Property(e => e.Value).HasColumnName("value").IsRequired().HasColumnType("decimal(7,2)");
            builder.Property(e => e.CreatedAt).HasColumnName("created_at").IsRequired()
                .HasColumnType("datetime").HasDefaultValueSql("now()");
        }
    }
}
