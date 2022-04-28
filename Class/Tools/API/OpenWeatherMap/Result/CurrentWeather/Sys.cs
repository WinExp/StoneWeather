using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.CurrentWeather
{
    internal class Sys
    {
        #region 声明字段
        internal double Type { get; }
        internal double ID { get; }
        internal double Message { get; }
        internal string Country { get; }
        internal double Sunrise { get; }
        internal double Sunset { get; }
        #endregion

        #region 构造方法
        internal Sys(JToken WeatherData)
        {
            if (WeatherData == null)
            {
                throw new ArgumentNullException("The value cannot be null.");
            }
            this.Type = WeatherData.Value<double>("type");
            this.ID = WeatherData.Value<double>("id");
            this.Message = WeatherData.Value<double>("message");
            this.Country = WeatherData.Value<string>("country");
            this.Sunrise = WeatherData.Value<double>("sunrise");
            this.Sunset = WeatherData.Value<double>("sunset");
        }
        #endregion
    }
}
