namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly// 
            using (FileLogger logger = new FileLogger("log.txt"))
            {
                logger.Log("This is a log message.");
                logger.Log("Another log message.");
                // ... more logging

            } // logger will be automatically disposed here
        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            // Initialize StreamWriter instance
            _writer = new StreamWriter(filePath, true); // 'true' appends to the file if it already exists
        }

        public void Dispose()
        {
            // Implement IDisposable pattern
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_writer != null)
                {
                    _writer.Close();
                    _writer.Dispose();
                }
            }
        }
        public void Log(string message)
        {
            // Write message to the file
            _writer.WriteLine($"{DateTime.Now}: {message}");
        }
    }
}