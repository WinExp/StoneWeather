using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.CurrentWeather
{
    internal class Main
    {
        #region 声明字段
        internal double Feels_Like { get; }
        internal double Temp { get; }
        internal double Temp_Min { get; }
        internal double Temp_Max { get; }
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
            this.Temp = WeatherData.Value<double>("temp");
            this.Feels_Like = WeatherData.Value<double>("feels_like");
            this.Temp_Min = WeatherData.Value<double>("temp_min");
            this.Temp_Max = WeatherData.Value<double>("temp_max");
            this.Pressure = WeatherData.Value<double>("pressure");
            this.Humidity = WeatherData.Value<double>("humidity");
        }
        #endregion
    }
}
