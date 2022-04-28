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
        internal static async Task<Result.CurrentWeather.WeatherResult> GetCurrentWeatherResultAsync(string APIKey, string City, string Language)
        {
            string Response = await Net.Http.Client.GetRequest($"https://api.openweathermap.org/data/2.5/weather?q={City}&units=metric&lang={Language}&appid={APIKey}");
            Result.CurrentWeather.WeatherResult Result = new Result.CurrentWeather.WeatherResult(Response);
            return Result;
        }
        #endregion
    }
}
