using System;
using FC.SC.AccountManager.Platform.Application.Accounts;
using FC.SC.AccountManager.Platform.Domain.Accounts;
using FC.SC.AccountManager.Platform.Infrastructure.Database.Mongo.Repositories;
using FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL;
using FC.SC.AccountManager.Platform.Infrastructure.Database.MySQL.Repositories;
using FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain;
using FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain.Models;
using FC.SC.AccountManager.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FC.SC.AccountManager.Platform.Infrastructure.IOC
{
    public class AccountManagerModule
    {
        public AccountManagerModule(IConfiguration configuration)
            : this(new ServiceCollection(), configuration)
        { }

        public AccountManagerModule(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // data source
            services.AddScoped<IDataSource>(provider =>
                new DefaultDataSource(configuration, "DefaultSQL"));

            // unit of work
            services.AddScoped<IUnitOfWorkAsync, AccountManagerContext>();

            // services
            services.AddScoped<IEntryBlockchainService, EntryBlockchainService>();

            // repositories
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IEntryBlockchainRepository>(provider =>
                new EntryBlockchainRepository(configuration.GetConnectionString("DefaultNoSQL"),
                configuration.GetValue<string>("MongoDb:Database"),
                configuration.GetValue<string>("MongoDb:Collection")));

            // app services
            services.AddScoped<IAccountAppService, AccountAppService>();
        }
    }
}
