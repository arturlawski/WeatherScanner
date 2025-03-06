using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WeatherSofomo.Persistence
{
    public interface IWeatherService
    {
        Task<string> GetWeatherAsync(float latitude, float longitude);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openWeatherApiKey;

        public WeatherService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _openWeatherApiKey = configuration["OpenWeather:ApiKey"] ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<string> GetWeatherAsync(float latitude, float longitude)
        {
            var apiUrl = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={_openWeatherApiKey}";
            try
            {
                var response = await _httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                var responseData = await response.Content.ReadAsStringAsync();
                return responseData;
            }
            catch (HttpRequestException ex)
            {
                return null;
            }
        }
    }
}