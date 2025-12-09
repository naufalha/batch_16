using AbstractFactory.Interfaces;

using AbstractFactory.Products;

public class Program
{
    static void Main(string[] args)
    {
            // Simulate a runtime choice (could be config, OS detect, DI, etc.)
            Console.WriteLine("Choose platform: 1 = Windows, 2 = Mac");
            var key = Console.ReadKey(intercept: true).KeyChar;
            Console.WriteLine();

            MacGui gui = new MacGui();

            gui.CreateButton().Paint();
            gui.CreateCheckBox().Paint();
        

    }
}