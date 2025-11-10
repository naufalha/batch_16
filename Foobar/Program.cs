using System;

public class Program
{
    public static void Main(string[] args)
    {
        int batasAkhir = 105;

        Console.WriteLine($"---  FooBarJazz (Sampai Angka {batasAkhir}) ---");

        for (int x = 1; x <= batasAkhir; x++)
        {
            string hasilKombo = "";

            if (x % 3 == 0)
            {
                hasilKombo += "foo";
            }

            if (x % 5 == 0)
            {
                hasilKombo += "bar";
            }

            if (x % 7 == 0)
            {
                hasilKombo += "jazz";
            }

            if (hasilKombo.Length > 0)
            {
                Console.WriteLine(hasilKombo);
            }
            else
            {
                Console.WriteLine(x);
            }
        }
    }
}