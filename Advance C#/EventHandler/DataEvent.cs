using System;

// Kita letakkan kelas ini di namespace yang sama
namespace EventHandlerLatihan
{
    // Materi: "Passing Data with Events"
    // Ini adalah kelas khusus yang bertugas "membawa" data
    // dari publisher ke subscriber.
    //
    // Sesuai konvensi .NET:
    // 1. Nama kelas diakhiri dengan "EventArgs".
    // 2. Kelas ini harus mewarisi (inherit) dari kelas 'EventArgs' bawaan .NET.
    public class VideoEventArgs : EventArgs
    {
        // Kita tambahkan properti untuk data apa saja yang ingin kita kirim.
        // Dalam kasus ini, kita ingin mengirim objek 'Video' itu sendiri.
        //
        // PENTING: Kita TIDAK membuat konstruktor kustom di sini.
        // Dengan membiarkannya kosong, C# akan memberi kita
        // konstruktor default tanpa parameter (gratis),
        // yang kita butuhkan untuk sintaks 'new VideoEventArgs { ... }'.
        public Video? Video { get; set; }
    }
}