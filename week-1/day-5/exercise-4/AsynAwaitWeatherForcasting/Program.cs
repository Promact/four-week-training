namespace Day5_Task4
{
    internal class Program
    {
        static  void Main(string[] args)
        {
            String[] urls =
            {
                "www.google.com",
                "www.youtube.com",
            };

            var tasks = new Task<string>[urls.Length];
            for(int i = 0;i< urls.Length;i++)
            {
                tasks[i] = fetchDataAsync(urls[i]);
            }

             Task.WhenAll(tasks).GetAwaiter().GetResult();

            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"URL: {urls[i]}, Content Length: {tasks[i].Result.Length}");
            }

        }

        static async Task<String> fetchDataAsync(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    String content = await client.GetStringAsync(url);
                    return content;
                }
                catch (Exception ex)
                {
                    return $"Error fetching {url}: {ex.Message}";

                }
            }
        }

    }
}