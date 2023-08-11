using System.ComponentModel;

namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            using (var logger = new FileLogger("C:\\Users\\admin\\log.txt"))
            {
                // More log entries...
                logger.Log("This is a log message.");
                logger.Log("Another log message.");
               
            }

        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;
        private bool _disposed = false;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
            _writer = new StreamWriter(filePath, append: true);
        }

        public void Dispose()
        {
            // Implement IDisposable pattern
            Dispose(true);
            GC.SuppressFinalize(this);

        }

        public void Log(string message)
        {
                // Write message to the file
                if (_disposed)
                {
                    throw new ObjectDisposedException("FileLogger", "Cannot log to a disposed FileLogger.");
                }

                _writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}");
                _writer.Flush();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _writer.Dispose();
                }

                _disposed = true;
            }
        }
    }
}
