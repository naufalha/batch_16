using System;

/*
 * Proyek Demo Nullable Value Types di C#
 *
 * Ini adalah program konsol sederhana untuk mendemonstrasikan
 * konsep-konsep dari materi 'Nullable Value Types' (T?).
 */
public class NullableDemoProject
{
    // Gunakan class ini untuk Demo 4
    public class SurveyResponse
    {
        public string Name { get; set; }
        
        // 'Age' adalah opsional. Bisa jadi user tidak mengisinya.
        // Jadi, kita gunakan 'int?' (nullable int).
        public int? Age { get; set; }

        // 'Rating' juga opsional (misal: 1-5 bintang).
        public double? Rating { get; set; }
    }


    // Main adalah titik masuk program
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

        // Cara TIDAK AMAN (sesuai dokumen, ini melempar exception)
        nullableInt = null;
        try
        {
            // Baris ini akan melempar InvalidOperationException
            Console.WriteLine(nullableInt.Value); 
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error saat akses .Value: {ex.Message}");
        }

        // Cara AMAN: GetValueOrDefault()
        // Jika null, akan mengembalikan default(int), yaitu 0
        Console.WriteLine($"GetValueOrDefault() (saat null): {nullableInt.GetValueOrDefault()}"); // Output: 0
        // Atau memberikan default kustom
        Console.WriteLine($"GetValueOrDefault(99) (saat null): {nullableInt.GetValueOrDefault(99)}"); // Output: 99


        // 2. Demo Operator Lifting (Perilaku Aritmatika & Relasi)
        Console.WriteLine("\n--- Demo 2: Operator Lifting ---");
        int? a = 10;
        int? b = null;
        int? c = 20;

        // Aritmatika: Operasi dengan 'null' menghasilkan 'null' (seperti SQL)
        Console.WriteLine($"a + c: {a + c}"); // Output: 30
        Console.WriteLine($"a + b: {a + b}"); // Output: (kosong, karena hasilnya null)

        // Relasional: Perbandingan dengan 'null' menghasilkan 'false'
        Console.WriteLine($"a > 5: {a > 5}");   // Output: True
        Console.WriteLine($"b > 5: {b > 5}");   // Output: False (bukan error, tapi false)
        Console.WriteLine($"b < 5: {b < 5}");   // Output: False

        // Gleichheit (==): 'null' hanya sama dengan 'null'
        Console.WriteLine($"a == 10: {a == 10}"); // Output: True
        Console.WriteLine($"b == 10: {b == 10}"); // Output: False
        Console.WriteLine($"b == null: {b == null}"); // Output: True


        // 3. Demo Operator Null-Coalescing (??)
        Console.WriteLine("\n--- Demo 3: Operator Null-Coalescing (??) ---");
        Console.WriteLine("   (Cara terbaik untuk memberi nilai default)");
        
        int? optionalValue = null;
        
        // Jika optionalValue adalah null, gunakan 99.
        // Ini adalah cara yang jauh lebih bersih daripada GetValueOrDefault().
        int concreteValue = optionalValue ?? 99;
        Console.WriteLine($"Hasil '??' (saat null): {concreteValue}"); // Output: 99

        optionalValue = 50;
        concreteValue = optionalValue ?? 99;
        Console.WriteLine($"Hasil '??' (saat non-null): {concreteValue}"); // Output:

        // 4. Demo Use Case: Data Opsional (Survei)
        Console.WriteLine("\n--- Demo 4: Use Case (Data Survei Opsional) ---");
        
        // User ini mengisi semua data
        var response1 = new SurveyResponse { Name = "Andi", Age = 30, Rating = 4.5 };
        
        // User ini tidak mengisi Age dan Rating
        var response2 = new SurveyResponse { Name = "Budi", Age = null, Rating = null };

        PrintSurveyResult(response1);
        PrintSurveyResult(response2);
    }

    public static void PrintSurveyResult(SurveyResponse response)
    {
        Console.WriteLine($"\n  Nama: {response.Name}");
        
        // Kita bisa cek 'HasValue'
        if (response.Age.HasValue)
        {
            Console.WriteLine($"  Usia: {response.Age.Value} tahun");
        }
        else
        {
            Console.WriteLine("  Usia: (tidak diisi)");
        }

        // Atau, kita bisa gunakan '??' untuk tampilan yang lebih singkat
        // Jika Rating null, gunakan 0.0, jika tidak, gunakan nilainya.
        double displayRating = response.Rating ?? 0.0;
        Console.WriteLine($"  Rating: {displayRating} / 5.0");
    }
}