namespace FileLoggerDisposableApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            using (FileLogger logger = new FileLogger(@"C:\Users\admin\Documents\Week-1\four-weeks-training\week-1\day-5\exercise-1\FileLoggerDisposableApp\log.txt"))
            {
                logger.Log("This is a log entry.");
                logger.Log("Another log entry.");
            }
        }
    }

    public class FileLogger : IDisposable
    {
        private StreamWriter _writer;

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
        protected virtual void Dispose(bool disposing)
        {
            // Check if the Dispose method is being called explicitly by the user code
            if (disposing)
            {
                // Check if the _writer field is not null when it has been initialized
                if (_writer != null)
                {
                    // It release the resources
                    _writer.Dispose();
                    // Set _writer to null to indicate that it has been disposed
                    _writer = null!;
                }
            }
        }

        public void Log(string message)
        {
            // Write message to the file
            if (_writer != null)
            {
                _writer.WriteLine($"{DateTime.Now}: {message}");
                // Clears all buffers for this TextWriter
                _writer.Flush();
            }
        }
    }
}