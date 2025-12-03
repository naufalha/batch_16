using System.IO;

namespace Banking.Domain
{
    public class FileLogger : ILogger
    {
        private string _filePath;
        public FileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public void Log(string message)
        {
            //menulis pesan dalam teks notepad
            string logMessage = $"{DateTime.Now}: {message}{Environment.NewLine}";
            // AppendAllText artinya: Tambahkan teks di baris baru (jangan hapus isi lama)
            File.AppendAllText(_filePath, logMessage);
        }
    }
}