using FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL.Configurations;
using FC.SC.AccountManager.Repository;
using Microsoft.EntityFrameworkCore;

namespace FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL
{
    public class AccountManagerContext : BaseContext
    {
        // for EF Migration only
        public AccountManagerContext()
            : base("Server=localhost;Port=3306;Uid=root;Pwd=root;Database=fc.sc.accounts")
        { }

        public AccountManagerContext(IDataSource source)
            : base(source)
        {
            // to ensures the integrity of the database
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // get connstring from BaseContext
            optionsBuilder.UseMySql(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new EntryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
