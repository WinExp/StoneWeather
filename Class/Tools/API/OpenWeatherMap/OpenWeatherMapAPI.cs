using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap
{
    internal static class OpenWeatherMapAPI
    {
        #region OpenWeatherAPI 方法
        internal static async Task<Result.OpenWeatherMap.WeatherResult> GetWeatherAsync(string APIKey, string City, string Language)
        {
            string Response = await Net.Http.Client.GetRequest($"https://api.openweathermap.org/data/2.5/weather?q={City}&lang={Language}&appid={APIKey}");
            Result.OpenWeatherMap.WeatherResult Result = new Result.OpenWeatherMap.WeatherResult(Response);
            return Result;
        }

        internal static async Task<Result.OpenWeatherMap.WeatherResult> GetWeatherAsync(string APIKey, string City, string Nation, string Language)
        {
            string Response = await Net.Http.Client.GetRequest($"https://api.openweathermap.org/data/2.5/weather?q={City},{Nation}&lang={Language}&appid={APIKey}");
            Result.OpenWeatherMap.WeatherResult Result = new Result.OpenWeatherMap.WeatherResult(Response);
            return Result;
        }
        #endregion
    }
}
