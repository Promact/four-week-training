using Newtonsoft.Json;

namespace AsynAwaitWeatherForcasting
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string city = "Vadodara, India";
            string apikey = "5c49172b6b94ca1313988159470df225";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apikey}";

            // Call the method to fetch weather data
            WeatherData weatherData = await FetchWeatherDataAsync(url);

            // Display the weather data with city name
            Console.WriteLine($"Weather in {city}:");
            Console.WriteLine($"Temperature: {Math.Round(weatherData.Main.Temp - 273.15,2)}°C");
            Console.WriteLine($"Weather: {weatherData.Weather[0].Description}");
        }

        // Call OpenWeatherMap API to fetch weather data https://openweathermap.org/api
        // Create a C# object from the JSON response
        // Replace Task<string> with the C# object Task<WeatherData>
        static async Task<WeatherData> FetchWeatherDataAsync(string url)
        {
            // Fetch web page content asynchronously using HttpClient
            //throw new NotImplementedException();
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a JSON string
                        string json = await response.Content.ReadAsStringAsync();
                        WeatherData data = JsonConvert.DeserializeObject<WeatherData>(json);
                        return data;
                    }
                    else
                    {
                        Console.WriteLine($"Error fetching data: {response.StatusCode}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching weather data: {ex.Message}");
                    
                }
                return null!;
            }
        }
    }
}