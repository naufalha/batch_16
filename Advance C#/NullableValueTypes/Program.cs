using System;
public class NullableDemoProect
{
    public class SurveyResponse
    {
        public string? Name { get; set; }
        //age adalah opsional bisa jadi user tidak mengisinya
        public int? Age { get; set; }
        //rating opsional misal 1-5 bintang
        public double? Rating { get; set; }
    }

    //main method
    public static void Main(string[] args)
    {
        Console.WriteLine("--- Demo Nullable Value Types (T?) ---");

        // 1. Demo Dasar: HasValue dan Value
        Console.WriteLine("\n--- Demo 1: Dasar-Dasar (HasValue, Value) ---");
        
        // Deklarasi int? (nullable int) dan inisialisasi ke null
        int? nullableInt = null;

        Console.WriteLine($"nullableInt.HasValue: {nullableInt.HasValue}"); // Output: False
        nullableInt = 100;
        Console.WriteLine($"nullableInt.HasValue: {nullableInt.HasValue}"); // Output: True
        Console.WriteLine($"nullableInt.Value: {nullableInt.Value}");     // Output: 100

        //cara tidak aman throw exception
        nullableInt = null;
        try
        {
            //this line throwing exception
            Console.WriteLine(nullableInt.Value);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"error akses {ex.Message}");
        }
        //cara aman,jika null maka akan return 0
        Console.WriteLine($"GetValueor default :{nullableInt.GetValueOrDefault()}");
        Console.WriteLine($"get value or default (99){nullableInt.GetValueOrDefault(99)}");



    }
    public static void PrintSurveyResult(SurveyResponse response)
    {
        Console.WriteLine($"\n nama: {response.Name}");
        //cek has value
        if (response.Age.HasValue)
        {
            Console.WriteLine($" usia {response.Age.Value} tahun");

        }
        else
        {
            Console.WriteLine("usia tidak diisi");

        }
        //bisa ditampilkan ?? untuk tampilan lebih singkat
        //jika rating null gunakan 0.0 jika tidak gunakannilainya
        double displayRating = response.Rating ?? 0.0;
        Console.WriteLine($"rating :{displayRating} / 5.0");


    }

}

