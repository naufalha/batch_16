using NUnit.Framework;
using Banking.Domain;

namespace Banking.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Constructor_WithInitialBalance_SetsBalanceCorrectly()
        {
            // Arrange
            decimal initialBalance = 100m;

            // Act
            var account = new BankAccount(initialBalance);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(100m));
        }
    }
}