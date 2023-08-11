using Newtonsoft.Json;

namespace AsynAwaitWeatherForcasting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string city = "Vadodara, India";
            string key = "929b546db3a40dc10e07b8c87cf143c2";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}";
            // Call the method to fetch weather data
            WeatherData weatherData = await FetchWeatherDataAsync(url);
            // Display the weather data with city name
            if (weatherData != null)
            {
                Console.WriteLine($"Temperature: {Math.Round(weatherData.Main.Temp - 273.15f)}°C");
                Console.WriteLine($"Description: {weatherData.Weather[0].Description}");
            }
            else
            {
                Console.WriteLine("Something went wrong, Api fetching failed.");
            }

        }

        // Call OpenWeatherMap API to fetch weather data https://openweathermap.org/api
        // Create a C# object from the JSON response
        // Replace Task<string> with the C# object Task<WeatherData>
        static async Task<WeatherData> FetchWeatherDataAsync(string url)
        {
            // Fetch web page content asynchronously using HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                    return weatherData;
                }
                else
                {
                    Console.WriteLine($"API call failed with status code: {response.StatusCode}");
                    return null;
                }
            }

        }
    }

    public class WeatherData
    {
        public WeatherMain Main { get; set; }
        public WeatherDescription[] Weather { get; set; }
    }

    public class WeatherMain
    {
        public float Temp { get; set; }
    }

    public class WeatherDescription
    {
        public string Description { get; set; }
    }
}