

namespace EventHandlerLatihan
{
    public class VideoEncoder
    {
        // bagaian 1 mendifinisikan delegate
        public event EventHandler<VidioEventArgs> VideoEncoded;
        //bagian 2 mendefinisikan method untuk mengekode video
        public void VideoEncode(Video video)
        {
            Console.WriteLine("Encoding video...");
            //simulasi proses encoding dengan delay
            System.Threading.Thread.Sleep(2000);
            //setelah encoding selesai, panggil event untuk memberitahu subscriber
            Console.WriteLine("Video encoded successfully.");
            OnVideoEncoded(video);

        }

        class Program
        {
            static void Main(string[] args)
            {
                
            }
        }
    }
}   