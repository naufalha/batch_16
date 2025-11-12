namespace EventHandlerLatihan1
{
    //klas data sederhana untuk video kita
    public class Video
    {
        public string Judul { get; set; } = string.Empty;
    }

    //event pulbisher
    public class VideoEncoder
    {
        //define delegate
        public delegate void VideoEncodedEventHandler();
        //define event
        public event VideoEncodedEventHandler? VideoEncoded;
        //method to raise event
        public void Encode(Video vidio)
        {
            Console.WriteLine($"Encoding video: {vidio.Judul}");
            //after encoding
            OnVideoEncoded();
            //panggil method onvideoencoded untuk memicu event subscriber

        }

        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
            {
                //calling event subscriber
                VideoEncoded();
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
        public void OnVideoEncoded()
        {
            Console.WriteLine("$[EmailService]:Mengirim email pemberitahuan bahwa video telah selesai di encode");

        }
    }
    
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Latihan Event Handler langkah 2.1 publisher");
            var video = new Video() { Judul = "Tutorial Event Handler di C#" };
            var videoEncoder = new VideoEncoder();
            //subscribe event dan memanggil method onvideoencoded di emailservice
            var EmailService = new EmailService();
            videoEncoder.VideoEncoded += EmailService.OnVideoEncoded;
            videoEncoder.Encode(video);
            //tidaka da subscribe maka tidak akan ada output setelah encoding
            Console.WriteLine("langkah 2.2 selesai subscribe event");
        
        }
    }
}