using NUnit.Framework;
using Banking.Domain;
using System;
using Moq;
namespace Banking.Tests
{
    [TestFixture]
    public class BankAccountTests
    {
        //buat object mock 
        private Mock<ILogger> _mockLogger;
        private Mock<IFraudService> _mockFraud;


        [SetUp]//akan dijalan setiap test
        public void SetUp()
        {
            //setiap test dijlankan kita siapkan mock (stundmaan baru) 
            _mockLogger = new Mock<ILogger>();
            _mockFraud = new Mock<IFraudService>();
        
        }

        [Test]
        public void Constructor_WithInitialBalance_SetsBalanceCorrectly()
        {
            //suntikan (inject mock loggoer ke dalam akun bank)
            // Arrange
            decimal initialBalance = 100m;

            // Act
            var account = new BankAccount(initialBalance,_mockLogger.Object,_mockFraud.Object);

            // Assert
            Assert.That(account.Balance, Is.EqualTo(100m));
        }
        //test baru 1 menggunakan test case untuk berbagai secekanrio
        [TestCase(50,50)] // tarik 50 dari 100 sisa 50
        [TestCase(100,0)]
        [TestCase(90,10)]
        [TestCase(10,90)]
        
    
        

        public void Wtihdraw_ValidAmount_DecreasesBalance(decimal amount, decimal expectedBalance)
        {
            // Arrange
            var account = new BankAccount(100m,_mockLogger.Object,_mockFraud.Object);
            // Act
            account.Withdraw(amount);
            // Assert
            Assert.That(account.Balance, Is.EqualTo(expectedBalance));
        }

        


        [Test]
        public void Withdraw_InvalidAmount_ThrowsException()
        {
            // Arrange
            var account = new BankAccount(50m,_mockLogger.Object, _mockFraud.Object);
            // Act and asserd
            //kita mengharpakan operasi ini gagal dengaiinfaolid operation
            Assert.Throws<InvalidOperationException>(() => account.Withdraw(100m));
        }

        //test baru untuk mocking
        [Test]
        public void Withdraw_ValidAmount_LogsTransaction()
        {
            //aragne
            var account = new BankAccount(100m, _mockLogger.Object,_mockFraud.Object);
            //act
            account.Withdraw(50m);
            //assert
            _mockLogger.Verify( x => x.Log("Penarikan berhasil: 50"), Times.Once());
        }
        //testing depo
        [Test]
        public void Deposit_ValidAmount_IncreasesBalance()
        {
            // Arrange
            var account = new BankAccount(50m, _mockLogger.Object, _mockFraud.Object);
            // Act
            account.Deposit(100m);
            // Assert
            Assert.That(account.Balance, Is.EqualTo(150m));
            
        }

        //test baru untuk transfer
        [Test]
        public void Transfer_HighValue_WhenFraudServiceApprove_Succeeds()
        {
            //arrange 
            var sender = new BankAccount(10000m, _mockLogger.Object, _mockFraud.Object);
            var receiver = new BankAccount(0m, _mockLogger.Object, _mockFraud.Object);

            //mocingk behaviour 
            //hei mock kalau ada yang tanya istransfer allowd dengan angka berapa pun jawab true boleh
            _mockFraud.Setup(x => x.IsTransferAllowed(It.IsAny<int>(), It.IsAny<decimal>()))
              .Returns(true); // [cite: 433, 438]

            //act
            sender.Transfer(receiver, 6000m);

            //assert
            Assert.That(sender.Balance, Is.EqualTo(4000m));

        }

        [Test]
        public void Transfer_HighValue_WhenFraudServiceRejects_ThrowException()
        {
            //arrange
            var sender = new BankAccount(1000m, _mockLogger.Object, _mockFraud.Object);
            var receiver = new BankAccount(0m, _mockLogger.Object, _mockFraud.Object);

            //mocking behaviour
            _mockFraud.Setup(x => x.IsTransferAllowed(It.IsAny<int>(), It.IsAny<decimal>()))
                        .Returns(false);

            //act and assert
            var ex = Assert.Throws<InvalidOperationException>(() => sender.Transfer(receiver, 6000m));
    
             Assert.That(ex.Message, Does.Contain("Transfer ditolak"));
            Assert.That(sender.Balance, Is.EqualTo(1000m)); // Saldo aman, tidak berkurang
            
        }





    }
}