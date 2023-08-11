using Newtonsoft.Json;
using System;

namespace Day5_Task4
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            String urls =
                "https://api.openweathermap.org/data/2.5/weather?lat=22.3072&lon=73.1812&appid=cfc445455912c235199387bb8f8d45c6";


            WeatherData weatherData = await fetchDataAsync(urls);
            Console.ForegroundColor = ConsoleColor.Yellow;


            Console.WriteLine($"Weather in vadodara:");
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Temperature: " + (int)(weatherData.Main.Temp - 273.15) + "°C");
            Console.WriteLine($"Weather: {weatherData.Weather[0].Description}");
            Console.ResetColor();

        }

        //for fetching data from api
        static async Task<WeatherData> fetchDataAsync(string url)
        {
            using(HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json);
                    return weatherData;
                }
                else
                {
                    throw new Exception($"{response.StatusCode}");
                }
            }
        }

        public class WeatherData
        {
            public MainData Main { get; set; }
            public WeatherDesc[] Weather { get; set; }
        }

        public class MainData
        {
            public float Temp { get; set; }
        }

        public class WeatherDataDesc
        {
            public String Description { get; set; }
        }

    }
}