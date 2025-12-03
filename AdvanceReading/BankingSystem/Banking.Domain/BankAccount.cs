using System;
using Banking.Domain;
namespace Banking.Domain    
{
    public class BankAccount
    {
        //tambahkan id primerray key
        public int Id{ get; private set;}
        public decimal Balance { get; private set; }
        public readonly ILogger _logger;
        private readonly IFraudService _fraudService; // Tambah ini
        
            public BankAccount(decimal initialBalance, ILogger logger, IFraudService fraudService)
            {
                Balance = initialBalance;
                _logger = logger;
                _fraudService = fraudService; // Simpan dependency
            }

        //withdraw method
        public void Withdraw(decimal amount)
        {
            //penerapan tell dont ask
            //objek ini sendiri menjadga konsistensi datanya
            if (amount > Balance)
            {
                throw new InvalidOperationException("dana tidak mencukupi");
            }
            Balance -= amount;
            //logger mencatat
            _logger.Log($"Penarikan berhasil: {amount}");
        }       

        //deposit
        public void Deposit(decimal amount)
        {
            Balance += amount;
            _logger.Log($"Deposit berhasil: {amount}");
        }   

        public void Transfer(BankAccount destination, decimal amount)
        {
            if (!_fraudService.IsTransferAllowed(this.Id, amount))
            {
                throw new InvalidOperationException("Transfer ditolak terdeteksi fraud");

            }

            this.Withdraw(amount);
            destination.Deposit(amount);
            _logger.Log($"Transfer berhasil: {amount}");
        }
            
    }

    
}