public struct Note
{
    //value semitone dari A
    private readonly int value;
    public Note(int semitonesFromA)
    {
        this.value = semitonesFromA;
    }

    //overloading operator biner +
    //harus public dan static
    public static Note operator +(Note x, int semitone)
    {
        //logika: kembalikan note dengan nilai baru 
        //nilai valu lama ditambah semiconlonos
        return new Note(x.value + semitone);
    }

    //overide to string agar mudah diprint
    public override string ToString()
    {
        return $"Note (value: {this.value})";
    }


}

//main class
public class OperatorOverloadingDemo
{
    public static void Main(string[] args)
    {
        Console.WriteLine("demo opertaor overloading sederhana");
        //buat note 'A' niali = 0
        Note noteA = new Note(0);
        Console.WriteLine($"Note Awal: {noteA}");
        //gunakan operataro untuk overload
        Note noteB = noteA + 2;
        Console.WriteLine($"NoteBaru (A+2): {noteB}");
    }
}