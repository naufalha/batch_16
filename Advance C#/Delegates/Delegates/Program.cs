namespace DelegatesLatihan
{
        public delegate int Transformer(int x);
        //this decalaration of delgetate untuk contract method yang menerima int dan mengembalikan int
        //
        public delegate void Notifikasi(string pesan);
        //this multicast delegate untuk contract method yang menerima string dan mengembalikan void
        //multicast delegate 
public class Program
    {

        static void Main(string[] args)
        {
            //Latihan2_MemanggilDelegate();
            Latihan3_MulticastDelegate();
        }

        //latihan memanggil and define delegate
        public static void Latihan2_MemanggilDelegate()
        {
            Console.WriteLine("Latihan Memanggil Delegate");
            //membuat instance delegate yang menunjuk ke method Square
            Transformer t = new Transformer(Square);
            //memanggil delegate seperti memanggil method biasa
            int hasil = t(5);
            Console.WriteLine($"Hasil pangkat dua dari 5 adalah: {hasil}");
            //kita bisa mengarakna delegate ke method lain yang sesuai dengan signature
            t = Cube;
            hasil = t(5);
            Console.WriteLine($"Hasil pangkat tiga dari 3 adalah: {hasil}");
    
        }
        
        //latihan multicast delegate
        public static void Latihan3_MulticastDelegate()
        {
            Console.WriteLine("multicast delegate latihan");
            //membuat meode yang codok ke delegate Notifikasi
            //1. subscribe method KirimEmail
            Notifikasi notifikasi = KirimEmail;
            Console.WriteLine("hanya kirim email");
            notifikasi("Halo, ini hanya mengirim  adalah notifikasi email.");

            //2. Menambhkan subscriber kedua dengan menggunakan "+=" operator
            notifikasi += KirimSMS;
            Console.WriteLine("kirim email dan sms");
            notifikasi("Halo, ini email " + "notifikasi email dan sms. mengirim ke dua method sekaligus dengan multicast delegate dengna parameter yang sama");
            //3. Menghapus subscriber pertama dengan menggunakan "-=" operator
            notifikasi -= KirimEmail;
            Console.WriteLine("hanya kirim sms saja,method KirimEmail dihapus dari daftar subscriber notifikasi");
            notifikasi("Halo, ini adalah notifikasi sms saja.method KirimEmail dihapus dari daftar subscriber notifikasi");

        }

    



        //define method signature for delegate
        public static int Square(int x)
        {
            return x * x;
        }

        public static int Cube(int x)
        {
            return x * x * x;
        }
        public static void KirimEmail(string pesan)
        {
            Console.WriteLine($"Mengirim email dengan pesan: {pesan}");
        }

        public static void KirimSMS(string pesan)
        {
            Console.WriteLine($"Mengirim SMS dengan pesan: {pesan}");
        }
        public static int Tambah(int a, int b)
        {
            return a + b;
        }

        public static int Kurang(int a, int b)
        {
            return a - b;
        }

    }
}