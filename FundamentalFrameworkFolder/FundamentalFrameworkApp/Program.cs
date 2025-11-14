//equaliry comparisson
using System;
using System.Diagnostics; // Untuk [Utility Classes] (meskipun kita pakai Environment)
using System.Collections.Generic; // Untuk [Equality Comparison] (HashSet)
using System.Globalization; // Untuk [Formatting and Parsing]
using System.Numerics; // Untuk [Working With Numbers] (BigInteger, Complex)
using System.Security.Cryptography; // Untuk [Working With Numbers] (RandomNumberGenerator)
using System.Text; // Untuk [String Handling] (StringBuilder) & [Other Conversions] (Encoding)

//===============================================================
// MODUL: Enums
//===============================================================

/// <summary>
/// Enum standar untuk level log.
/// </summary>
public enum LogLevel
{
    Info,    // 0
    Warning, // 1
    Error    // 2
}

/// <summary>
/// Enum [Flags] untuk izin pengguna.
/// Nilai harus pangkat 2.
/// </summary>
[Flags]
public enum Permissions
{
    None = 0,
    Read = 1,    // 0001
    Write = 2,   // 0010
    Execute = 4, // 0100
    All = Read | Write | Execute // 7
}

//===============================================================
// MODUL: Equality Comparison (dan Enums)
//===============================================================

/// <summary>
/// Class kustom yang mengimplementasikan protokol Equality Comparison.
/// Dua objek 'User' dianggap SAMA jika 'Id' dan 'Username' mereka sama.
/// </summary>
public class User : IEquatable<User>
{
    public int Id { get; }
    public string Username { get; }
    public Permissions UserPermissions { get; set; }

    public User(int id, string username, Permissions permissions)
    {
        Id = id;
        Username = username;
        UserPermissions = permissions;
    }

    // Untuk output yang cantik
    public override string ToString()
    {
        // Menampilkan [Flags] enum (akan menampilkan "Read, Write", dll.)
        return $"[User ID: {Id}, Name: {Username}, Perms: {UserPermissions}]";
    }

    // --- Implementasi Protokol Equality ---

    // 1. Override virtual Object.Equals(object obj)
    public override bool Equals(object obj)
    {
        return Equals(obj as User);
    }

    // 2. Implementasi IEquatable<User>.Equals(User other)
    //    Ini adalah logika inti kesetaraan kita.
    public bool Equals(User other)
    {
        if (other is null)
        {
            return false;
        }
        // Optimasi jika menunjuk ke objek yang sama persis
        if (Object.ReferenceEquals(this, other))
        {
            return true;
        }
        // Logika kesetaraan nilai:
        return this.Id == other.Id && this.Username == other.Username;
    }

    // 3. Override GetHashCode()
    //    WAJIB: Jika Equals() true, GetHashCode() HARUS sama.
    public override int GetHashCode()
    {
        // Gunakan field yang sama dengan yang kita gunakan di Equals()
        return HashCode.Combine(Id, Username);
    }

    // 4. Overload Operator == dan !=
    public static bool operator ==(User left, User right)
    {
        if (left is null)
        {
            return right is null;
        }
        return left.Equals(right);
    }

    public static bool operator !=(User left, User right)
    {
        return !(left == right);
    }
}

//===============================================================
// MODUL: Date and Times (dan Enums)
//===============================================================

/// <summary>
/// Class sederhana untuk menyimpan entri log yang sudah di-parse.
/// Menggunakan DateTimeOffset (praktik terbaik).
/// </summary>
public class LogEntry
{
    public DateTimeOffset Timestamp { get; }
    public LogLevel Level { get; }
    public string Message { get; }

    public LogEntry(DateTimeOffset timestamp, LogLevel level, string message)
    {
        Timestamp = timestamp;
        Level = level;
        Message = message;
    }

    public override string ToString()
    {
        // Menggunakan format 'o' (round-trip) untuk tanggal
        return $"[{Timestamp:o}] [{Level.ToString("G")}] {Message}";
    }
}

//===============================================================
// MODUL: String Handling & Formatting/Parsing
//===============================================================

/// <summary>
/// Kelas statis untuk mem-parsing string log mentah.
/// </summary>
public static class LogParser
{
    // Format Log yang Diharapkan: "ISO_DATE|LOG_LEVEL|Pesan"
    // Contoh: "2025-11-13T14:30:00.123+07:00|Warning|User 'admin' logged in."
    
    public static LogEntry ParseLogLine(string logLine)
    {
        // MODUL: String Handling (Split)
        string[] parts = logLine.Split('|');

        if (parts.Length != 3)
        {
            throw new FormatException($"Log line tidak valid: {logLine}");
        }

        // MODUL: Formatting and Parsing (Parse) & Date/Time
        // Gunakan InvariantCulture dan RoundtripKind untuk format ISO 8601
        DateTimeOffset timestamp = DateTimeOffset.Parse(
            parts[0], 
            CultureInfo.InvariantCulture, 
            DateTimeStyles.RoundtripKind);

        // MODUL: Enums (TryParse) & Formatting/Parsing (TryParse)
        // Gunakan TryParse untuk enum agar aman
        if (!Enum.TryParse(parts[1], true, out LogLevel level)) // true = case-insensitive
        {
            level = LogLevel.Error; // Default jika parsing gagal
        }

        string message = parts[2];

        return new LogEntry(timestamp, level, message);
    }
}


