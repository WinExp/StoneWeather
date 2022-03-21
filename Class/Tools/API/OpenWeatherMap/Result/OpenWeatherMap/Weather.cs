using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoneWeather.Class.Tools.API.OpenWeatherMap.Result.OpenWeatherMap
{
    internal class Weather
    {
        #region 声明字段
        internal double ID { get; }
        internal string Main { get; }
        internal string Description { get; }
        internal string Icon { get; }
        #endregion

        #region 构造方法
        internal Weather(JToken WeatherData)
        {
            if (WeatherData == null)
            {
                throw new ArgumentNullException("The value cannot be null.");
            }
            this.ID = WeatherData.Value<double>("id");
            this.Main = WeatherData.Value<string>("main");
            this.Description = WeatherData.Value<string>("description");
            this.Icon = WeatherData.Value<string>("icon");
        }
        #endregion
    }
}
