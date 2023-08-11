namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
             using (FileLogger logger = new FileLogger("C:\\Users\\admin\\log.txt"))
            {
                logger.Log("This is a log entry.");
                logger.Log("Another log entry.");
            }

        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            _writer = new StreamWriter(filePath, append: true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_writer != null)
                {
                    _writer.Dispose();
                    _writer = null;
                }
            }
        }

        public void Log(string message)
        {
            if (_writer != null)
            {
                _writer.WriteLine($"{DateTime.Now}: {message}");
                _writer.Flush();
            }
        }
    }


}

