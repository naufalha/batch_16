public class FooBar
{
    public static void Main(string[] args)
    {
        int n = 30;
        for (int i = 1; i <= n; i++)
        {
            if (i % 15 == 0)
            {
                Console.Write("foobar");
            }
            else if (i % 3 == 0)
            {
                Console.Write("foo");
            }
            else if (i % 5 == 0)
            {
                Console.Write("bar");
            }
            else
            {
                Console.Write(i);
            }

            if (i < n)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine();
    }
}