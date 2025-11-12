//enemurator c#
using System;
using System.Collections;
using System.Collections.Generic;

public class IteraratorDemoProject
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Demo Enumerator in C#");
        //demo enumerator manual
        var number = new List<int>() { 1, 2, 3, 4, 5 };
        Console.WriteLine("Using foreach to iterate over the list:");
        foreach (var num in number)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine();
        //iterasi manual menggunakan enumerator
        Console.WriteLine("Using IEnumerator to iterate manually:");
        //kita menggunakan using karena IEnumerator mengimplementasikan IDisposable
        using (IEnumerator<int> enumerator = number.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                int current = enumerator.Current;
                Console.WriteLine(current);
            }
        }

        //enumerator dengan yield return
        Console.WriteLine();
        Console.WriteLine("Using GenerateNumbers with yield return:");
        Console.WriteLine("membuat sequence angka genap (lazy evaluation)");
        IEnumerable<int> evenSequence = GetEvenNumbers(10);
        foreach (var even in evenSequence)
        {
            Console.WriteLine(even);
        }

        Console.WriteLine();
        //buat squence angka dalam range tertentu lazy
        Console.WriteLine("lazy return"); 
        IEnumerable<int> range = GenerateRange(1, 10);
        //filter sqeuence
        IEnumerable<int> filteredRange = FilterLessThan(range, 5);
        foreach (var num in filteredRange)
        {
            Console.WriteLine($"{num}");
                   }
        Console.WriteLine();

    }
    // iterator komposisiis generator range
    //hanya menghasilkan angkadalam range tertentu
    public static IEnumerable<int> GenerateRange(int start, int count)
    {
        Console.WriteLine("GenerateRange called");
        for (int i = 0; i < count; i++)
        {
            yield return start + i;
        }
        Console.WriteLine("GenerateRange completed");
    }

    // iterator generator angka genap
    public static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i += 2)
        {
            yield return i;
        }
    }   

    //iterator filter mengambil sqeuence yang difilter
    public static IEnumerable<T> FilterLessThan<T>(IEnumerable<T> sequence,T limit)
        where T : IComparable<T>
    {
        Console.WriteLine("iterator filter less than");
        foreach (T item in sequence) 
        {
            if (item.CompareTo(limit) < 0)
            {
                //loloskan filter
                yield return item;
            }
        }
        Console.WriteLine("iterator filter less than done");
    }
}