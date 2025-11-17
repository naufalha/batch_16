using System;
using System.Text;

public class Program
{
    public static void Main(string[] args)
    {
        int batasAkhir = 105;

        Console.WriteLine($"--- Combo Output Sampai Angka {batasAkhir} ---");

        for (int x = 1; x <= batasAkhir; x++)
        {
            StringBuilder sb = new StringBuilder();

            // Switch-case appending each string to a setring builder object
            switch (true)
            {
                case bool when x % 3 == 0:
                    sb.Append("foo");
                    break;
            }

            switch (true)
            {
                case bool when x % 4 == 0:
                    sb.Append("baz");
                    break;
            }

            switch (true)
            {
                case bool when x % 5 == 0:
                    sb.Append("bar");
                    break;
            }

            switch (true)
            {
                case bool when x % 7 == 0:
                    sb.Append("jazz");
                    break;
            }

            switch (true)
            {
                case bool when x % 9 == 0:
                    sb.Append("huzz");
                    break;
            }

            // Kalau gak ada aturan yang match → print angka
            if (sb.Length == 0)
                Console.WriteLine(x);
            else
                Console.WriteLine(sb.ToString());
        }
    }
}
