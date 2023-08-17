using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AsynAwaitWeatherForcasting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string city = "Vadodara, India";
            string apiKey = "YOUR_API_KEY";

            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

            WeatherData weatherData = await FetchWeatherDataAsync(url);
            DisplayWeatherData(weatherData);
        }

        static async Task<WeatherData> FetchWeatherDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                string json = await client.GetStringAsync(url);
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                return weatherData;
            }
        }

        static void DisplayWeatherData(WeatherData weatherData)
        {
            Console.WriteLine($"Weather data for {weatherData.City}:");
            // Display other weather information
        }
    }

    public class WeatherData
    {
        public string City { get; set; }
        // Other properties representing weather information
    }
}
