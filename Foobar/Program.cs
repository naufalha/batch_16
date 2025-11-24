using System;
using System.Collections.Generic;
using System.Text;

public class FoobarGenerator
{   
    //
    private readonly List<KeyValuePair<int, string>> _rules = new();
    public void AddRule(int input, string output)
    {
        _rules.Add(new KeyValuePair<int, string>(input, output));
    }
    public string Generate(int number)
    {
        StringBuilder sb = new StringBuilder();

        foreach (var rule in _rules)
        {
            if (number % rule.Key == 0)
            {
                sb.Append(rule.Value);
            }
        }

        return sb.Length > 0 ? sb.ToString() : number.ToString();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        int batasAkhir = 105;
        var generator = new FoobarGenerator();
        //api usage generator.Addrule(an integer number,some string)
        generator.AddRule(3, "foo");
        generator.AddRule(4, "baz");
        generator.AddRule(5, "bar");
        generator.AddRule(7, "jazz");
        generator.AddRule(9, "huzz");

        //an example adding addtion rules
        generator.AddRule(10, "fufu");
        generator.AddRule(20,"fafa");
        Console.WriteLine($"--- API Based foobar from 1 to {batasAkhir} ---");
        for (int x = 1; x <= batasAkhir; x++)
        {
            Console.WriteLine(generator.Generate(x));
        }
    }
}
