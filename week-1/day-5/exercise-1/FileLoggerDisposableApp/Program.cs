namespace Day5_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var logger = new FileLogger(@"C:\Users\admin\source\repos\Day5_Task1\Day5_Task1\log.txt"))
            {
                logger.Log("This is a log message");
                logger.Log("Another log message");
                Console.WriteLine("Successfully type message");
            }
           
        }
    }

    public class FileLogger : IDisposable
    {
        StreamWriter writer;

        public FileLogger(String fileppath)
        {
            writer = new StreamWriter(fileppath,append:true);
        }

        //interface method to must implement
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //for memory management does not done automatic we have to apply this.
        }

        public virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                if (writer != null)
                {
                    writer.Dispose();
                    writer = null;
                }
            }
        }

        public void Log(string message)
        {
            string formattedMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";

            writer.WriteLine(formattedMessage);
          
    }
}