using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.OpenWeatherMap
{
    internal class Main
    {
        #region 声明字段
        internal double CelsiusFeels_Like { get; }
        internal double FahrenheitFeels_Like { get; }
        internal double KelvinFeels_Like { get; }
        internal double CelsiusTemp { get; }
        internal double FahrenheitTemp { get; }
        internal double KelvinTemp { get; }
        internal double CelsiusTemp_Min { get; }
        internal double CelsiusTemp_Max { get; }
        internal double FahrenheitTemp_Min { get; }
        internal double FahrenheitTemp_Max { get; }
        internal double KelvinTemp_Min { get; }
        internal double KelvinTemp_Max { get; }
        internal double Pressure { get; }
        internal double Humidity { get; }
        #endregion

        #region 构造方法
        internal Main(JToken WeatherData)
        {
            if (WeatherData == null)
            {
                throw new ArgumentNullException("The value cannot be null.");
            }
            this.KelvinTemp = WeatherData.Value<double>("temp");
            this.KelvinFeels_Like = WeatherData.Value<double>("feels_like");
            this.KelvinTemp_Min = WeatherData.Value<double>("temp_min");
            this.KelvinTemp_Max = WeatherData.Value<double>("temp_max");
            this.CelsiusTemp = ConvertToCelsius(this.KelvinTemp);
            this.CelsiusFeels_Like = ConvertToCelsius(this.KelvinFeels_Like);
            this.CelsiusTemp_Min = ConvertToCelsius(this.KelvinTemp_Min);
            this.CelsiusTemp_Max = ConvertToCelsius(this.KelvinTemp_Max);
            this.FahrenheitTemp = ConvertToFahrenheit(this.CelsiusTemp);
            this.FahrenheitFeels_Like = ConvertToFahrenheit(this.CelsiusFeels_Like);
            this.FahrenheitTemp_Min = ConvertToFahrenheit(this.CelsiusTemp_Min);
            this.FahrenheitTemp_Max = ConvertToFahrenheit(this.CelsiusTemp_Max);
            this.Pressure = WeatherData.Value<double>("pressure");
            this.Humidity = WeatherData.Value<double>("humidity");
        }
        #endregion

        #region 单位转换方法
        private static double ConvertToFahrenheit(double Celsius)
        {
            return Math.Round((9 / 5 * Celsius) + 32, 3);
        }

        private static double ConvertToCelsius(double Kelvin)
        {
            return Math.Round(Kelvin - 273.15, 3);
        }
        #endregion
    }
}
