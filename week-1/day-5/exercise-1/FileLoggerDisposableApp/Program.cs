namespace FileLoggerDisposableApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Use FileLogger and dispose of it properly
            using (var logger = new FileLogger(@"C:\Users\admin\Documents\Week_1\four-weeks-training\week-1\day-5\exercise-1\FileLoggerDisposableApp\log.txt"))
            {
                logger.Log("Log entry 1");
                logger.Log("Log entry 2");
            }

            Console.WriteLine("Log entries entered and logger disposed.");
        }
    }

    class FileLogger : IDisposable
    {
        private StreamWriter _writer;
        private bool disposed = false;

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

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _writer.Dispose();
                }
                disposed = true;
            }
        }

        //~FileLogger()
        //{
        //    Dispose(false);
        //}

        public void Log(string message)
        {
            // Write message to the file
            if (_writer != null) 
            _writer.WriteLine($"{DateTime.Now}; {message}");
        }
    }
}