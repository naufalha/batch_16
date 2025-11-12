using EventHandlerLatihan;

namespace EventHandlerLatihan
{
    //klas data sederhana untuk video kita
    public class Video
    {
        public string? Judul { get; set; }
    }
    //event pulbisher
    public class VideoEncoder
    {
        //define delegate
        // --- LATIHAN 2.4: Perbarui Delegate ---
        // Materi: "Passing Data with Events"
        // Delegate standar .NET untuk event SELALU memiliki dua parameter:
        // 1. 'object source': Siapa yang memicu event (yaitu, si VideoEncoder)
        // 2. 'EventArgs args': Objek yang membawa data (yaitu, VideoEventArgs kita)
        //
        // Kita HAPUS delegate lama (VideoEncodedEventHandler)
        // dan ganti dengan standar .NET:
        // public delegate void VideoEncodedEventHandler(); <-- HAPUS INI

        // Kita bisa gunakan delegate bawaan .NET 'EventHandler<T>'
        // 'EventHandler<VideoEventArgs>' adalah singkatan untuk:
        // 'delegate void NamaApapun(object source, VideoEventArgs args)'
        //         public event VideoEncodedEventHandler? VideoEncoded;
        public event EventHandler<VideoEventArgs>? VideoEncoded;
        
        
        //method to raise event
        public void Encode(Video vidio)
        {
            Console.WriteLine($"Encoding video: {vidio.Judul}");
            //after encoding
            Thread.Sleep(3000);
            OnVideoEncoded(vidio);
            //panggil method onvideoencoded untuk memicu event subscriber

        }
// 2.4 perbarui event triger method
        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
            {
                // 1. Buat objek EventArgs untuk "membungkus" data video kita
                var args = new VideoEventArgs { Video = video };

                // 2. Panggil event-nya!
                //    'this' adalah 'source' (si pengirim, yaitu instance VideoEncoder ini)
                //    'args' adalah data yang kita kirim
                VideoEncoded(this, args);
            }
            else
            {
                Console.WriteLine("No subscribers for the event.");
            }
        }
    }
    public class EmailService
    {
        //event handler signature harus sama dengan delegate vidio encode event handler
        public void OnVideoEncoded(object source, VideoEventArgs args)
        {
            Console.WriteLine("$[EmailService]:Mengirim email pemberitahuan bahwa video telah selesai di encode");

        }


    }
    public class SMSService
    {
        //multicaset event handler
        //membuat classsebanyak kita mau 
        //membuat method sesuai dengan delegate
        public void OnVideoEncoded(Object source,VideoEventArgs args)
        {
            Console.WriteLine($"[SMSService]:Mengirim SMS pemberitahuan bahwa video telah selesai di encode");
        }
    }
    
    class Program
    {
        static void Main (string[] args)
        {
                        Console.WriteLine("--- Latihan Event Handler: Langkah 2.4 (Mengirim Data) ---");
            
            var video = new Video { Judul = "Tutorial C# Event.mp4" };
            var videoEncoder = new VideoEncoder(); 
            var emailService = new EmailService(); 
            var smsService = new SMSService(); 

            // 3. Berlangganan
            // Kodenya SAMA PERSIS. Ini tetap berfungsi karena metode subscriber
            // (OnVideoEncoded) sudah kita perbarui agar cocok dengan delegate baru.
            videoEncoder.VideoEncoded += emailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += smsService.OnVideoEncoded;
            
            // 4. Mulai proses.
            videoEncoder.Encode(video);

            Console.WriteLine("\n--- Latihan Langkah 2.4 Selesai ---");
        }
    }
}