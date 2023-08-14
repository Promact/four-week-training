using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsynAwaitWeatherForcasting
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            string city = "Vadodara, India";
            string apiKey = "1e4d999bb01f734b6185144802f2b581";
            double latitude = 22.3072; 
            double longitude = 73.1812; 

            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}";

            WeatherData weatherData = await FetchWeatherDataAsync(url);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Weather in {city}:");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Temperature: "+(int)(weatherData.Main.Temp-273.15)+"°C");
            Console.WriteLine($"Weather: {weatherData.Weather[0].Description}");
            Console.ResetColor();

        }

        static async Task<WeatherData> FetchWeatherDataAsync(string url)
        {
            using HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                return weatherData;
            }
            else
            {
                throw new Exception($"Failed to fetch weather data. Status code: {response.StatusCode}");
            }
        }
    }

    public class WeatherData
    {
        public MainData Main { get; set; }
        public WeatherDescription[] Weather { get; set; }
    }

    public class MainData
    {
        public float Temp { get; set; }
    }

    public class WeatherDescription
    {
        public string Description { get; set; }
    }
}
