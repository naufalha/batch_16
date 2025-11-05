using System;
using System.Diagnostics.Contracts;
using cars;
using gay;

namespace democlass
{
    class Program
    {
        static void Main(string[] args)
        {
            calculator3 calculator3 = new calculator3();
            int result = calculator3.add(35, 10);
            Console.WriteLine("Result: " + result);

        }

    }

    public class calculator3
    {
        public int add(int a, int b)
        {

            return a + b;
        }
    }
}
