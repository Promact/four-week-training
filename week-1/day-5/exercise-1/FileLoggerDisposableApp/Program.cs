namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            string path = "C:\\Users\\admin\\source\\repos\\Day-2\\four-weeks-training\\week-1\\day-5" +
                "\\exercise-1\\FileLoggerDisposableApp\\FileLogg.txt";
            using (FileLogger logger = new FileLogger(path))
            {
                logger.Log("Log message at:");
            }
        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
            _writer = new StreamWriter(filePath, true);
        }

        public void Dispose()
        {
            // Implement IDisposable pattern
            // Dispose of unmanaged resources.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        private bool _disposedValue;
        private void Dispose(bool isDisposing)
        {
            if (!_disposedValue)
            {
                if (isDisposing)
                {
                    _writer.Dispose();
                    _writer = null;
                }
                _disposedValue = true;
            }
        }

        public void Log(string message)
        {
            // Write message to the file
            _writer.WriteLine(message + " " + DateTime.Now.ToString());
            Console.WriteLine("Log message saved to logg file.");
        }

        ~FileLogger()
        {
            Dispose(false);
        }
    }
}