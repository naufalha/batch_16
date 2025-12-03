using System;
using Banking.Domain;

class Program
{
    static void Main(string[] args)
    {
        //tentukan mau disimpan mana
        string lokasiFile = "log_transaksi.txt";
        //2.buat logger asli bukan moccking
        ILogger loggerAsli = new FileLogger(lokasiFile);
        //3.buat akun bank
        //bank akun tidak peduli asli atau palsu)
        var myAccount = new BankAccount(1000m, loggerAsli);
        Console.WriteLine($"Saldo awal: {myAccount.Balance}");
        myAccount.Withdraw(500m);
        Console.WriteLine($"Saldo akhir: {myAccount.Balance}");

        try
        {
            Console.WriteLine("sedang menarik 200");
            myAccount.Withdraw(200m);


            Console.WriteLine("sedang menarik 300");
            myAccount.Withdraw(300m);
            Console.WriteLine("selesai silahkan cek log file");
        }
        catch (InvalidOperationException ex)
        {
        }
    }
    
}