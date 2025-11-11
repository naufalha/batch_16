using System.Collections.Specialized;

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
            Latihan2_MemanggilDelegate();
            Latihan3_MulticastDelegate();
            Latihan4_GenericDelegate();
            Latihan5_LamdaExpression();
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
            notifikasi("tes notifikasi pertama ");

            //2. Menambhkan subscriber kedua dengan menggunakan "+=" operator
            notifikasi += KirimSMS;
            Console.WriteLine("\nkirim email dan sms");
            notifikasi("paket anda telah tiba");
            //3. Menghapus subscriber pertama dengan menggunakan "-=" operator
            notifikasi -= KirimEmail;
            Console.WriteLine("\nhanya kirim sms saja,method KirimEmail dihapus dari daftar subscriber notifikasi");
            notifikasi("Diskon 50% untuk pembelian hari ini telah digunakan");

        }
        //generic delegate (action and func) bisa digunakan untuk menghindari deklarasi delegate yang berulang
        //C# menyediakan dua jenis generic delegate yaitu Action dan Func
        //Action: digunakan untuk method yang tidak mengembalikan nilai (void)
        //Func: digunakan untuk method yang mengembalikan nilai
        public static void Latihan4_GenericDelegate()
        {
            Console.WriteLine("\n---- Latihan Generic Delegate dengan Func dan Action");

            // action<T>: untuk method yang tidak mengembalikan nilai
            Action<string> notifAction = KirimEmail;
            notifAction = KirimSMS;
            notifAction("iniadalah notifikasi menggunakan Action delegate");
            // 2. Func<T1, T2, TResult>: untuk method yang mengembalikan nilai
            Func<int, int, int> hitung = Tambah;
            int total = hitung(10, 5);
            Console.WriteLine($"hasil Func Tambah(10,5) = {total}");
            //arakhakn  method lain yang cocok
            hitung = Kurang;
            total = hitung(10, 5);
            Console.WriteLine($"hasil Func Kurang(10,5) = {total}");



        }
        
        //anonymous method dan lambda expression bisa digunakan untuk membuat implementasi delegate secara inline tanpa perlu mendefinisikan method terpisah
        /** ini adalah cara untuk menulis moed anonymous method
         dan   lambda expression adalah cara yang lebih ringkas untuk menulis anonymous method
            */
        public static void Latihan5_LamdaExpression()
        {
            Console.WriteLine("\n---- Latihan Lambda Expression");
            //1. cara lam :menggunakan"square yang sudah ada
            Func<int, int> KuadratFunc = x => x * x;
            Console.WriteLine($"Hasil kuadrat dari 6 adalah: {KuadratFunc(6)}, ini dengan cara lama");
            //2. cara baru :menggunakan lambda expression
            //menggunakan lambda expression untuk menghitung pangkat tiga
            //(int x )=> { return x * x * x; }
            // ini adalah metod anonynim langsung yang di declare ke delegate Func
            Func<int, int> KuadratLambda = (int x) => { return x * x * x; };
            Console.WriteLine($"Hasil pangkat tiga dari 6 adalah: {KuadratLambda(6)}, ini dengan cara baru lambda expression");
            //cara lebih ringkas tanpa tipe data parameter dan tanpa kurawal serta return
            //c# bisa menginfer tipe data parameter dari konteks delegate
            Func<int, int> KuadratSimple = x => x * x;
            Console.WriteLine($"Hasil kuadrat dari 7 adalah: {KuadratSimple(7)}, ini dengan cara lebih ringkas");
            //menggunakan lambda dengan action (void)
            Action<string> sapa = nama =>
            {
                string pesan = $"Halo, {nama}! Selamat datang di dunia C#.";
                Console.WriteLine(pesan);
            };
            sapa("Jokowi");
        
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