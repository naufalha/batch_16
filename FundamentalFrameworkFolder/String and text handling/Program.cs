
using System;
using System.Text;
using System.Globalization;

// This console application demonstrates the key concepts from the
// "String and Text Handling" document.
public class Program
{
    public static void Main(string[] args)
    {
        DemoCharMethods();
        DemoStringImmutability();
        DemoStringManipulation();
        DemoStringFormatting();
        DemoStringComparison();
        DemoStringBuilder();
        DemoEncoding();
    }

    // Demonstrates System.Char static methods
    public static void DemoCharMethods()
    {
        Console.WriteLine("--- Demo: System.Char Methods ---");
        char c1 = 'a';
        char c2 = '7';
        char c3 = '\t'; // Tab character
        char c4 = 'i';

        Console.WriteLine($"char.IsLetter('a'): {char.IsLetter(c1)}"); // True
        Console.WriteLine($"char.IsDigit('7'): {char.IsDigit(c2)}");   // True
        Console.WriteLine($"char.IsWhiteSpace('\\t'): {char.IsWhiteSpace(c3)}"); // True

        // As the doc mentions, ToUpper() can be culture-sensitive.
        // The Turkish 'i' becomes 'İ'.
        // ToUpperInvariant() is the safe way to always get the English 'I'.
        Console.WriteLine($"char.ToUpperInvariant('i'): {char.ToUpperInvariant(c4)}");
        Console.WriteLine();
    }

    // Demonstrates that strings are immutable
    public static void DemoStringImmutability()
    {
        Console.WriteLine("--- Demo: String Immutability ---");
        string s1 = "Hello";
        
        // .Replace() does NOT change s1.
        // It returns a *new* string.
        string s2 = s1.Replace("l", "p");

        Console.WriteLine($"Original s1: {s1}"); // s1 is still "Hello"
        Console.WriteLine($"New s2: {s2}");      // s2 is "Heppo"

        // The + operator also creates a new string
        string s3 = s1 + " World!";
        Console.WriteLine($"New s3: {s3}");
        Console.WriteLine();
    }

    // Demonstrates common string manipulation methods
    public static void DemoStringManipulation()
    {
        Console.WriteLine("--- Demo: String Manipulation ---");
        string data = "Find the 'needle' in this haystack.";
        
        // IndexOf: Find the start of a substring
        int index = data.IndexOf("needle");
        Console.WriteLine($"'needle' found at index: {index}");

        // Substring: Extract a part of the string
        string needle = data.Substring(index, "needle".Length);
        Console.WriteLine($"Extracted: {needle}");

        // Split: Divide a string into an array
        string csv = "one,two,three,four";
        string[] parts = csv.Split(',');
        Console.WriteLine("Split by comma:");
        foreach (string part in parts)
        {
            Console.WriteLine($"  - {part}");
        }

        // Join: Combine an array into a string
        string joined = string.Join(" | ", parts);
        Console.WriteLine($"Joined with ' | ': {joined}");
        Console.WriteLine();
    }

    // Demonstrates string.Format and interpolated strings
    public static void DemoStringFormatting()
    {
        Console.WriteLine("--- Demo: String Formatting ---");
        string name = "Alice";
        double amount = 123.45;

        // Old way: string.Format()
        string s1 = string.Format("Hello, {0}. Your balance is {1:C}.", name, amount);
        Console.WriteLine($"string.Format(): {s1}");
        
        // New way (C# 6+): Interpolated Strings ($)
        // This is generally preferred for readability.
        string s2 = $"Hello, {name}. Your balance is {amount:C}.";
        Console.WriteLine($"Interpolation: {s2}");

        // Interpolation with alignment (from your doc)
        // -10 = 10 characters, left-aligned
        // 15:C = 15 characters, right-aligned, Currency format
        string s3 = $"Name: {name,-10} | Balance: {amount,15:C}";
        Console.WriteLine($"Formatted/Aligned: {s3}");
        Console.WriteLine();
    }

    // Demonstrates Ordinal vs. Culture-Aware comparison
    public static void DemoStringComparison()
    {
        Console.WriteLine("--- Demo: String Comparison ---");
        string s1 = "apple";
        string s2 = "APPLE";
        
        // The == operator performs an Ordinal (byte-level), case-sensitive check.
        Console.WriteLine($"'apple' == 'APPLE': {s1 == s2}"); // False

        // For case-insensitive comparison, use string.Equals with an enum.
        // OrdinalIgnoreCase is fast and safe for internal/non-linguistic checks.
        bool fastCheck = string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"OrdinalIgnoreCase: {fastCheck}"); // True

        // Culture-aware comparison is for sorting/displaying to users.
        // Example: In German, "Straße" (street) can be treated as equal to "Strasse".
        string s3 = "Straße";
        string s4 = "Strasse";
        
        // Set culture to German (de-DE)
        CultureInfo german = new CultureInfo("de-DE");
        
        // Ordinal check will fail (different bytes)
        bool ordinalCheck = string.Equals(s3, s4, StringComparison.OrdinalIgnoreCase);
        Console.WriteLine($"'Straße' vs 'Strasse' (Ordinal): {ordinalCheck}"); // False

        // Culture check will succeed (linguistically equivalent in German)
       // bool cultureCheck = string.Equals(s3, s4, StringComparison.Create(german, CompareOptions.IgnoreCase));
       // Console.WriteLine($"'Straße' vs 'Strasse' (German Culture): {cultureCheck}"); // True
       // Console.WriteLine();
    }

    // Demonstrates efficient string building with StringBuilder
    public static void DemoStringBuilder()
    {
        Console.WriteLine("--- Demo: StringBuilder ---");
        
        // Inefficient way: Using string + in a loop
        // This creates many new string objects in memory.
        string sBad = "";
        for (int i = 0; i < 5; i++)
        {
            sBad += i + ","; // Creates a new string every time
        }
        Console.WriteLine($"Inefficient concat: {sBad}");
        
        // Efficient way: Using StringBuilder
        // This uses one mutable buffer.
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < 5; i++)
        {
            sb.Append(i);
            sb.Append(",");
        }
        
        // Get the final, immutable string
        string sGood = sb.ToString();
        Console.WriteLine($"Efficient append: {sGood}");
        Console.WriteLine();
    }

    // Demonstrates converting strings to/from bytes using Encodings
    public static void DemoEncoding()
    {
        Console.WriteLine("--- Demo: Text Encodings ---");
        // Emoji requires multiple bytes
        string text = "Hi 😃"; 

        // UTF-8 is standard for web/files. 1-4 bytes per char.
        byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);
        Console.WriteLine($"'{text}' in UTF-8: {utf8Bytes.Length} bytes");
        
        // UTF-16 is what C# uses internally (Encoding.Unicode is an alias)
        // 2 or 4 bytes per char.
        byte[] utf16Bytes = Encoding.Unicode.GetBytes(text);
        Console.WriteLine($"'{text}' in UTF-16: {utf16Bytes.Length} bytes");

        // Convert back to prove it works
        string roundTrip = Encoding.UTF8.GetString(utf8Bytes);
        Console.WriteLine($"Round-tripped from UTF-8: {roundTrip}");
        Console.WriteLine();
    }
}