using AsynAwaitWeatherForcasting.Models;
using Newtonsoft.Json;

namespace AsynAwaitWeatherForcasting
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            string city = "Vadodara, India";
            // Call the method to fetch weather data
            // Display the weather data with city name
            // API key for authorization
            string apiKey = "929b546db3a40dc10e07b8c87cf143c2";
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

            WeatherData weatherData = await FetchWeatherDataAsync(url);
            if (weatherData != null)
            {
                Console.WriteLine($"Weather in {city}:");
                Console.WriteLine($"Temperature: {Math.Round(weatherData.Main.Temp - 273.15, 2)} °C");
                Console.WriteLine($"Weather: {weatherData.Weather[0].Description}");
            }
            else
            {
                Console.WriteLine($"Could not fetch weather data for {city}.");
            }
        }

        // Call OpenWeatherMap API to fetch weather data https://openweathermap.org/api
        // Create a C# object from the JSON response
        // Replace Task<string> with the C# object Task<WeatherData>
        static async Task<WeatherData> FetchWeatherDataAsync(string url)
        {
            // Fetch web page content asynchronously using HttpClient
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // Call GET request to the WheatherApi
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a JSON string
                        string json = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON string to a WeatherData object
                        WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(json)!;
                        return weatherData;
                    }
                    else
                    {
                        Console.WriteLine($"Error fetching data: {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error fetching data: {ex.Message}");
                }
            }
            return null!;
        }
    }
}