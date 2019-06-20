using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FC.SC.AccountManager.Platform.Domain.Accounts;
using Moq;
using Xunit;

namespace FC.SC.AccountManager.Tests
{
    public class AccountDomainTest
    {
        [Theory]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(600)]
        [InlineData(0)]
        public async Task Create_Account_Should_Succeed(decimal value)
        {
            // Arrange
            List<Account> accounts = new List<Account>();
            var account = Account.Create(value);
            var accountRepoMoq = new Mock<IAccountRepository>();
            accountRepoMoq.Setup(ac => ac.AddAsync(It.IsAny<Account>(), It.IsAny<CancellationToken>()))
                .Callback<Account, CancellationToken>((ac, ct) => accounts.Add(ac))
                .Returns(Task.CompletedTask);

            // Act
            var task = Task.Run(() =>
            {
                accountRepoMoq.Object.AddAsync(account);
                accountRepoMoq.Object.SaveChangesAsync();
            });
            Exception ex = await Record.ExceptionAsync(async () => await task);

            // Assert
            Assert.Null(ex);
        }

        [Theory]
        [InlineData(100, 50, 50)]
        [InlineData(500, 49.9, 450.1)]
        [InlineData(600, 289, 311)]
        public void Transfer_Account_Should_Decrease_Balance(decimal balance, decimal value, decimal total)
        {
            // Arrange
            var account = Account.Create(balance);
            var relatedAccount = Account.Create(0);

            // Act
            var entry = account.Transfer(relatedAccount, value);

            // Assert
            Assert.NotNull(entry);
            Assert.Equal(entry.Value, value);
            Assert.Equal(account.Balance, total);
        }

        [Fact]
        public void Transfer_Account_With_No_Balance_Should_Fail()
        {
            // Arrange
            var balance = 10;
            var value = 50;
            var account = Account.Create(balance);
            var relatedAccount = Account.Create(0);

            // Act
            Action task = () => account.Transfer(relatedAccount, value);

            // Assert
            Assert.Throws<InvalidOperationException>(task);
        }

        [Theory]
        [InlineData(100, 50, 150)]
        [InlineData(500, 49.9, 549.9)]
        [InlineData(600, 211, 811)]
        public void Deposit_Account_Should_Increase_Balancec(decimal balance, decimal value, decimal total)
        {
            // Arrange
            var account = Account.Create(balance);
            var relatedAccount = Account.Create(0);

            // Act
            var entry = account.Deposit(relatedAccount, value);

            // Assert
            Assert.NotNull(entry);
            Assert.Equal(entry.Value, value);
            Assert.Equal(account.Balance, total);
        }
    }
}
