﻿using System;
using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain.Models;

namespace FC.SC.AccountManager.Platform.Infrastructure.Services.Blockchain
{
    public class EntryBlockchainService : IEntryBlockchainService
    {
        readonly IEntryBlockchainRepository _repository;

        public EntryBlockchainService(IEntryBlockchainRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<EntryBlockchain> GetBlockchain()
        {
            return await _repository.GetBlockchain();
        }

        public async Task AddBlock(Block block)
        {
            var blockchain = await GetBlockchain();

            if (blockchain == null)
            {
                blockchain = new EntryBlockchain();
                blockchain.AddBlock(block);
                await _repository.Create(blockchain);
            }
            else
            {
                blockchain.AddBlock(block);
                await _repository.Update(blockchain);
            }
        }
    }
}