//===============================================================
// Main Program
//===============================================================
public class Program
{
    // MODUL: Working With Numbers (Best Practice)
    // Buat SATU instance Random dan gunakan kembali.
    private static readonly Random _random = new Random();

    public static void Main(string[] args)
    {
        Console.WriteLine("--- DEMO PROYEK KOMPREHENSIF ---");

        // 1. DEMO: 3
        Console.WriteLine("\n--- Modul: Utility Classes ---");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Info Sistem dari 'System.Environment':");
        Console.WriteLine($"  Nama Komputer: {Environment.MachineName}");
        Console.WriteLine($"  Nama Pengguna: {Environment.UserName}");
        Console.WriteLine($"  Versi OS: {Environment.OSVersion.VersionString}");
        Console.ResetColor();

        // 2. DEMO: Equality Comparison & Enums
        Console.WriteLine("\n--- Modul: Equality Comparison & Enums ---");
        var p1 = new User(101, "admin", Permissions.Read | Permissions.Write);
        var p2 = new User(102, "guest", Permissions.Read);
        var p3 = new User(101, "admin", Permissions.All); // ID & Nama sama, tapi izin beda

        Console.WriteLine($"User 1: {p1}");
        Console.WriteLine($"User 2: {p2}");
        Console.WriteLine($"User 3: {p3}");

        // Memeriksa kesetaraan nilai (Value Equality)
        // Ini 'True' karena Equals() kita HANYA memeriksa Id dan Username
        bool p1_eq_p3 = (p1 == p3);
        Console.WriteLine($"\nApakah User 1 == User 3? {p1_eq_p3}");

        // Membuktikan GetHashCode() bekerja dengan HashSet
        var userSet = new HashSet<User>();
        userSet.Add(p1);
        
        // .Contains(p3) akan 'True' HANYA jika GetHashCode() & Equals() benar
        Console.WriteLine($"Apakah HashSet berisi User 3? {userSet.Contains(p3)}");

        // Cek [Flags] Enum
        if ((p1.UserPermissions & Permissions.Write) == Permissions.Write)
        {
            Console.WriteLine("User 1 memiliki izin 'Write'.");
        }

        // 3. DEMO: String Handling, Parsing, Date/Time
        Console.WriteLine("\n--- Modul: String Handling, Parsing, Date/Time ---");
        string logLine = "2025-11-13T14:45:15.500+07:00|Warning|Disk space running low.";
        Console.WriteLine($"Log Mentah: {logLine}");
        
        LogEntry entry = LogParser.ParseLogLine(logLine);
        Console.WriteLine("Hasil Parse:");
        Console.WriteLine($"  Timestamp: {entry.Timestamp} (Kind: {entry.Timestamp.Offset})");
        Console.WriteLine($"  Level: {entry.Level}");
        Console.WriteLine($"  Pesan: {entry.Message}");

        // 4. DEMO: Working With Numbers (Math, Random, BigInteger)
        Console.WriteLine("\n--- Modul: Working With Numbers ---");
        double num = 81;
        Console.WriteLine($"Math.Sqrt({num}) = {Math.Sqrt(num)}");
        Console.WriteLine($"Angka acak (dari instance static): {_random.Next(1000)}");
        
        BigInteger bigNum = BigInteger.Pow(2, 128);
        Console.WriteLine($"BigInteger (2^128): {bigNum}");
        
        // 5. DEMO: Other Conversions (Base16, Base64, BitConverter)
        Console.WriteLine("\n--- Modul: Other Conversions ---");
        
        // Konversi Angka (Base 16 Hex)
        int hexVal = Convert.ToInt32("FF", 16); // FF = 255
        Console.WriteLine($"Convert.ToInt32(\"FF\", 16) = {hexVal}");

        // Konversi Base-64 (untuk token/data biner)
        // MODUL: Working With Numbers (Secure Random)
        byte[] secureToken = new byte[16];
        RandomNumberGenerator.Fill(secureToken); // Buat token acak yang aman
        
        // MODUL: Other Conversions (ToBase64String)
        string tokenString = Convert.ToBase64String(secureToken);
        Console.WriteLine($"Token Keamanan (Base-64): {tokenString}");

        // MODUL: Other Conversions (BitConverter)
        byte[] intBytes = BitConverter.GetBytes(123456789);
        Console.WriteLine($"BitConverter.GetBytes(123456789): {string.Join(" ", intBytes)}");

        Console.WriteLine("\n--- DEMO SELESAI ---");
    }
}