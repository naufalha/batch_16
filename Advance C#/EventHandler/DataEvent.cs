using System;

namespace EventHandlerLatihan
{
    // Materi: "Passing Data with Events"
    // Ini adalah praktik standar di .NET.
    // 1. Buat kelas yang mewarisi dari 'EventArgs'.
    // 2. Kelas ini bertugas MEMBAWA data dari Publisher ke Subscriber.
    public class VideoEventArgs : EventArgs
    {
        // Properti ini akan berisi data yang ingin kita kirimkan.
        public Video Video { get; set; }

        public VideoEventArgs(Video video)
        {
            Video = video;
        }
    }

    // Kelas data sederhana untuk video kita
    public class Video
    {
        public string Judul { get; set; }
    }
}