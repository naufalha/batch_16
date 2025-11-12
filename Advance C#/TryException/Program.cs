//demo event exception handling
public class ExceptionDemoProject
{
    public static void Main(string[] args)
    {
        //demo try catch finally
        ProcessUserInput("123");
        ProcessUserInput("abc");
        ProcessUserInput(null);
        ProcessUserInput("9999999999999999999999999");

        //demo safe divide
        SafeDivide(10, 2);
        SafeDivide(10, 0);

        //demo try parse
        UseTryParse("456");
        UseTryParse("def");

    }
    // demo  try catch finaly
    public static void ProcessUserInput(string input)
    {
        Console.WriteLine($"Processing input: {input}");
        try
        {
            //throwing exception manualy
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input cannot be null");

            }
            //kode yang bisa melempar exsepsi
            //jika bukan angka akan di convert ke int
            int number = int.Parse(input);
            Console.WriteLine($"You entered number: {number}");
        }
        catch (ArgumentException ex)
        {
            //catch argument spesifik
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("catch 1 error argument");
            Console.ResetColor();
        }
        catch (FormatException ex)
        {
            //catch format exception
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("catch 2 error format");
            Console.ResetColor();
        }
        catch (OverflowException ex)
        {
            //catch overflow exception
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("catch 3 error overflow");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            //catch general exception
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("catch 3 general error");
            Console.ResetColor();
        }
        finally
        {
            //kode yang selalu di eksekusi
            Console.WriteLine("Finally block executed.");
        }


    }


    public static void SafeDivide(int a, int b)
    {
        try
        {
            int result = a / b;
            Console.WriteLine($"Result: {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
    }


    public static void UseTryParse(string input)
    {
        if (int.TryParse(input, out int number))
        {
            Console.WriteLine($"Parsed number: {number}");
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }
}