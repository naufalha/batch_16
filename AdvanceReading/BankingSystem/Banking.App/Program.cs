using System;
using Banking.Domain;
using Serilog;
class Program
{
    static void Main(string[] args)
    {
        // konfigurasi serilog
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log_banking.json",rollingInterval: RollingInterval.Day )
            .CreateLogger();
        
        //create adapter logger
        Banking.Domain.ILogger loggerAsli = new SerilogAdapter();
        IFraudService fraudService = new FakeFraudService();

        //depedency injection
        var MilosAccount = new BankAccount(1000m, loggerAsli, fraudService);
        Console.WriteLine($"Saldo awal: {MilosAccount.Balance}");


        //tentukan mau disimpan mana
        string lokasiFile = "log_transaksi.txt";
        //2.buat logger asli bukan moccking
        //ILogger loggerAsli = new FileLogger(lokasiFile);
        //3.buat akun bank
        //bank akun tidak peduli asli atau palsu)
        var myAccount = new BankAccount(1000m, loggerAsli,fraudService);
        Console.WriteLine($"Saldo awal: {myAccount.Balance}");
        myAccount.Withdraw(500m);
        Console.WriteLine($"Saldo akhir: {myAccount.Balance}");

        try
        {
            Console.WriteLine("sedang menarik 200");
            myAccount.Withdraw(200m);

            MilosAccount.Withdraw(200m);
            Console.WriteLine("selesai silahkan cek log file");
            MilosAccount.Withdraw(200m);


            Console.WriteLine("sedang menarik 300");
            myAccount.Withdraw(300m);
            Console.WriteLine("selesai silahkan cek log file");
        }
        catch (InvalidOperationException ex)
        {
            loggerAsli.Log(ex.Message);
            Console.WriteLine(ex.Message);
        }
    }
    
}